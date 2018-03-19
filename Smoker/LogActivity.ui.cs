using Android.Widget;
using GalaSoft.MvvmLight.Views;
using smoker;

namespace Smoker
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the LogActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class LogActivity : ActivityBase
    {
        private Button _btnBack;
        //private Button _btnBack;

        public Button BtnBack
        {
            get
            {
                return _btnBack
                       ?? (_btnBack = FindViewById<Button>(Resource.Id.log_btn_back));
            }
        }

        //public Button BtnBack
        //{
        //    get
        //    {
        //        return _btnBack
        //               ?? (_btnBack = FindViewById<Button>(Resource.Id.log_btn_back));
        //    }
        //}

    }
}