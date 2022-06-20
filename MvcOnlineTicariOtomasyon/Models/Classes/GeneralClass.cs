using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class GeneralClass
    {
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Detail> details { get; set; }
    }
}