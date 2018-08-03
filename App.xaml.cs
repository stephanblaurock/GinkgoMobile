using System;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ginkgo {
	public partial class App : Application {
		public App() {
			InitializeComponent();
			FlowListView.Init();

			new Modules.Cross.ModulesClientEnvironment("http://service.graule-technik.de:8077", "blaurock@graule-technik.de", "res");
			NavigationPage navPage = new NavigationPage(new MainPage());
			navPage.BarBackgroundColor = Ginkgo.Common.GinkgoAppSettings.AccentColor;
			navPage.BarTextColor = Color.White;
			MainPage = navPage;
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
