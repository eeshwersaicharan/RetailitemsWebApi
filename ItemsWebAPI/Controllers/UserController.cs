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

        [HttpGet,Route("api/User/GetPassword/{_emailId}")]
        public string GetPassword(string _emailId)
        {
            IEnumerable<User> _userlist = _uservalidation.GetAllUsers();
           
            if(_userlist.Any(u => u.emailId == _emailId))
            {
                return _uservalidation.GetUserPasswordByUserName(_emailId);
            }      
            else
            {
                return "InvalidEmail";
            }
        }

        [HttpGet, Route("api/User/RegisterNewuser/{FirstName}/{LastName}/{emailId}/{Mobileno}/{Password}")]
      //  [HttpPost, ActionName("api/User/RegisterNewuser")]
        public IEnumerable<User> RegisterNewuser(User _newuser)
        {
            if (_uservalidation.RegisterNewUser(_newuser))
            {
                return _uservalidation.GetAllUsers();
            }
            return Enumerable.Empty<User>();
        }

        [HttpGet, Route("api/User/LoginUser/{_emailid}/{_password}")]
        public bool LoginUser(string _emailid,string _password)
        {
            if ((_uservalidation.LoginToNextPage(_emailid, _password)))
            {
                return true;
            }
            return false;
        }
    }
}
