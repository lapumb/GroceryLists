using System;
using Xamarin.Forms;
using GroceryLists.ViewModels;
using GroceryLists.Views; 

namespace GroceryLists
{
    public partial class App : Application
    {
        public static MainPage MainPg { get; set; } = null;
        public static MainViewModel MainVM { get; set; } = null;
        public static ListPage ListPg { get; set; } = null;
        public static ListViewModel ListVM { get; set; } = null;

        public App()
        {
            InitializeComponent();
            MainPage =  new NavigationPage(new MainPage()); ;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
