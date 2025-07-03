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
    public class DL_AssetMaster
    {
        SqlHelper _SqlHelper = new SqlHelper();
        SqlTransaction _SqlTransaction = null;
        SqlConnection _SqlConnection = null;
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_AssetMaster obj)
        {
            _SqlHelper = new SqlHelper();
            _SqlConnection = new SqlConnection(GlobalVariable.mMainSqlConString);
            _SqlConnection.Open();
            _SqlTransaction = _SqlConnection.BeginTransaction();

            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@PlantCode", SqlDbType.VarChar, 50);
                param[1].Value = obj.PlantCode;
                param[2] = new SqlParameter("@Floor", SqlDbType.VarChar, 50);
                param[2].Value = obj.Floor;
                param[3] = new SqlParameter("@Section", SqlDbType.VarChar, 50);
                param[3].Value = obj.Section;
                param[4] = new SqlParameter("@AssetCode", SqlDbType.VarChar, 50);
                param[4].Value = obj.AssetCode;
                param[5] = new SqlParameter("@Description", SqlDbType.VarChar, 50);
                param[5].Value = obj.Description;
                param[6] = new SqlParameter("@RFID_Tag", SqlDbType.VarChar, 50);
                param[6].Value = obj.RFID_Tag;
                param[7] = new SqlParameter("@Brand", SqlDbType.VarChar, 50);
                param[7].Value = obj.Brand;
                param[8] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[8].Value = obj.CreatedBy;
                param[9] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
                param[9].Value = obj.ID;
                DataTable dataTable = _SqlHelper.ExecuteDataset(_SqlTransaction, "[PRC_AssetMaster]", param).Tables[0];
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
