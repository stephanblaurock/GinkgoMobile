using System;
using System.Collections.Generic;
using Modules.Cross.Kontakte.PageModels;
using Xamarin.Forms;

namespace Ginkgo.Pages.Kontakte {
	public partial class KontaktePage : ContentPage {
		private KontaktePageModel _PageModel;
		public KontaktePage() {
			InitializeComponent();
			this.Title = "Kontakte";
			this.Icon = "contact_dark";

			this._PageModel = new KontaktePageModel();
			this.BindingContext = this._PageModel;
		}
	}
}
