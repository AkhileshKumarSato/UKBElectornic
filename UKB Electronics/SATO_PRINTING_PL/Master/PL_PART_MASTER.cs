using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATO_PRINTING_COMMON;


namespace SATO_PRINTING_PL
{
    public class PL_PART_MASTER : Common
    {
        public string PlantCode { get; set; }
        public string Floor { get; set; }
        public string Section { get; set; }
        public string AssetCode { get; set; }
        public string RFIDTag { get; set; }
        public string Desc { get; set; }
        public string BrandType { get; set; }
        public string ID { get; set; }


    }
}
