using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillQueueNo { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Tax { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Time { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivery { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}