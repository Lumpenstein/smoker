using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Attributes;

namespace smoker.Model
{
    [Table("Smokes")]
    public class Smoke
    {
        public Smoke(int id, long time)
        {
            Id = id;
            Time = time;
        }


        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public long Time { get; set; }

    }
}