using Android.Widget;
using GalaSoft.MvvmLight.Views;
using smoker;

namespace Smoker
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the MainActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class MainActivity : ActivityBase
    {
        private TextView _tvSmokesToday;

        public TextView TvSmokesToday
        {
            get
            {
                return _tvSmokesToday
                       ?? (_tvSmokesToday = FindViewById<TextView>(Resource.Id.main_tv_nbSmokesToday));
            }
        }

        private Button _btnAddSmoke;

        public Button BtnAddSmoke
        {
            get
            {
                return _btnAddSmoke
                       ?? (_btnAddSmoke = FindViewById<Button>(Resource.Id.main_btn_addSmoke));
            }
        }

    }
}