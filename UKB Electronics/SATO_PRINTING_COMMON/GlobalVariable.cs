﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatoLib;

namespace SATO_PRINTING_COMMON
{
   public class GlobalVariable
    {
        public static SatoCustomFunction mStoCustomFunction = new SatoCustomFunction();
        public static string mSatoApps = "SatoApps";
        public static string mMainSqlConString = "";
        public static string mSatoDbServer = "";
        public static string mSatoDb = "";
        public static string mSatoDbUser = "";
        public static string mSatoDbPassword = "";
        public static string mSatoAppsLoginUser = "";
        public static string mSatoAppsLoginLine = "";
        public static string mUserType = "";
        public static SatoLogger AppLog;
        public static string UserName="";
        public static string UserGroup = "";
        public static string mAccessUser = "";
        public static string IP = "";
        public static string Port = "";
        public static string mPrinterName = "";
        public static string mBoxPrnFileName = "BOX_LABEL.PRN";
        public static string mPalletPrnFileName = "PALLET_LABEL.PRN";
        public static string mPrn = string.Empty;
        public static string ProductQRPortNo = "";
        public static string MRPQRPortNo = "";
        public static string CARTONQRPortNo = "";
        public static string gEXCELVER = "12.0";
        public static string BaudRate = "";
        public static string Parity = "";
        public static string StopBits = "";
        public static string DataBits = "";
        public static string Handshake = "";
        public static  void MesseageInfo(Label label,string sMessage, int icnt)
        {
            if (icnt == 1)
            {
                label.BackColor = Color.Yellow;
                label.ForeColor = Color.Black;
                label.Text = sMessage;
            }
            else
            {
                label.BackColor = Color.Red;
                label.ForeColor = Color.WhiteSmoke;
                label.Text = sMessage;
            }
        }
        public static void allowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public static void BindCombo(ComboBox comboBox, DataTable dataTable)
        {
            try
            {
                DataRow Drw;
                Drw = dataTable.NewRow();
                Drw.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(Drw, 0);
                comboBox.DataSource = dataTable.DefaultView;
                comboBox.ValueMember = dataTable.Columns[0].ColumnName;
                comboBox.DisplayMember = dataTable.Columns[1].ColumnName;

            }
            catch (Exception ex)
            {
                if (ex.Message == "ComboBox that has a DataSource set cannot be sorted") { return; }
                throw;
            }
        }
        public static void allowOnlyForLandline(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '-'))
            {
                e.Handled = false;
            }

        }
        public static void allowOnlyNumericAndDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^[0-9]{10}$").Success;
        }
        public static bool IsEmailId(string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
        public static string  DataTableToCsv(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            var columnNames = dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            return sb.ToString().Replace(""+'"'+"","");
        }
        public static void ExportDataInCSV(DataTable _dt)
        {
            string _FileName = string.Empty;
            SaveFileDialog sdb = new SaveFileDialog();
            sdb.InitialDirectory = @"C:\";
            sdb.Title = "Save text Files";
            if (sdb.ShowDialog() == DialogResult.OK)
                _FileName = sdb.FileName;
            else
                return;
            StreamWriter _sWriter = new StreamWriter(_FileName + ".csv");
            string _sData = "";
            try
            {

                for (int i = 0; i < _dt.Columns.Count; i++)
                {
                    if (_sData == "")
                        _sData = _dt.Columns[i].ColumnName.ToString().ToUpper();
                    else
                        _sData = _sData + "," + _dt.Columns[i].ColumnName.ToString().ToUpper();
                }
                _sWriter.WriteLine(_sData);

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    _sData = "";
                    for (int j = 0; j < _dt.Columns.Count; j++)
                    {
                        if (_sData == "")
                            _sData = _dt.Rows[i][j].ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                        else
                            _sData = _sData + "," + _dt.Rows[i][j].ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                    }
                    _sWriter.WriteLine(_sData);
                }
                MessageBox.Show("Data exported successfully at " + _FileName + ".csv", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sWriter.Close();
                _sWriter.Dispose();
            }
        }
        public static void ExportInCSV(DataGridView _dg)
        {
            string _FileName = string.Empty;
            SaveFileDialog sdb = new SaveFileDialog();
            sdb.InitialDirectory = @"C:\";
            sdb.Title = "Save text Files";
            if (sdb.ShowDialog() == DialogResult.OK)
                _FileName = sdb.FileName;
            else
                return;
            StreamWriter _sWriter = new StreamWriter(_FileName + ".csv");
            string _sData = "";
            try
            {

                for (int i = 0; i < _dg.ColumnCount; i++)
                {
                    if (_sData == "")
                        _sData = _dg.Columns[i].HeaderText.ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                    else
                        _sData = _sData + "," + _dg.Columns[i].HeaderText.ToString().ToUpper().Replace(",", "").Replace("\t", "").Replace("\n", "").Trim();
                }
                _sWriter.WriteLine(_sData);

                for (int i = 0; i < _dg.Rows.Count; i++)
                {
                    _sData = "";

                    for (int j = 0; j < _dg.ColumnCount; j++)
                    {
                        if (_dg.Rows[i].Cells[j].Value == null)
                            _dg.Rows[i].Cells[j].Value = "";
                        if (_sData == "")
                            _sData = _dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim();
                        else
                            _sData = _sData + "," + _dg.Rows[i].Cells[j].Value.ToString().ToUpper().Replace(",", "~").Replace("\t", "").Replace("\n", "").Trim();
                    }
                    _sWriter.WriteLine(_sData);
                }
                MessageBox.Show("Data exported successfully at " + _FileName + ".csv", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sWriter.Close();
                _sWriter.Dispose();
            }
        }

        public static bool ReadLocationPrn()
        {
            string _sPrnWithMaster = AppDomain.CurrentDomain.BaseDirectory + "\\Location.PRN";
            string prn = string.Empty;

            if (File.Exists(_sPrnWithMaster))
            {
                StreamReader sr = new StreamReader(_sPrnWithMaster);
                prn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                mPrn = prn;
            }
            return true;
        }

        public static bool ReadMachinePrn()
        {
            string _sPrnWithMaster = AppDomain.CurrentDomain.BaseDirectory + "\\Machine.PRN";
            string prn = string.Empty;

            if (File.Exists(_sPrnWithMaster))
            {
                StreamReader sr = new StreamReader(_sPrnWithMaster);
                prn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                mPrn = prn;
            }
            return true;
        }

        public static bool ReadRMPrintingPrn()
        {
            string _sPrnWithMaster = AppDomain.CurrentDomain.BaseDirectory + "\\RMBarcode.PRN";
            string prn = string.Empty;

            if (File.Exists(_sPrnWithMaster))
            {
                StreamReader sr = new StreamReader(_sPrnWithMaster);
                prn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                mPrn = prn;
            }
            return true;
        }
        public static DataTable IMPORT_DATA(string strPath, string ProcessType)
        {
            string conn = "";
            DataTable dt = null;
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Worksheet wsheet = new Microsoft.Office.Interop.Excel.Worksheet();
                Microsoft.Office.Interop.Excel.Workbook wbook = excelApp.Workbooks.Open(strPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wsheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;
                if (GlobalVariable.gEXCELVER == "12.0")
                {
                    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + ";Extended Properties=\"Excel 12.0;IMEX=1\";";
                }
                else if (GlobalVariable.gEXCELVER == "4.0")
                {
                    conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + ";Extended Properties=\"Excel 8.0;IMEX=1\";";
                }
                else if (GlobalVariable.gEXCELVER == "16.0")
                {
                    conn = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + strPath + ";Extended Properties=\"Excel 16.0;IMEX=1\";";
                }
                else
                {
                    return dt;
                }
                OleDbDataAdapter adp = new OleDbDataAdapter("select   * from [" + wsheet.Name + "$]  ", conn);
                dt = new DataTable();
                adp.Fill(dt);
                adp.Dispose();
                Marshal.ReleaseComObject(wsheet);
                Marshal.ReleaseComObject(wbook);
                wsheet = null;
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
                wbook = null;
                excelApp = null;
                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
                DataTable filteredRows = dt.Rows.Cast<DataRow>().Where(row => row.ItemArray.Any(field => !(field is System.DBNull))).CopyToDataTable(); //use to remove excel's blank rows(Added by SANTOSH)
                return filteredRows;
            }
            catch
            {
                throw;
            }
        }

        public static bool ReadSFPrintingPrn()
        {
            string _sPrnWithMaster = AppDomain.CurrentDomain.BaseDirectory + "\\SFBarcode.PRN";
            string prn = string.Empty;

            if (File.Exists(_sPrnWithMaster))
            {
                StreamReader sr = new StreamReader(_sPrnWithMaster);
                prn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                mPrn = prn;
            }
            return true;
        }

        public static bool ReadFGPrintingPrn()
        {
            string _sPrnWithMaster = AppDomain.CurrentDomain.BaseDirectory + "\\ASTI_PRN.PRN";
            string prn = string.Empty;

            if (File.Exists(_sPrnWithMaster))
            {
                StreamReader sr = new StreamReader(_sPrnWithMaster);
                prn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                mPrn = prn;
            }
            return true;
        }

    }
}
