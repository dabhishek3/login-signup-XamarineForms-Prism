using Logintest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Logintest.Views
{
    public partial class AddPage : ContentPage
    {
        SQLiteConnection conn;
        public AddPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLiteInterface>().GetConnection();
            conn.CreateTable<TypeModel>();
        }

        private async void Save_Clicked(object sender, System.EventArgs e)
        {
            try
            {


                TypeModel typemodel = new TypeModel();
                typemodel.type = (string)myPicker.SelectedItem;
                typemodel.Quotes = Quotes.Text;
                conn.Insert(typemodel);
                IEnumerable<TypeModel> Data = conn.Query<TypeModel>("select * from typemodel");
                await DisplayAlert(null, typemodel.type + "  Saved", "Ok");
                await Navigation.PopAsync();
            }
            catch(Exception ex)
            {

            }


        }
    }
}
