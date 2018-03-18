using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using smoker;
using Smoker.ViewModel;
using SQLite.Net.Async;
using Messenger = GalaSoft.MvvmLight.Messaging.Messenger;

namespace Smoker
{
    [Activity(Label = "Smoker", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity
    {
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> _bindings = new List<Binding>();

        /// <summary>
        /// Gets a reference to the MainViewModel from the ViewModelLocator.
        /// </summary>
        private MainViewModel Vm
        {
            get
            {
                return App.Locator.Main;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Illustrates how to use the Messenger by receiving a message
            // and sending a message back.
            Messenger.Default.Register<NotificationMessageAction<string>>(
                this,
                HandleNotificationMessage);

            // Binding and commanding

            // Binding between the first TextView and the WelcomeTitle property on the VM.
            // Keep track of the binding to avoid premature garbage collection
            _bindings.Add(
                this.SetBinding(
                    () => Vm.SmokesToday,
                    () => TvSmokesToday.Text));

            // Actuate the IncrementCommand on the VM.
            BtnAddSmoke.SetCommand(
                "Click",
                Vm.AddSmokeCommand);

            // Setup DB
            Vm.SetupDB();
            Vm.CreateSmokeTable();

            Vm.UpdateSmokesToday();

        }

        private void HandleNotificationMessage(NotificationMessageAction<string> message)
        {
            // Execute a callback to send a reply to the sender.
            message.Execute("Success! (from MainActivity.cs)");
        }
    }
}

