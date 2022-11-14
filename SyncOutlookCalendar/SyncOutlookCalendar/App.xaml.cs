﻿using Microsoft.Identity.Client;
using Microsoft.UI.Xaml;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SyncOutlookCalendar
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static IPublicClientApplication ClientApplication;
        //You need to replace your Application ID
        public static string ClientID = "09893c5e-c8e6-4652-9e11-43baa5422854";
        public static string[] Scopes = { "User.Read", "Calendars.Read", "Calendars.ReadWrite" };
        private const string Tenant = "77f1fe12-b049-4919-8c50-9fb41e5bb63b"; 
        private const string Authority = "https://login.microsoftonline.com/" + Tenant;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            ClientApplication = PublicClientApplicationBuilder.Create(ClientID)
        .WithAuthority(Authority)
        .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
        .Build();

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}