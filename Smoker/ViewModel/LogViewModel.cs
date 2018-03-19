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
    public class LogViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="SmokesToday" /> property's name.
        /// </summary>
        public const string SmokesTodayPropertyName = "SmokesToday";

        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;


        private int _smokesToday = 0;
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

        private RelayCommand _addSmokeCommnand;
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
                               _dataService.InsertSmoke(DateTime.Now, (error) =>
                               {
                                   if (error != null)
                                   {
                                       return;
                                   }
                               });
                           }));
            }
        }

        private RelayCommand _refreshCommnand;
        /// <summary>
        /// Refreshes the SmokesToday with value from DB.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommnand
                       ?? (_refreshCommnand = new RelayCommand(
                           () =>
                           {
                               _dataService.GetSmokeCount((count, error) =>
                               {
                                   if (error != null)
                                   {
                                       return;
                                   }
                                   SmokesToday = count;
                               });
                           }));
            }
        }

        private RelayCommand _resetSmokesCommnand;
        /// <summary>
        /// Gets the IncrementCommand.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand ResetSmokesCommand
        {
            get
            {
                return _resetSmokesCommnand
                       ?? (_resetSmokesCommnand = new RelayCommand(
                           () =>
                           {
                               _dataService.ResetSmokes((error) =>
                               {
                                   if (error != null)
                                   {
                                       return;
                                   }

                                   RefreshSmokesCount();
                               });
                           }));
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public LogViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
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

        private RelayCommand<string> _navigateCommand;
        /// <summary>
        /// Gets the NavigateCommand.
        /// Goes to the second page, using the navigation service.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (_navigateCommand = new RelayCommand<string>(
                           parameter => _navigationService.NavigateTo(
                               ViewModelLocator.LogPageKey,
                               parameter)));
            }
        }

        public void SetupDB()
        {
            _dataService.SetupDB();
        }

        public void CreateSmokeTable()
        {
            _dataService.CreateSmokesTable();
        }

        public void RefreshSmokesCount()
        {
            _dataService.GetSmokeCount((count, error) =>
            {
                if (error != null)
                {
                    return;
                }
                SmokesToday = count;
            });
        }

    }
}