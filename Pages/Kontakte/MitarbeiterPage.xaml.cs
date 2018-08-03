using System;
using System.Collections.Generic;
using Modules.Cross.Kontakte.Models;
using Modules.Cross.Kontakte.PageModels;
using Xamarin.Forms;

namespace Ginkgo.Pages.Kontakte {
	public partial class MitarbeiterPage : ContentPage {
		private MitarbeiterPageModel _PageModel;
		public MitarbeiterPage() {
			InitializeComponent();

			this._PageModel = new MitarbeiterPageModel();
			this.BindingContext = this._PageModel;
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			//var item = (MenuItem)sender;
			Mitarbeiter mitarbeiter = e.Item as Mitarbeiter;
			var action = await DisplayActionSheet("Mitarbeiter-Aktion", "Abbrechen", null,
												  "Festnetz anrufen", "Mobil anrufen", "Mail schreiben");
			if (action == "Festnetz anrufen") {
				Device.OpenUri(new Uri("tel:" + mitarbeiter.Telefon));
			} else if (action == "Mobil anrufen") {

				Device.OpenUri(new Uri("tel:" + mitarbeiter.Mobil));
			} else if (action == "Mail schreiben") {

				Device.OpenUri(new Uri("mailto:" + mitarbeiter.EMail));
			}
		}
	}
}
