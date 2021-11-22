using System;

namespace ItemWebApi.Itemclass
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string emailId { get; set; }
        public double Mobileno { get; set; }
        public string Password { get; set; }
    }
}
