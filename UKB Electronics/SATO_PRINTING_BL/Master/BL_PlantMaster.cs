using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATO_PRINTING_DL;
using SATO_PRINTING_PL;

namespace SATO_PRINTING_BL
{
   public class BL_PlantMaster
    {
        public DataTable BL_ExecuteTask(PL_PlantMaster objPl)
        {
            DL_PlantMaster objDl = new DL_PlantMaster();
            return objDl.DL_ExecuteTask(objPl);
        }
    }
}
