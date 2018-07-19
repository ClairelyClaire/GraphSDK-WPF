using Microsoft.Identity.Client;
using System.Windows;

namespace GraphSDK_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // portal.azure.com
        private static string AzureAppId = "9cc033c6-6227-4c3a-992e-977169a77447";
        public static PublicClientApplication AzureApp = new PublicClientApplication(AzureAppId);

        // apps.dev.microsoft.com
        private static string DevAppId = "dea2b33e-dccb-4f90-92e1-0594fbc93fa8";
        public static PublicClientApplication DevApp = new PublicClientApplication(DevAppId);
    }
}
