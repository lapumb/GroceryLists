using Xamarin.Forms;
using GroceryLists.Models;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace GroceryLists.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private readonly string TAG = "ListPage";

        public ListPage(List list)
        {
            InitializeComponent();

            // bind to list items
            listPageList.ItemsSource = list.Items;

            // set VM properties
            App.ListVM.ListName = list.Name;
            App.ListVM.ItemList = list.Items; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.ListPg = this;
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var answer = await DisplayAlert("Are you sure?", null, "Yes", "No");
            if (answer)
            {
                GroceryListsMaster.GetList(App.ListVM.ListName).Items.Remove((ListItem)menuItem.CommandParameter); 
            }
        }
    }
}