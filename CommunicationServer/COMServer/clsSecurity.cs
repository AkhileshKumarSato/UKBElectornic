//using UmsDLL;
using SatoLib;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace COMServer.Classes
{
    class clsSecurity
    {
        clsMsgRule oRule = new clsMsgRule();
        private SqlHelper _SqlHelper = new SqlHelper();

        #region EN Method
        public string EncryptString(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        public string DecryptString(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

        #region Login & Menu

        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public string ManageUser(User obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {


                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;

                param[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
                param[1].Value = obj.UserId;
                param[2] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param[2].Value = obj.Name;
                param[3] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                param[3].Value = obj.Password;
                param[4] = new SqlParameter("@Group", SqlDbType.VarChar, 50);
                param[4].Value = obj.Group;

                param[5] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                param[5].Value = obj.CreatedBy;
                param[6] = new SqlParameter("@NewPassword", SqlDbType.VarChar, 50);
                param[6].Value = obj.NewPassword;

                param[7] = new SqlParameter("@PlantCode", SqlDbType.VarChar, 50);
                param[7].Value = obj.Plant;

                DataTable dt = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[Prc_UserMaster]", param).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    oRule.sResponse = clsMsgRule.sValid + "~" + dt.Rows[0]["USERID"].ToString() + "~" + dt.Rows[0]["UserName"].ToString() + "~" + dt.Rows[0]["GroupName"].ToString();
                }
                else
                {
                    oRule.sResponse = clsMsgRule.sInValid + "~Wrong UserId / Password";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRule.sResponse;
        }

        #endregion
        public string DtToString(DataTable dt)
        {
            string sRow = string.Empty;
            string sDTString = string.Empty;
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sCol = string.Empty;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sCol = sCol + dt.Rows[i][j].ToString() + "$";
                    }
                    sRow = sRow + sCol.Substring(0, sCol.Length - 1) + "#";
                }
                sDTString = sRow.Substring(0, sRow.Length - 1);
            }
            return sDTString;
        }

        #endregion

        #region MyFuncation
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public string ManageGroupRights(User obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@Type", SqlDbType.VarChar, 100);
                param[0].Value = "GET_USER_RIGHTS";
                param[1] = new SqlParameter("@GroupName", SqlDbType.VarChar, 50);
                param[1].Value = obj.Group;
                DataTable dt = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_GroupMaster]", param).Tables[0];
                oRule.sResponse = clsMsgRule.sValid + "~";
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        oRule.sResponse += row["ModuleId"].ToString() + "#";
                    }
                    oRule.sResponse = oRule.sResponse.TrimEnd('#');
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRule.sResponse;
        }

        #endregion

        #region In And Out Process
        /// <summary>
        /// Execute Operation 
        /// </summary>
        /// <returns></returns>
        public string ManageInAndOut(InAndOut obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@FROM_PLANT", SqlDbType.VarChar, 50);
                param[1].Value = obj.FromPlant;
                param[2] = new SqlParameter("@TO_PLANT", SqlDbType.VarChar, 50);
                param[2].Value = obj.ToPlant;
                param[3] = new SqlParameter("@DOC_NO", SqlDbType.VarChar, 200);
                param[3].Value = obj.DocNo;
                param[4] = new SqlParameter("@RFID_TAG", SqlDbType.VarChar, 200);
                param[4].Value = obj.RFIDTag;
                param[5] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[5].Value = obj.CreatedBy;

                DataTable dt = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_DISPATCH]", param).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName.ToString() == "RESULT")
                    {
                        //if (dt.Rows[0][0].ToString() == "Y")
                            oRule.sResponse = clsMsgRule.sValid + "~" + dt.Rows[0]["RESULT"].ToString();
                        //else
                        //    oRule.sResponse = clsMsgRule.sInValid + "~" + dt.Rows[0]["RESULT"].ToString();
                    }
                    else
                    {
                        oRule.sResponse = clsMsgRule.sValid + "~";
                        oRule.sResponse += DtToString(dt);
                    }
                }
                else
                {
                    oRule.sResponse = clsMsgRule.sInValid + "~Data No Saved";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRule.sResponse;
        }

        public string ManageInAndOut_RCV(InAndOut obj)
        {
            _SqlHelper = new SqlHelper();
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@TYPE", SqlDbType.VarChar, 100);
                param[0].Value = obj.DbType;
                param[1] = new SqlParameter("@FROM_PLANT", SqlDbType.VarChar, 50);
                param[1].Value = obj.FromPlant;
                param[2] = new SqlParameter("@TO_PLANT", SqlDbType.VarChar, 50);
                param[2].Value = obj.ToPlant;
                param[3] = new SqlParameter("@DOC_NO", SqlDbType.VarChar, 200);
                param[3].Value = obj.DocNo;
                param[4] = new SqlParameter("@RFID_TAG", SqlDbType.VarChar, 200);
                param[4].Value = obj.RFIDTag;
                param[5] = new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 50);
                param[5].Value = obj.CreatedBy;

                DataTable dt = _SqlHelper.ExecuteDataset(GlobalVariable.mMainSqlConString, CommandType.StoredProcedure, "[PRC_RECEIVING]", param).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName.ToString() == "RESULT")
                    {
                        //if (dt.Rows[0][0].ToString() == "Y")
                        oRule.sResponse = clsMsgRule.sValid + "~" + dt.Rows[0]["RESULT"].ToString();
                        //else
                        //    oRule.sResponse = clsMsgRule.sInValid + "~" + dt.Rows[0]["RESULT"].ToString();
                    }
                    else
                    {
                        oRule.sResponse = clsMsgRule.sValid + "~";
                        oRule.sResponse += DtToString(dt);
                    }
                }
                else
                {
                    oRule.sResponse = clsMsgRule.sInValid + "~Data No Saved";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRule.sResponse;
        }

        #endregion




    }
}
