using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleApp.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }


        public Users() { }

        public Users(int Id, string Username, string Name, string Surname1, string Surname2, string Phone, string Address, bool Active)
        {
            this.Id = Id;
            this.Username = Username;
            this.Name = Name;
            this.Surname1 = Surname1;
            this.Surname2 = Surname2;
            this.Phone = Phone;
            this.Address = Address;
            this.Active = Active;
        }

        public Users(string Username, string Name, string Surname1, string Surname2, string Phone, string Address, bool Active)
        {
            this.Username = Username;
            this.Name = Name;
            this.Surname1 = Surname1;
            this.Surname2 = Surname2;
            this.Phone = Phone;
            this.Address = Address;
            this.Active = Active;
        }
    }
}