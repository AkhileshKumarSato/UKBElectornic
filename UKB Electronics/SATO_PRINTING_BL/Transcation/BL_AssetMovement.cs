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
    public class BL_AssetMovement
    {
        public DataTable BL_ExecuteTask(PL_AssetMovement objPl)
        {
            DL_AssetMovement objDl = new DL_AssetMovement();
            return objDl.DL_ExecuteTask(objPl);
        }
        public DataTable BL_GetDocNo(PL_AssetMovement objPl)
        {
            DL_AssetMovement objDl = new DL_AssetMovement();
            return objDl.DL_GetDocNo(objPl);
        }
    }
}
