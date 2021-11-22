using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsWebApi.UserValidation;
using ItemWebApi.CommonConnection;
using ItemWebApi.Itemclass;

namespace ItemsWebAPI.Controllers
{
    //  [Route("api/[controller]")]
     // [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuserservice _uservalidation;

        public UserController(Iuserservice _userservice)
        {
            _uservalidation = _userservice;
        }

        [HttpGet, Route("api/User/GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _uservalidation.GetAllUsers();
        }

        [HttpGet,Route("api/User/GetPassword/{emailId}")]
        public Object GetPassword(Object _emailId)
        {
            IEnumerable<User> _userlist = new List<User>();
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
            _userlist = _uservalidation.GetAllUsers().Where(u => u.emailId == _emailId);
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            if (_userlist.Any() == true)
            {
                return _userlist.FirstOrDefault();
            }

            return Enumerable.Empty<User>();
        }

       // [HttpGet, Route("api/User/RegisterNewuser")]
        [HttpPost, ActionName("api/User/RegisterNewuser")]
        public IEnumerable<User> RegisterNewuser(User _newuser)
        {
            if (_uservalidation.RegisterNewUser(_newuser))
            {
                return _uservalidation.GetAllUsers();
            }
            return Enumerable.Empty<User>();
        }
    }
}
