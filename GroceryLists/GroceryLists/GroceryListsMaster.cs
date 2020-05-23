using System.Collections.ObjectModel;
using System.Diagnostics;
using GroceryLists.Models; 

namespace GroceryLists
{
    class GroceryListsMaster
    {
        private static string TAG = "GroceryListMaster";

        public static ObservableCollection<List> Lists { get; set; } = new ObservableCollection<List>();

        public static bool ListIsValid(List list)
        {
            // note: list.Items can be empty
            if (null == list)
            {
                Debug.WriteLine($"{TAG}: list is null. returning.");
                return false;
            } else if (string.IsNullOrEmpty(list.Name) || string.IsNullOrEmpty(list.Timestamp.ToString()))
            {
                Debug.WriteLine($"{TAG}: list property invalid.");
                return false; 
            }

            return true; 
        }

        public static void AddToLists(List list)
        {
            if (!ListIsValid(list))
            {
                Debug.WriteLine($"{TAG}: list is not valid."); 
                return; 
            }

            // TODO: send to firebase and on success, add to list. On failure, print message
            Lists.Add(list); 
        }

        public static void RemoveFromLists(List list)
        {
            if (!ListIsValid(list))
            {
                Debug.WriteLine($"{TAG}: list is not valid.");
                return; 
            }

            // TODO: send to firebase and on success, add to list. On failure, print message
            Lists.Remove(list); 
        }

        public static void RefreshLists()
        {
            // TODO: get most current lists from firebase
        }

        public static List GetList(string name)
        {
            foreach (List list in Lists) {
                if (name.Equals(list.Name))
                {
                    return list; 
                }
            }

            // didn't find anything
            return null; 
        }

        public static bool ItemIsValid(ListItem item)
        {
            if (null == item)
            {
                Debug.WriteLine($"{TAG}: item is null. returning.");
                return false;
            } else if (string.IsNullOrEmpty(item.Name) || 
                string.IsNullOrEmpty(item.Timestamp.ToString()) || 
                string.IsNullOrEmpty(item.CreatedBy))
            {
                Debug.WriteLine($"{TAG}: item property invalid.");
                return false; 
            }

            return true; 
        }

        public static void AddToItems(List list, ListItem item)
        {
            if (!ItemIsValid(item) || !ListIsValid(list))
            {
                Debug.WriteLine($"{TAG}: list or item is invalid.");
                return;
            }

            // TODO: send to firebase and on success, add to list. On failure, print message
            list.Items.Add(item);
        }

        public static void RemoveFromItems(List list, ListItem item)
        {
            if (!ItemIsValid(item) || !ListIsValid(list))
            {
                Debug.WriteLine($"{TAG}: list or item is invalid.");
                return;
            }

            // TODO: send to firebase and on success, add to list. On failure, print message
            list.Items.Remove(item);
        }

        public static void RefreshItems(string listName)
        {
            // TODO: get most current items from firebase
        }

        public static ListItem GetItem(List list, string name)
        {
            foreach (ListItem item in list.Items)
            {
                if (name.Equals(item.Name))
                {
                    return item;
                }
            }

            // didn't find anything
            return null;
        }
    }
}
