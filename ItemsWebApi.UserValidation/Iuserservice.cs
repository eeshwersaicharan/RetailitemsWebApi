using System;
using ItemWebApi.Itemclass;
using System.Collections.Generic;

namespace ItemsWebApi.UserValidation
{
    public interface Iuserservice
    {
        IEnumerable<User> GetAllUsers();
        Object GetUserPasswordByUserName(object emailId);
        bool LoginToNextPage(string username, string password);
        bool RegisterNewUser(User user);

    }
}
