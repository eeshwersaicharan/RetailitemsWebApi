using System;
using System.Collections.Generic;
using ItemWebApi.Itemclass;

namespace ItemWebApi.Operations
{
    public interface IitemServices
    {
        IEnumerable<Items> GetAllItems();
        IEnumerable<Items> GetItemById(int _id);
        IEnumerable<Items> GetItemByCategory(string _category);

        bool InsertItem(Items _Item);
        bool DeleteItem(int _Id);
        bool UpdateItemPriceById(int _Id,int _changeinprice);
    }
}
