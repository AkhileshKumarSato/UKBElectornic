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
   public class BL_ProductQRScanning
    {
        public DataTable BL_ExecuteTask(PL_ProductQRScanning objPl)
        {
            DL_ProductQRScanning objDl = new DL_ProductQRScanning();
            return objDl.DL_ExecuteTask(objPl);
        }
    }
}
