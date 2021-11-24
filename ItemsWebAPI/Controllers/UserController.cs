
//This is the UserController Which Manages All Operations Of Users by Interacting with UserService Class

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
        //Constructor for UserController 
        public UserController(Iuserservice _userservice)
        {
            _uservalidation = _userservice;
        }
        //This method returns all Users by interacting with Database through Method in UserService class
        [HttpGet, Route("api/User/GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _uservalidation.GetAllUsers();
        }

        //This method returns all Password Of Respective User By using user's EmailId through Method in UserService class
        [HttpGet,Route("api/User/GetPassword")]
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


        //This Method Inserts New User Into users DataBase By using Method in UserService
        [HttpPost, Route("api/User/RegisterNewuser")]
     
        public IEnumerable<User> RegisterNewuser(User _newuser)
        {
            if (_uservalidation.RegisterNewUser(_newuser))
            {
                return _uservalidation.GetAllUsers();
            }
            return Enumerable.Empty<User>();
        }
        //This Method Validates User And Returns true for Successful validation
        [HttpGet, Route("api/User/LoginUser")]
        public bool LoginUser(string _emailid,string _password)
        {
            if ((_uservalidation.LoginToNextPage(_emailid, _password)))
            {
                return true;
            }
            return false;
        }
        [HttpPatch,Route("api/User/resetpassword")]
        public string resetpassword(string emailId,string oldpassword,string newpassword)
        {
            if (_uservalidation.ResetPassword(emailId, oldpassword, newpassword))
            {
                return "Password Updated Successfully";
            }
            return "Password not Updated";
        }
    }
}
