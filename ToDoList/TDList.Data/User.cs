using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDList.Data
{
   public class User //: IdentityUser
    {
        public User()
        {
            ToDoLists = new List<ToDoList>();
        }
        public int Id { get; set; } 
        public string Login { get; set; }
        public string PasswordHash{ get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }

        public virtual List<ToDoList> ToDoLists { get; set; }
    }
}
    