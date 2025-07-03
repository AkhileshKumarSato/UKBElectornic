using SATO_PRINTING_DL;
using SATO_PRINTING_PL;
using System.Data;

namespace SATO_PRINTING_BL
{
    public class BL_REPORT
    {
        public DataTable BL_ExecuteTask(PL_REPORT objPl)
        {
            DL_REPORT objDl = new DL_REPORT();
            return objDl.DL_ExecuteTask(objPl);
        }
    }
}
