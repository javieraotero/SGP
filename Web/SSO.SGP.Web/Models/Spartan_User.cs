using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.SGP.Web.Models
{
    public class Spartan_User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public int Image { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
    
    }

    public class Spartan_User_Role
    {
        public int User_RoleId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class Spartan_File
    {
        public int FileId { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public int FileSize { get; set; }
        public int Object { get; set; }
        public int User { get; set; }
        public DateTime Datetime { get; set; } 
    }

    public class Spartan_User_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Spartan_User_Role_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Spartan_Object
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Image { get; set; }
        public string URL { get; set; }
    }

    public class Spartan_Object_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

}