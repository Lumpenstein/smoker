﻿using Android.Widget;
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
        private Button _btnAddSmoke;
        private Button _btnRefresh;
        private Button _btnReset;
        private Button _btnLogActivity;

        public TextView TvSmokesToday
        {
            get
            {
                return _tvSmokesToday
                       ?? (_tvSmokesToday = FindViewById<TextView>(Resource.Id.main_tv_nbSmokesToday));
            }
        }

        public Button BtnAddSmoke
        {
            get
            {
                return _btnAddSmoke
                       ?? (_btnAddSmoke = FindViewById<Button>(Resource.Id.main_btn_addSmoke));
            }
        }

        public Button BtnRefresh
        {
            get
            {
                return _btnRefresh
                       ?? (_btnRefresh = FindViewById<Button>(Resource.Id.main_btn_refresh));
            }
        }

        public Button BtnReset
        {
            get
            {
                return _btnReset
                       ?? (_btnReset = FindViewById<Button>(Resource.Id.main_btn_reset));
            }
        }

        public Button BtnLogActivity
        {
            get
            {
                return _btnLogActivity
                       ?? (_btnLogActivity = FindViewById<Button>(Resource.Id.main_btn_logActivity));
            }
        }

    }
}