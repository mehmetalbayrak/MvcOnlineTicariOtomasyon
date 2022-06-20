using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(20)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Context { get; set; }
        public DateTime Date { get; set; }
    }
}