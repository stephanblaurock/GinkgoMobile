using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ginkgo.Pages.Mails {
	public partial class MailMessagePage : ContentPage {
		public MailMessagePage() {
			InitializeComponent();
			this.Title = "Nachricht";
		}

		async void HandleSettings_Clicked(object sender, System.EventArgs e) {
			var action = await DisplayActionSheet("Welche Aktion möchten Sie ausführen?", "Abbrechen", null,
											  "gelb markieren", "rot markieren", "Markierung aufheben", "als erledigt markieren");
			if (action == "gelb markieren") {
				//this.GetPageModel().SetMessageFlags(-1, -1, 1);
			} else if (action == "rot markieren") {

				//this.GetPageModel().SetMessageFlags(-1, -1, 2);
			} else if (action == "Markierung aufheben") {

				//this.GetPageModel().SetMessageFlags(-1, -1, 0);
			} else if (action == "als erledigt markieren") {

				//this.GetPageModel().SetMessageFlags(-1, 1, -1);
			}
		}
	}
}
