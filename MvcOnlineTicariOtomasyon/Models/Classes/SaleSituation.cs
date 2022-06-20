using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SaleSituation
    {
        [Key]
        public int SaleId { get; set; }
        //product
        //current
        //personel
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int PersonelId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Personel Personel { get; set; }
    }
}