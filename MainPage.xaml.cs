using Logintest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Logintest.Views
{
    public partial class MainPage : ContentPage
    {
        private SQLiteConnection conn;
        public MainPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLiteInterface>().GetConnection();
            conn.CreateTable<User>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}