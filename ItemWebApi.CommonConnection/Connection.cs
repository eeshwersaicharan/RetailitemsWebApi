
//This class used to assign ConnectionString to one Variable and use it globally across project
using System;

namespace ItemWebApi.CommonConnection
{
    public class ConnectionClass
    {
        public static string _ConnectionString = @"server=IM-RT-LP-678\SQLEXPRESS;database=AspireTest;integrated security=True";
    }
}
