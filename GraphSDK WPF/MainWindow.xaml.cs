using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Windows;

namespace GraphSDK_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] _scopes = new string[] { "User.Read" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void cmdAzureLogin_Click(object sender, RoutedEventArgs e)
        {
            // results of auth token request
            AuthenticationResult authResult = null;

            try
            {
                // MSAL points to the AAD/MSA v2 endpoint by default
                // nothing else is needed here, I think

                // acquire silently first - this will refresh an existing token or sign in the current user (?)
                authResult = await App.AzureApp.AcquireTokenSilentAsync(_scopes, App.AzureApp.Users.FirstOrDefault());
            }
            catch (MsalUiRequiredException ex)
            {
                // if an exception occurs, AcquireTokenAsync is required (interactive login)
                txtResult.Text = $"MsalUiRequiredException: {ex.Message}";

                // try an interactive login
                try
                {
                    authResult = await App.AzureApp.AcquireTokenAsync(_scopes);
                }
                catch (MsalException msalex)
                {
                    // something terrible happened
                    txtResult.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
            catch (Exception ex)
            {
                // something terrible happened
                txtResult.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
            }

            // now you can try to do something with the returned auth stuffs.
            if (authResult != null)
            {
                // do a thing
            }
        }

        private async void cmdDevLogin_Click(object sender, RoutedEventArgs e)
        {
            // results of auth token request
            AuthenticationResult authResult = null;

            try
            {
                // MSAL points to the AAD/MSA v2 endpoint by default
                // nothing else is needed here, I think

                // acquire silently first - this will refresh an existing token or sign in the current user (?)
                authResult = await App.DevApp.AcquireTokenSilentAsync(_scopes, App.DevApp.Users.FirstOrDefault());
            }
            catch (MsalUiRequiredException ex)
            {
                // if an exception occurs, AcquireTokenAsync is required (interactive login)
               txtResult.Text = $"MsalUiRequiredException: {ex.Message}";

                // try an interactive login
                try
                {
                    authResult = await App.DevApp.AcquireTokenAsync(_scopes);
                }
                catch (MsalException msalex)
                {
                    // something terrible happened
                    txtResult.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
            catch (Exception ex)
            {
                // something terrible happened
                txtResult.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
            }

            // now you can try to do something with the returned auth stuffs.
            if (authResult != null)
            {
                // do a thing
            }
        }
    }
}
