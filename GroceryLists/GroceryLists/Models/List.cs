using System;
using System.Collections.ObjectModel;

namespace GroceryLists.Models
{
    public class List
    {
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public ObservableCollection<ListItem> Items { get; set; } = new ObservableCollection<ListItem>(); 
    }
}
