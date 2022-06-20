using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name ="Personel Adı")]
        public string PersonelName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Personel Soyadı")]
        public string PersonelSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Görsel")]
        public string PersonelImage { get; set; }
        public ICollection<SaleSituation> SaleSituations { get; set; }
        public int DepartmanId { get; set; }
        [Display(Name = "Departman")]
        public virtual Departman Departmen { get; set; }
    }

}
