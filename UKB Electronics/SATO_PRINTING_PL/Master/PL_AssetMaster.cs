using SATO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO_PRINTING_PL
{
    public class PL_AssetMaster : Common
    {
        public string PlantCode { get; set; }
        public string Floor { get; set; }
        public string Section { get; set; }
        public string AssetCode { get; set; }
        public string Description { get; set; }
        public string RFID_Tag { get; set; }
        public string Brand { get; set; }
        public string ID { get; set; }
    }
}
