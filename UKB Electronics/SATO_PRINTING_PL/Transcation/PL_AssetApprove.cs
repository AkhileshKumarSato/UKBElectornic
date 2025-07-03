using SATO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO_PRINTING_PL
{
    public class PL_AssetApprove:Common
    {
        public string DocNo { get; set; }
        public string Plant { get; set; }
        public string AssetCode { get; set; }
        public decimal Qty { get; set; }
        public string MovementType { get; set; }



    }
}
