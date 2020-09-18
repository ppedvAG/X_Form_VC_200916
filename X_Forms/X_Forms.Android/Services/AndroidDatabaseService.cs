using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(X_Forms.Droid.Services.AndroidDatabaseService))]
namespace X_Forms.Droid.Services
{
    public class AndroidDatabaseService : IDatabaseService
    {
        public SQLiteConnection Con { get; set; }

        public SQLiteConnection GetConnection()
        {
            string ordner = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string dbName = "PersonenDb.db3";

            string path = Path.Combine(ordner, dbName);

            Con = new SQLiteConnection(path);

            return Con;
        }
    }
}