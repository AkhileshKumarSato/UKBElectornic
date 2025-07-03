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
    public class DL_AssetApprove
    {
        SqlHelper _SqlHelper = new SqlHelper();
        SqlTransaction _SqlTransaction = null;
        SqlConnection _SqlConnection = null;

        public DataTable DL_ExecuteTask(PL_AssetApprove obj)
        {
            _SqlHelper = new SqlHelper();
            _SqlConnection = new SqlConnection(GlobalVariable.mMainSqlConString);
            _SqlConnection.Open();
            _SqlTransaction = _SqlConnection.BeginTransaction();

            try
            {
                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@DocNo", SqlDbType.VarChar, 50);
                param[1].Value = obj.DocNo;
                param[2] = new SqlParameter("@Plant", SqlDbType.VarChar, 50);
                param[2].Value = obj.Plant;
                param[3] = new SqlParameter("@AssetCode", SqlDbType.VarChar, 50);
                param[3].Value = obj.AssetCode;
                param[4] = new SqlParameter("@Qty", SqlDbType.Decimal);
                param[4].Value = obj.Qty;
                param[5] = new SqlParameter("@MovementType", SqlDbType.VarChar, 50);
                param[5].Value = obj.MovementType;
                param[6] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[6].Value = obj.CreatedBy;

                DataTable dataTable = _SqlHelper.ExecuteDataset(_SqlTransaction, "[PRC_AssetApprove]", param).Tables[0];
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

    }
}
