using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expense
    {
        [Key]
        public int ExpenceId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Context { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Price { get; set; }
    }
}