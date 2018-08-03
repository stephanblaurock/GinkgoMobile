using System;
namespace Ginkgo.Common {
	public class GinkgoAppModule {
		public static GinkgoAppModule Default;

		public GinkgoAppModule() {
			Default = this;
		}
	}
}
