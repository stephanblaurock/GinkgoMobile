using System;
using System.Collections.Generic;
using Modules.Cross.Zeit.Models;
using Xamarin.Forms;
using CrossUtils.Extensions;
using CrossUtils.Json;
using Modules.Cross.Zeit;
using Modules.Cross;

namespace Ginkgo.Pages.Zeit {
	public partial class StempelZeitManualPage : ContentPage {

		private StempelTagInfo _StempelTagInfo;
		private int _UserID = 0;
		public StempelZeitManualPage(StempelTagInfo sti, int userID) {
			InitializeComponent();
			_StempelTagInfo = sti;
			_UserID = userID;
			this.BindingContext = _StempelTagInfo;
			this._TimePicker.Time = DateTime.Now.TimeOfDay;
		}

		async void Cancel_Handle_Clicked(object sender, EventArgs args) {
			await Navigation.PopModalAsync();
		}
		void Delete_Handle_Clicked(object sender, EventArgs args) {
			// Daten noch speichern...
			this.CreateStempelzeit(true);
			// await Navigation.PopModalAsync();
		}
		void Add_Handle_Clicked(object sender, EventArgs args) {
			// Daten noch speichern...
			this.CreateStempelzeit(false);
			// await Navigation.PopModalAsync();
		}

		private async void CreateStempelzeit(bool delete) {
			Stempelzeit sz = new Stempelzeit();
			sz.Datum = _StempelTagInfo.Datum.ResetTimePart() + _TimePicker.Time;
			sz.Datum = sz.Datum.ResetTimePartToMinute();
			sz.Grund = "G";
			sz.IDKontakt = _StempelTagInfo.IDKontakt;
			sz.Manual = true;
			sz.TimeCreated = DateTime.Now;
			sz.UserIDCreated = _UserID;
			sz.ShouldDeleted = delete;
			sz.UserIDCreated = _UserID;
			JsonCommand cmd = DataFoxServiceCommands.CreateAddOrUpdateStempelzeitCommand(sz);
			JsonCommandRetValue retValue = await ModulesClientEnvironment.Default.JsonCommandClient.DoCommand(cmd);
			if (retValue.ReturnCode == 200)
				await Navigation.PopModalAsync();
			else
				DisplayAlert("Fehler", retValue.ReturnMessage, "OK");
		}

	}
}
