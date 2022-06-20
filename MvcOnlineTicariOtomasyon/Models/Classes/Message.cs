using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Receiver { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Header { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(2000)]
        public string Context { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Date { get; set; }
    }
}