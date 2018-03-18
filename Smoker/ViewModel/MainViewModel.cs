using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Smoker.Model;

namespace Smoker.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="SmokesToday" /> property's name.
        /// </summary>
        public const string SmokesTodayPropertyName = "SmokesToday";

        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private int _smokesToday = 0;
        private RelayCommand _addSmokeCommnand;

        /// <summary>
        /// Sets and gets the Clock property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// Use the "mvvminpc*" snippet group to create more such properties.
        /// </summary>
        public int SmokesToday
        {
            get
            {
                return _smokesToday;
            }
            set
            {
                Set(ref _smokesToday, value);
            }
        }

        /// <summary>
        /// Gets the IncrementCommand.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand AddSmokeCommand
        {
            get
            {
                return _addSmokeCommnand
                       ?? (_addSmokeCommnand = new RelayCommand(
                           () =>
                           {
                               SmokesToday++;
                           }));
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private RelayCommand _sendMessageCommand;

        /// <summary>
        /// Gets the SendMessageCommand.
        /// </summary>
        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                    ?? (_sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        // Any object can send messages.
                        // For this simple demo, the message is received by App.xaml.cs
                        // (see line 98).
                        // This message type also allows a reply to be sent.

                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "AnyNotification",
                                reply =>
                                {

                                }));
                    }));
            }
        }
    }
}