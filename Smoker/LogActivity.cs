using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using smoker;
using Smoker.ViewModel;
using SQLite.Net.Async;
using Messenger = GalaSoft.MvvmLight.Messaging.Messenger;

namespace Smoker
{
    [Activity(Label = "Smoker")]
    public partial class LogActivity
    {
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> _bindings = new List<Binding>();

        /// <summary>
        /// Gets a reference to the LogViewModel from the ViewModelLocator.
        /// </summary>
        private LogViewModel Vm
        {
            get
            {
                return App.Locator.Log;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "Second" layout resource
            SetContentView(Resource.Layout.act_log);

            // Retrieve navigation parameter and set as current "DataContext"
            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var p = nav.GetAndRemoveParameter<string>(Intent);

            BtnBack.Click += (s, e) => nav.GoBack();
        }

        private void HandleNotificationMessage(NotificationMessageAction<string> message)
        {
            // Execute a callback to send a reply to the sender.
            message.Execute("Success! (from MainActivity.cs)");
        }
    }
}

