using Logintest.Models;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace Logintest.Views
{
    public partial class HomePage : ContentPage
    {
        SQLiteConnection conn;
        public TypeModel TypeModel;
        public HomePage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLiteInterface>().GetConnection();
            conn.CreateTable<TypeModel>();
           
            var sourceData = (from User in conn.Table<User>() select User);
            listUser.ItemsSource = sourceData;

        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Quit", "You want Quit", "OK");
            Application.Current.Quit();
            await Navigation.PushAsync(new MainPage());

        }

        private async void Add_Clicked(object sender, System.EventArgs e)
        {
           await Navigation.PushAsync(new AddPage());
        }

        private void See_Clicked(object sender, System.EventArgs e)
        {
            var data = (from TypeModel in conn.Table<TypeModel>() select TypeModel);
            Datalist.ItemsSource = data;
        }
    }
}
