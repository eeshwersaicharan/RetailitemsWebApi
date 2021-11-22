using System;
using ItemWebApi.Itemclass;
using System.Collections.Generic;

namespace ItemsWebApi.UserValidation
{
    public interface Iuserservice
    {
        IEnumerable<User> GetAllUsers();
        string GetUserPasswordByUserName(string emailId);
        bool LoginToNextPage(string emailId, string password);
        bool RegisterNewUser(User user);

    }
}
