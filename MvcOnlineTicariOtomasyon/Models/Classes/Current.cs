using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CurrentSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CurrentProvince { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(64)]
        public string CurrentPassword { get; set; }
        public bool Status { get; set; }
        public ICollection<SaleSituation> SaleSituations { get; set; }
    }
}