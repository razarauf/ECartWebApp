using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECartWebApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [MaxLength(50)]
        public string ItemCode { get; set; }

        [MaxLength(250)]
        public string ItemName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string ImageURL { get; set; }

        public decimal ItemPrice { get; set; }
    }
}