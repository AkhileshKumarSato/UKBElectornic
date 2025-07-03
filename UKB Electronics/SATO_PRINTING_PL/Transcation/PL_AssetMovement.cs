using SATO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SATO_PRINTING_PL
{
    public class PL_AssetMovement:Common
    {
        public string DocNo { get; set; }
        public string FromPlant { get; set; }
        public string FromFloor { get; set; }
        public string FromSection { get; set; }
        public string ToPlant { get; set; }
        public string ToFloor { get; set; }
        public string ToSection { get; set; }
        public string AssetCode { get; set; }
        public decimal Qty { get; set; }
        public string Description { get; set; }
    }
}
