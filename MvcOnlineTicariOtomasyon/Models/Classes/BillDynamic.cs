using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillDynamic
    {
        public IEnumerable<Bill> Bills { get; set; }
        public IEnumerable<BillDetail> BillDetails { get; set; }
    }
}