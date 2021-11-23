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
    }
}
