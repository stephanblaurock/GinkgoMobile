using System;
using System.Collections.Generic;
using CrossUtils.Json;
using Modules.Cross;
using Modules.Cross.CTI;
using Modules.Cross.CTI.Models;
using Xamarin.Forms;

namespace Ginkgo.Pages.CTI {
	public partial class AnruferlistePage : ContentPage {
		public AnruferlistePage() {
			InitializeComponent();
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			//var item = (MenuItem)sender;
			CallInfo call = e.Item as CallInfo;
			var action = await DisplayActionSheet("Anruf-Aktion", "Abbrechen", null,
												  "über Handy anrufen", "über Tapi anrufen");
			if (action == "über Handy anrufen") {
				Device.OpenUri(new Uri("tel:" + call.AnruferNumber));
			} else if (action == "über Tapi anrufen") {
				JsonCommand cmd = CTIServiceCommands.MakeTapiCall("", call.AnruferNumber);
				JsonCommandRetValue retval = await ModulesClientEnvironment.Default.JsonCommandClient.DoCommand(cmd);
			}

		}
	}
}
