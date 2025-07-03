using SatoLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATO_PRINTING_PL;
using SATO_PRINTING_COMMON;

namespace SATO_PRINTING_DL
{
   public class DL_PlantMaster
    {
        SqlHelper _SqlHelper = new SqlHelper();
        SqlTransaction _SqlTransaction = null;
        SqlConnection _SqlConnection = null;
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_PlantMaster obj)
        {
            _SqlHelper = new SqlHelper();
            _SqlConnection = new SqlConnection(GlobalVariable.mMainSqlConString);
            _SqlConnection.Open();
            _SqlTransaction = _SqlConnection.BeginTransaction();

            try
            {
                SqlParameter[] param = new SqlParameter[9];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PlantCode", SqlDbType.VarChar, 50);
                param[1].Value = obj.PlantCode;
                param[2] = new SqlParameter("@Floor", SqlDbType.VarChar, 50);
                param[2].Value = obj.Floor;
                param[3] = new SqlParameter("@Section", SqlDbType.VarChar, 50);
                param[3].Value = obj.Section;
                param[4] = new SqlParameter("@LocationCode", SqlDbType.VarChar, 50);
                param[4].Value = obj.Location;
                param[5] = new SqlParameter("@DptCode", SqlDbType.VarChar, 50);
                param[5].Value = obj.Dept;
                param[6] = new SqlParameter("@Description", SqlDbType.VarChar, 50);
                param[6].Value = obj.Desc;
                param[7] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[7].Value = obj.CreatedBy;
                param[8] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
                param[8].Value = obj.ID;
                DataTable dataTable = _SqlHelper.ExecuteDataset(_SqlTransaction, "[PRC_PlantMaster]", param).Tables[0];
                _SqlTransaction.Commit();
                _SqlTransaction = null;
                _SqlConnection.Close();
                _SqlConnection.Dispose();
                _SqlConnection = null;
                return dataTable;
            }
            catch (Exception ex)
            {
                if (_SqlTransaction != null)
                {
                    _SqlTransaction.Rollback();
                    _SqlTransaction = null;
                }
                throw ex;
            }
        }
        #endregion
    }
}
