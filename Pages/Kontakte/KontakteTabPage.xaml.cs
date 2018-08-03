using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ginkgo.Pages.Kontakte {
	public partial class KontakteTabPage : TabbedPage {
		public KontakteTabPage() {
			InitializeComponent();
			this.Title = "Kontakte";
			this.Children.Add(new MitarbeiterPage());
			this.Children.Add(new KontaktePage());
		}
	}
}
