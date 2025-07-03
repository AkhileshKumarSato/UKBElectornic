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
   public class BL_ProductLineMapping
    {
        public DataTable BL_ExecuteTask(PL_ProductLineMapping objPl)
        {
            DL_ProductLineMapping objDl = new DL_ProductLineMapping();
            return objDl.DL_ExecuteTask(objPl);
        }

    }
}
