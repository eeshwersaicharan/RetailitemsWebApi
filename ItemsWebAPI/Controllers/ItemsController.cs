
//This is the ItemsController Which Manages All Operations Of Items by Interacting with ItemService Class

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

        //Constructor for ItemController 
        public ItemsController(IitemServices _iitemServices)
        {
            _itemoperations = _iitemServices;
        }

        //This method returns all Items by interacting with Database through Method in ItemService class
        [HttpGet,Route("api/Items/GetItems")]
        public IEnumerable<Items> GetItems()
        {
            return _itemoperations.GetAllItems();
        }

        //This method used to Insert Item into Database through Method in ItemService class
        [HttpPost, Route("api/Items/insertitem")]
        public string insertitem(Items _item)
        {
            if (_itemoperations.InsertItem(_item))
            {
                return "ItemInserted";
            }

            return "ItemNotInserted Give Valid ItemData";
        }

        //This method used to Update the Price of item by using ItemId through Method in ItemService class
        [HttpPatch,Route("api/Items/updateitempricebyid/{id}/{changeprice}")]
        public string updateitempricebyid(int id,int changeprice)
        {
            if (_itemoperations.UpdateItemPriceById(id, changeprice))
            {
                return "Price Succesfully Updated ";
            }
            return "Price Not Updated";
        }

        //This Method Used To Delete Any Item In Items List By using its Id through Method in ItemService class
        [HttpDelete,Route("api/Items/Deleteitem")]
        public string Deleteitem(int id)
        {
            if (_itemoperations.DeleteItem(id))
            {
                return "Item Deleted Successfully";
            }
            return "Item Not Deleted";
        }

        //This Method Used to get Any Item By using its Id through Method in ItemService class
        [HttpGet, Route("api/Items/getitembyid/")]
        public IEnumerable<Items> getitembyid(int id)
        {
            IEnumerable<Items> itemslist = _itemoperations.GetAllItems();
            if(itemslist.Any(i=>i.Id==id))
            {
                return _itemoperations.GetItemById(id);
            }
            return Enumerable.Empty<Items>();
        }
        //This Method Used to get All Items Belongs To Same Category By using its Id through Method in ItemService class
        [HttpGet, Route("api/Items/getitembycategory/")]
        public IEnumerable<Items> getitembycategory(string category)
        {
            IEnumerable<Items> itemslist = _itemoperations.GetAllItems();
            if (itemslist.Any(i => i.Category == category))
            {
                return _itemoperations.GetItemByCategory(category);
            }
            return Enumerable.Empty<Items>();
        }
        //This method used to Update the Price of items Belongs to Same Category by using CategoryName through Method in ItemService class
        [HttpPatch,Route("api/Items/updateitempricebycategory")]
        public string updateitempricebycategory(string category,int changeinprice)
        {
            if (_itemoperations.UpdateItemPriceByCategory(category, changeinprice))
            {
                return "Price Updated Succesfully";
            }
            return "Price Not Updated";
        }

        //This method used to Update the Quantity of item by using ItemId through Method in ItemService class
        [HttpPut,Route("api/Items/UpdateItemQuantity")]
        public string UpdateItemQuantity(int id,int quantitychange)
        {
            if (_itemoperations.UpdateItemQuantity(id, quantitychange))
            {
                return "Quantity Updated";
            }
            return "Quantity not Updated";
        }
    }
}
