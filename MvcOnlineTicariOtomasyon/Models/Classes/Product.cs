using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Marka")]
        public string Brand { get; set; }

        [Display(Name = "Stok Adeti")]
        public short Stock { get; set; }

        [Display(Name = "Alış Fiyatı")]
        public decimal BuyPrice { get; set; }

        [Display(Name = "Satış Fiyatı")]
        public decimal SellPrice { get; set; }

        [Display(Name = "Durum")]
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Görsel")]
        public string ProductImage { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SaleSituation> SaleSituations { get; set; }
    }
}