using Logintest.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logintest.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private SQLiteConnection conn;
        public LoginPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLiteInterface>().GetConnection();
            
        }

        

        private async void Button_Clicked_1(object sender, System.EventArgs e)
        {
            var myquery = conn.Table<User>().Where(u => u.userName.Equals(entryuser.Text) && u.password.Equals(entrypassword.Text)).FirstOrDefault();
            if(myquery!=null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
               await DisplayAlert("Error", "Failed To Login Username or Password", "Yes", "Ok");
               await Navigation.PopAsync();
            }
        }
    }
}
