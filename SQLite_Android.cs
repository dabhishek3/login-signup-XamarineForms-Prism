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
using Logintest.Droid;
using Logintest.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Logintest.Droid
{
    public class SQLite_Android : ISQLiteInterface
    {
        SQLiteConnection conn;
        public SQLiteConnection GetConnection()
        {
            var dbName = "Myapp.db";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
        
    }
}