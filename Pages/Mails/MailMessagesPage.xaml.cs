using System;
using System.Collections.Generic;
using Modules.Cross.Mails.Models;
using Modules.Cross.Mails.PageModels;
using Xamarin.Forms;

namespace Ginkgo.Pages.Mails {
	public partial class MailMessagesPage : ContentPage {
		private MailMessagesPageModel _PageModel;
		public MailMessagesPage() {
			InitializeComponent();
			this.Title = "E-Mails";
			this.Icon = "calendar_dark_50.png";
			this._PageModel = new MailMessagesPageModel();
			this.BindingContext = this._PageModel;
			//this.SetBinding(Page.TitleProperty, "PageTitle");
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			var dataItem = (MailMessageListItem)(e.Item);
			//this.GetPageModel().ItemTapped(dataItem);
		}

		void HandleToolbutton_Clicked(object sender, System.EventArgs e) {

			//_FolderDrawer.ToggleDrawer();

		}

		void Folderlist_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			var dataItem = (MailFolder)(e.Item);
			//this.GetPageModel().Folderlist_ItemTapped(dataItem);
			//_FolderDrawer.IsOpen = false;
		}

		async void ContextMoreClicked(object sender, EventArgs e) {
			var item = (MenuItem)sender;
			MailMessageListItem msg = item.CommandParameter as MailMessageListItem;
			//DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
			var action = await DisplayActionSheet("Welche Aktion möchten Sie ausführen?", "Abbrechen", null,
												  "gelb markieren", "rot markieren", "Markierung aufheben", "als erledigt markieren");
			if (action == "gelb markieren") {
				//this.GetPageModel().SetMessageFlags(msg, -1, -1, 1);
			} else if (action == "rot markieren") {
				//this.GetPageModel().SetMessageFlags(msg, -1, -1, 2);
			} else if (action == "Markierung aufheben") {
				//this.GetPageModel().SetMessageFlags(msg, -1, -1, 0);
			} else if (action == "als erledigt markieren") {
				//this.GetPageModel().SetMessageFlags(msg, -1, msg.FlagErledigt ? 0 : 1, -1);
			}
		}

		void ContextDeleteClicked(object sender, EventArgs e) {
			var item = (MenuItem)sender;
			MailMessageListItem msg = item.CommandParameter as MailMessageListItem;
			//this.GetPageModel().DeleteMessage(msg);
		}
	}
}
