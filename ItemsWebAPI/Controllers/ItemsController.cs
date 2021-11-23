using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemWebApi.CommonConnection;
using ItemWebApi.Itemclass;
using ItemWebApi.Operations;

namespace ItemsWebAPI.Controllers
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IitemServices _itemoperations;

        public ItemsController(IitemServices _iitemServices)
        {
            _itemoperations = _iitemServices;
        }
        [HttpGet,Route("api/Items/GetItems")]
        public IEnumerable<Items> GetItems()
        {
            return _itemoperations.GetAllItems();
        }
        [HttpPost, Route("api/Items/insertitem/{Id}/{Name}/{Price}/{Quantity}/{Category}")]
        public string insertitem(Items _item)
        {
            if (_itemoperations.InsertItem(_item))
            {
                return "ItemInserted";
            }

            return "ItemNotInserted Give Valid ItemData";
        }

        [HttpGet,Route("api/Items/updateitempricebyid/{id}/{changeprice}")]
        public string updateitempricebyid(int id,int changeprice)
        {
            if (_itemoperations.UpdateItemPriceById(id, changeprice))
            {
                return "Price Succesfully Updated ";
            }
            return "Price Not Updated";
        }
        [HttpGet,Route("api/Items/Deleteitem/{id}")]
        public string Deleteitem(int id)
        {
            if (_itemoperations.DeleteItem(id))
            {
                return "Item Deleted Successfully";
            }
            return "Item Not Deleted";
        }
        [HttpGet, Route("api/Items/getitembyid/{id}")]
        public IEnumerable<Items> getitembyid(int id)
        {
            IEnumerable<Items> itemslist = _itemoperations.GetAllItems();
            if(itemslist.Any(i=>i.Id==id))
            {
                return _itemoperations.GetItemById(id);
            }
            return Enumerable.Empty<Items>();
        }
        [HttpGet, Route("api/Items/getitembycategory/{category}")]
        public IEnumerable<Items> getitembycategory(string category)
        {
            IEnumerable<Items> itemslist = _itemoperations.GetAllItems();
            if (itemslist.Any(i => i.Category == category))
            {
                return _itemoperations.GetItemByCategory(category);
            }
            return Enumerable.Empty<Items>();
        }
        [HttpGet,Route("api/Items/updateitempricebycategory/{category}/{changeinprice}")]
        public string updateitempricebycategory(string category,int changeinprice)
        {
            if (_itemoperations.UpdateItemPriceByCategory(category, changeinprice))
            {
                return "Price Updated Succesfully";
            }
            return "Price Not Updated";
        }
    }
}
