using SATO_PRINTING_COMMON;
using SATO_PRINTING_PL;
using SatoLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SATO_PRINTING_DL
{
   public class DL_PartiallyComplete
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_PartiallyComplete obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@ProductCode", SqlDbType.VarChar, 50);
                param[1].Value = obj.ProductCode;
                param[2] = new SqlParameter("@Line_No", SqlDbType.VarChar, 50);
                param[2].Value = obj.Line_No;
                param[3] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[3].Value = obj.CreatedBy;
                param[4] = new SqlParameter("@RPT_Type", SqlDbType.VarChar, 50);
                param[4].Value = obj.RPT_Type;


                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_PartialComplete_MRP_AND_Carton]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion   
    }
}
