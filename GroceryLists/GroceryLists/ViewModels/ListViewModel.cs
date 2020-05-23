using System.ComponentModel;
using GroceryLists.Models; 
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;
using Acr.UserDialogs;

namespace GroceryLists.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        private readonly string TAG = "ListViewModel";

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

        private string _listName = "";
        public string ListName
        {
            get { return _listName; }
            set
            {
                _listName = value;
                OnPropertyChanged(nameof(ListName));
            }
        }

        private ObservableCollection<ListItem> _itemsList = null; 
        public ObservableCollection<ListItem> ItemList
        {
            get { return _itemsList; }
            set
            {
                _itemsList = value;
                OnPropertyChanged(nameof(ItemList));
            }
        }

        public ListViewModel()
        {
            App.ListVM = this;
        }

        public ICommand AddItem => new Command(async () =>
        {
            string result = await App.ListPg.DisplayPromptAsync("Add Item", "Item Name", "Add");
            if (!string.IsNullOrEmpty(result))
            {
                GroceryListsMaster.AddToItems(GroceryListsMaster.GetList(ListName), new ListItem
                {
                    Name = result,
                    CreatedBy = Utilities.Utilities.GetDeviceName(), 
                    Timestamp = DateTime.Now
                });
            }
        });

        public ICommand DeleteItem => new Command(() =>
        {
            // TODO
        });

        public ICommand EditItem => new Command(() =>
        {
            // TODO
        });

        public ICommand Refresh => new Command(() =>
        {
            // Refresh the list
            UserDialogs.Instance.ShowLoading();
            IsRefreshing = true;
            GroceryListsMaster.RefreshItems(ListName);
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