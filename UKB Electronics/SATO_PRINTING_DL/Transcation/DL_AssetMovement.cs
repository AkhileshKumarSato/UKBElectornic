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
    public class DL_AssetMovement
    {
        SqlHelper _SqlHelper = new SqlHelper();
        SqlTransaction _SqlTransaction = null;
        SqlConnection _SqlConnection = null;
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_AssetMovement obj)
        {
            _SqlHelper = new SqlHelper();
            _SqlConnection = new SqlConnection(GlobalVariable.mMainSqlConString);
            _SqlConnection.Open();
            _SqlTransaction = _SqlConnection.BeginTransaction();

            try
            {
                SqlParameter[] param = new SqlParameter[12];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@DocNo", SqlDbType.VarChar, 50);
                param[1].Value = obj.DocNo;
                param[2] = new SqlParameter("@FromPlant", SqlDbType.VarChar, 50);
                param[2].Value = obj.FromPlant;
                param[3] = new SqlParameter("@FromFloor", SqlDbType.VarChar, 50);
                param[3].Value = obj.FromFloor;
                param[4] = new SqlParameter("@FromSection", SqlDbType.VarChar, 50);
                param[4].Value = obj.FromSection;
                param[5] = new SqlParameter("@ToPlant", SqlDbType.VarChar, 50);
                param[5].Value = obj.ToPlant;
                param[6] = new SqlParameter("@ToFloor", SqlDbType.VarChar, 50);
                param[6].Value = obj.ToFloor;
                param[7] = new SqlParameter("@ToSection", SqlDbType.VarChar, 50);
                param[7].Value = obj.ToSection;
                param[8] = new SqlParameter("@AssetCode", SqlDbType.VarChar, 50);
                param[8].Value = obj.AssetCode;
                param[9] = new SqlParameter("@Qty", SqlDbType.Decimal);
                param[9].Value = obj.Qty;
                param[10] = new SqlParameter("@Description", SqlDbType.VarChar, 50);
                param[10].Value = obj.Description;
                param[11] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[11].Value = obj.CreatedBy;
                DataTable dataTable = _SqlHelper.ExecuteDataset(_SqlTransaction, "[PRC_AssetMovement]", param).Tables[0];
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

        public DataTable DL_GetDocNo(PL_AssetMovement obj)
        {
            _SqlHelper = new SqlHelper();
            _SqlConnection = new SqlConnection(GlobalVariable.mMainSqlConString);
            _SqlConnection.Open();
            _SqlTransaction = _SqlConnection.BeginTransaction();

            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                DataTable dataTable = _SqlHelper.ExecuteDataset(_SqlTransaction, "[PRC_GetRunningSerial]", param).Tables[0];
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