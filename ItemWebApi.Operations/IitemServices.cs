using System;
using System.Collections.Generic;
using ItemWebApi.Itemclass;

namespace ItemWebApi.Operations
{
    public interface IitemServices
    {
        IEnumerable<Items> GetAllItems();
        Items GetItemById();
        IEnumerable<Items> GetItemByCategory();

        bool InsertItem(Items _Item);
        bool DeleteItem(int _Id);
        bool UpdateItemPrice(int _Id);
    }
}
