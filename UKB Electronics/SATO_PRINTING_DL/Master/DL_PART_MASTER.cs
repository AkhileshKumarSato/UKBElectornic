
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

    public class DL_PART_MASTER
    {
        SqlHelper _SqlHelper = new SqlHelper();
        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public DataTable DL_ExecuteTask(PL_PART_MASTER obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@Line_No", SqlDbType.VarChar, 50);
                param[1].Value = obj.LineNo;
                param[2] = new SqlParameter("@ModelNo", SqlDbType.VarChar, 100);
                param[2].Value = obj.ModelNo;
                param[3] = new SqlParameter("@ProductCode", SqlDbType.VarChar, 50);
                param[3].Value = obj.ProductCode;
                param[4] = new SqlParameter("@ProductName", SqlDbType.VarChar, 100);
                param[4].Value = obj.ProductName;
                param[5] = new SqlParameter("@EAN_No", SqlDbType.VarChar, 50);
                param[5].Value = obj.EAN_No;
                param[6] = new SqlParameter("@PackSize", SqlDbType.Int);
                param[6].Value = obj.PackSize;
                param[7] = new SqlParameter("@ProductQRLength", SqlDbType.Int);
                param[7].Value = obj.ProductQRLength;
                param[8] = new SqlParameter("@NetQty", SqlDbType.VarChar, 100);
                param[8].Value = obj.NetQty;
                param[9] = new SqlParameter("@SLC_EAN_No", SqlDbType.VarChar, 50);
                param[9].Value = obj.SLC_EAN_No;
                param[10] = new SqlParameter("@MaxRetailPrice", SqlDbType.VarChar, 50);
                param[10].Value = obj.MaxRetailPrice;
                param[11] = new SqlParameter("@Specification", SqlDbType.VarChar, 50);
                param[11].Value = obj.Specification;
                param[12] = new SqlParameter("@Alphabet_Char_1", SqlDbType.VarChar, 50);
                param[12].Value = obj.Alphabet_Char_1;
                param[13] = new SqlParameter("@PositionIndex_Char_1", SqlDbType.Int);
                param[13].Value = obj.PositionIndex_Char_1;
                param[14] = new SqlParameter("@Alphabet_Char_2", SqlDbType.VarChar, 50);
                param[14].Value = obj.Alphabet_Char_2;
                param[15] = new SqlParameter("@PositionIndex_Char_2", SqlDbType.Int);
                param[15].Value = obj.PositionIndex_Char_2;
                param[16] = new SqlParameter("@SerialLength", SqlDbType.Int);
                param[16].Value = obj.SerialLength;
                param[17] = new SqlParameter("@ManufacturedBy", SqlDbType.VarChar, 100);
                param[17].Value = obj.ManufacturedBy;
                param[18] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 100);
                param[18].Value = obj.CreatedBy;
                param[19] = new SqlParameter("@Line", SqlDbType.VarChar, 100);
                param[19].Value = obj.Line;
                return _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_PartMaster]", param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion      

    }
}
