using SATO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO_PRINTING_PL
{
   public class PL_MRPQRScanning : Common
    {
        public string Line_No { get; set; }
        public string SetDefaultProduct { get; set; }
        public string ProductQRCode { get; set; }
        public string EAN_No { get; set; }
        public string PackSize { get; set; }
        public string ProductCode { get; set; }
    }
}
