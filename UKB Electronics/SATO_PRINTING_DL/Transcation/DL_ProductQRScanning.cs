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
  public class DL_ProductQRScanning
    {
        SqlHelper _SqlHelper = new SqlHelper();
        SqlTransaction _SqlTransaction = null;
        SqlConnection _SqlConnection = null;
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_ProductQRScanning obj)
        {
            _SqlHelper = new SqlHelper();
            _SqlConnection = new SqlConnection(GlobalVariable.mMainSqlConString);
            _SqlConnection.Open();
            _SqlTransaction = _SqlConnection.BeginTransaction();

            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@Line_No", SqlDbType.VarChar, 50);
                param[1].Value = obj.Line_No;
                param[2] = new SqlParameter("@SetDefaultProduct", SqlDbType.VarChar, 50);
                param[2].Value = obj.SetDefaultProduct;
                param[3] = new SqlParameter("@ProductQRCode", SqlDbType.VarChar, 50);
                param[3].Value = obj.ProductQRCode;
                param[4] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[4].Value = obj.CreatedBy;
                DataTable dataTable = _SqlHelper.ExecuteDataset(_SqlTransaction, "[PRC_ProductQRScanning]", param).Tables[0];
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
