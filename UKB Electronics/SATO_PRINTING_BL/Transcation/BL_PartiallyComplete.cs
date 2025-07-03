using SATO_PRINTING_DL;
using SATO_PRINTING_PL;
using System.Data;

namespace SATO_PRINTING_BL
{
   public class BL_PartiallyComplete
    {
        public DataTable BL_ExecuteTask(PL_PartiallyComplete objPl)
        {
            DL_PartiallyComplete objDl = new DL_PartiallyComplete();
            return objDl.DL_ExecuteTask(objPl);
        }
    }
}
