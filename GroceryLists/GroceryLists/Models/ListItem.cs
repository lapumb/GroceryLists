using System;

namespace GroceryLists.Models
{
    public class ListItem
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
