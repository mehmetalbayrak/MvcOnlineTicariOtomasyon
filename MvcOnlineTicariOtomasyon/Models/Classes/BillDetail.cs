using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillDetail
    {
        [Key]
        public int BillDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string BillContext { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }
    }
}