﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DepartmanName { get; set; }
        public bool Status { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}