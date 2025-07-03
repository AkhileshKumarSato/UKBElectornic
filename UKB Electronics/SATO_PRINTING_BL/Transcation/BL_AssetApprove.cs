using SATO_PRINTING_DL;
using SATO_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO_PRINTING_BL
{
    public class BL_AssetApprove
    {
        public DataTable BL_ExecuteTask(PL_AssetApprove objPl)
        {
            DL_AssetApprove objDl = new DL_AssetApprove();
            return objDl.DL_ExecuteTask(objPl);
        }
    }
}
