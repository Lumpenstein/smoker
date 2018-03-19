using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using GalaSoft.MvvmLight.Helpers;
using smoker.Model;

namespace smoker.Adapter
{
    class Log_latestSmokesAdapter : RecyclerView.Adapter
    {
        public event EventHandler<Log_latestSmokesAdapterClickEventArgs> ItemClick;
        public event EventHandler<Log_latestSmokesAdapterClickEventArgs> ItemLongClick;
        Smoke[] items;

        public Log_latestSmokesAdapter(Smoke[] smokesArray)
        {
            items = smokesArray;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);

            var vh = new Log_latestSmokesAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as Log_latestSmokesAdapterViewHolder;
            //holder.TextView.Text = items[position];
        }

        public override int ItemCount => items.Length;

        void OnClick(Log_latestSmokesAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(Log_latestSmokesAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class Log_latestSmokesAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }


        public Log_latestSmokesAdapterViewHolder(View itemView, Action<Log_latestSmokesAdapterClickEventArgs> clickListener,
                            Action<Log_latestSmokesAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            itemView.Click += (sender, e) => clickListener(new Log_latestSmokesAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new Log_latestSmokesAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class Log_latestSmokesAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}