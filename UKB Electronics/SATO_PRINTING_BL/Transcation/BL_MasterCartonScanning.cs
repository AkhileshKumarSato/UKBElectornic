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
   public class BL_MasterCartonScanning
    {
        public DataTable BL_ExecuteTaskMrp(PL_MasterCartonScanning objPl)
        {
            DL_MasterCartonScanning objDl = new DL_MasterCartonScanning();
            return objDl.DL_ExecuteTaskMrp(objPl);
        }

        public DataTable BL_ExecuteTaskCarton(PL_MasterCartonScanning objPl)
        {
            DL_MasterCartonScanning objDl = new DL_MasterCartonScanning();
            return objDl.DL_ExecuteTaskCarton(objPl);
        }
    }
}
