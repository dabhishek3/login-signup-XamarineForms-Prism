using Logintest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Logintest.Views
{
    public partial class SignupPage : ContentPage
    {
        private SQLiteConnection conn;
        public SignupPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLiteInterface>().GetConnection();
            conn.CreateTable<User>();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {

            
            User user = new User();
            user.userName = entryuser.Text;
            user.name = entryname.Text;
            user.phone = entryphone.Text;
            user.email = entryemail.Text;
            user.address = entryaddress.Text;
            user.password = entrypassword.Text;
            conn.Insert(user);
            IEnumerable<User> Data = conn.Query<User>("select * from user");
            await DisplayAlert("Congratulation" ," User Registration Successfull", "Yes","Cancel");
            await Navigation.PopAsync();
            }
            catch(Exception ex)
            { 
            }

        }
    }
}





