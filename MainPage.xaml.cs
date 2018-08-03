using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginkgo.Pages.Zeit;
using Ginkgo.Pages.Kontakte;
using Ginkgo.Pages.CTI;
using Ginkgo.Pages.Mails;

using Xamarin.Forms;

namespace Ginkgo {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			this.Title = "Ginkgo";

		}

		void Handle_Mails_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("E-Mails", "coming soon...", "OK");
		}
		void Handle_Tasks_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("Tasks", "coming soon...", "OK");
		}
		void Handle_CTI_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("CTI", "coming soon...", "OK");
		}
		void Handle_Kontakte_Clicked(object sender, System.EventArgs e) {
			this.Navigation.PushAsync(new KontakteTabPage());
		}
		void Handle_Kalender_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("Kalender", "coming soon...", "OK");
		}
		void Handle_Stunden_Clicked(object sender, System.EventArgs e) {
			this.Navigation.PushAsync(new StempelPage());
		}
		void Handle_Geraete_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("Geräte", "coming soon...", "OK");
		}
		void Handle_OMS_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("OMS", "coming soon...", "OK");
		}
		void Handle_Lager_Clicked(object sender, System.EventArgs e) {
			DisplayAlert("Lager", "coming soon...", "OK");
		}
	}
}
