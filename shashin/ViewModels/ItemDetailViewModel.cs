using System;

using shashin.Models;

namespace shashin.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Item = item;
        }
    }
}
