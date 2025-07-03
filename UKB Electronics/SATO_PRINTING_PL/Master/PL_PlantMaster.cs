using SATO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO_PRINTING_PL
{
   public class PL_PlantMaster : Common
    {
        public string PlantCode { get; set; }
        public string Floor { get; set; }
        public string Section { get; set; }
        public string Location { get; set; }
        public string Dept { get; set; }
        public string Desc { get; set; }
        public string ID { get; set; }
    }
}
