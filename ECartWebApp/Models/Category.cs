using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECartWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [MaxLength(150)]
        public string CategoryCode { get; set; }

        [MaxLength(150)]
        public string CategoryName { get; set; }
    }
}