using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using Acr.UserDialogs;

namespace GroceryLists.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly string TAG = "MainViewModel";

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public MainViewModel()
        {
            App.MainVM = this;
        }

        public ICommand AddList => new Command(async () =>
        {
            string result = await App.MainPg.DisplayPromptAsync("Create New List", "List Name", "Add"); 
            if (!string.IsNullOrEmpty(result))
            {
                GroceryListsMaster.AddToLists(new Models.List
                {
                    Name = result,
                    Timestamp = DateTime.Now
                });
            }
        });

        public ICommand DeleteList => new Command(() =>
        {
            // TODO
        });

        public ICommand EditList => new Command(() =>
        {
            // TODO
        });

        public ICommand Refresh => new Command(() =>
        {
            // Refresh the list
            UserDialogs.Instance.ShowLoading();
            IsRefreshing = true; 
            GroceryListsMaster.RefreshLists();
            IsRefreshing = false;
            UserDialogs.Instance.HideLoading();

        });

        /*changed event notifiers */
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
