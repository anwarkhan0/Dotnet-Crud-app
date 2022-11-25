using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace crudapp.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("UsersContext")
        {
        }

        public DbSet<Users> User { get; set; }

        
    }
}