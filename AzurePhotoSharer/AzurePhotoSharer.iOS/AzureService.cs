﻿using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(AzurePhotoSharer.iOS.AzureService))]

namespace AzurePhotoSharer.iOS
{
    public class AzureService : AzureServiceBase
    {
        private static UIViewController GetTopmostViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }
            return vc;
        }

        protected override async Task AuthenticateUser()
        {
            await Client.LoginAsync(GetTopmostViewController(),
                                    MobileServiceAuthenticationProvider.MicrosoftAccount,
                                    CallbackName);
        }
    }
}