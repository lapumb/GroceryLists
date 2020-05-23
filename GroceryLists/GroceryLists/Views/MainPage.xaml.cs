using Xamarin.Forms;
using GroceryLists.Models;
using GroceryLists.Views; 
using System.Diagnostics;

namespace GroceryLists
{
    public partial class MainPage : ContentPage
    {
        private readonly string TAG = "MainPage";

        public MainPage()
        {
            InitializeComponent();

            // bind list source
            mainPageList.ItemsSource = GroceryListsMaster.Lists; 
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var answer = await DisplayAlert("Are you sure?", null, "Yes", "No");
            if (answer)
            {
                GroceryListsMaster.Lists.Remove((List)menuItem.CommandParameter);
            }
        }

        async void mainPageList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            List list = mainPageList.SelectedItem as List;
            Debug.WriteLine($"{TAG}: Item selected: {list.Name}");

            if (GroceryListsMaster.ListIsValid(list))
            {
                ListPage listPage = new ListPage(list);
                await App.Current.MainPage.Navigation.PushAsync(listPage); 
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.MainPg = this;
        }
    }
}
