﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace crudapp.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String email { get; set; }
        public String gender { get; set; }
        public String ip_address { get; set; }
    }



    
}