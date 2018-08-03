using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Modules.Cross.Zeit.ViewModels;
using Modules.Cross.Zeit.Models;

namespace Ginkgo.Pages.Zeit {
	public partial class StempelPage : ContentPage {
		private StempelPageViewModel _ViewModel;
		public StempelPage() {
			InitializeComponent();
			this.Title = "Zeiterfassung";
			_ViewModel = new StempelPageViewModel();
			_ViewModel.PropertyChanged += _ViewModel_PropertyChanged;
			this.BindingContext = _ViewModel;
			this._ListView.ItemsSource = this._ViewModel.StempelTagInfos;
			this.Appearing += (object sender, EventArgs e) => { this._PIN.Focus(); };
		}

		void _ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
			if (e.PropertyName == "LoginTextboxVisible" && _ViewModel.LoginTextboxVisible == true) {
				this._PIN.Focus();
			}

		}


		private async void Login_Handle_Clicked(object sender, System.EventArgs e) {
			if (this._ButtLogin.Text == "LOGIN") {
				string pin = _PIN.Text;
				_PIN.Text = "";
				var retval = await this._ViewModel.Login(pin);
				if (!retval.success) {
					await DisplayAlert("Login", retval.message, "OK");
				}
			} else {
				this._ViewModel.Logout();
			}
		}

		private async void KOMMEN_Handle_Clicked(object sender, System.EventArgs e) {
			var retval = await this._ViewModel.AddStempelzeit(true);
			if (!retval.success) {
				await DisplayAlert("KOMMEN", retval.message, "OK");
			}
		}


		private async void GEHEN_Handle_Clicked(object sender, System.EventArgs e) {
			var retval = await this._ViewModel.AddStempelzeit(true);
			if (!retval.success)
				await DisplayAlert("GEHEN", retval.message, "OK");
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			var st = e.Item as StempelTagInfo;
			var manualPage = new StempelZeitManualPage(st, _ViewModel.CurrentUser.ID);
			manualPage.Disappearing += (object osender, EventArgs oe) => {
				this._ViewModel.RefreshStempelTagInfos();
			};
			await Navigation.PushModalAsync(manualPage);
		}
	}
}
