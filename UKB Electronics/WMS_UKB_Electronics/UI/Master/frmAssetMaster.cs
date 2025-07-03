using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using SATO_PRINTING_BL;
using SATO_PRINTING_COMMON;
using SATO_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS_UKB_Electronics
{
    public partial class frmAssetMaster : Form
    {


        #region Variables

        private BL_AssetMaster _blObj = null;
        private PL_AssetMaster _plObj = null;
        private bool _IsUpdate = false;
        DataTable dtPlant= null;
        DataTable dtFloor = null;
        DataTable dtSection = null;
        string ID = "";

        #endregion

        #region Form Methods

        public frmAssetMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_AssetMaster();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                btnDelete.Enabled = false;
                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                }
                Clear();
                GetPlant();
                GetFloor1();
                GetSection1();
                BindGrid();
                cmbPlant.Focus();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }

        #endregion
        #region Button Event
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _plObj = new PL_AssetMaster();
                DataTable dataTable = null;
                if (dgvUpload.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvUpload.Rows)
                    {
                        if (Convert.ToString(row.Cells["Error1"].Value) != string.Empty && Convert.ToString(row.Cells["Error2"].Value) != string.Empty && Convert.ToString(row.Cells["Error3"].Value) != string.Empty)
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please remove all the given errors in excel and upload again.", 3);
                            return;
                        }
                    }
                    if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Do you want to save the record!!"))
                    {
                        foreach (DataGridViewRow row in dgvUpload.Rows)
                        {
                            _plObj.PlantCode = Convert.ToString(row.Cells["Plant"].Value);
                            _plObj.Floor = Convert.ToString(row.Cells["Floor_No"].Value);
                            _plObj.Section = Convert.ToString(row.Cells["Section_No"].Value);
                            _plObj.AssetCode = Convert.ToString(row.Cells["Asset_Code"].Value);
                            _plObj.RFID_Tag = Convert.ToString(row.Cells["RFIDTag"].Value);
                            _plObj.Brand = Convert.ToString(row.Cells["Brand_Code"].Value);
                            _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                            _plObj.DbType = "INSERT";
                             dataTable = _blObj.BL_ExecuteTask(_plObj);
                        }


                        if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Saved successfully!!", 1);
                            dgvUpload.Visible = false;
                            dgvUpload.Height = 0;
                            lblPath.Text = "";
                            dgv.DataSource = null;
                            dgv.Visible = true;
                            dgv.Height = 500;
                            btnReset_Click(sender, e);
                        }
                        else 
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0]["RESULT"].ToString(), 3);
                        }

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (ValidateInput())
                    {
                        if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Do you want to save the record!!"))
                        {
                            _plObj.PlantCode = cmbPlant.SelectedItem.ToString();
                            _plObj.Floor = cmbFloor.SelectedItem.ToString();
                            _plObj.Section = cmbSection.SelectedItem.ToString();
                            _plObj.AssetCode = txtAssetCode.Text.Trim().ToString();
                            _plObj.RFID_Tag = txtRfidTag.Text.Trim().ToString();
                            _plObj.Description = txtDec.Text.Trim().ToString();
                            _plObj.Brand = txtBrandType.Text.Trim().ToString();
                            //_plObj.LineNo = GlobalVariable.mSatoAppsLoginLine;
                            _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                            //If saving data
                            if (_IsUpdate == false)
                            {
                                _plObj.DbType = "INSERT";
                                 dataTable = _blObj.BL_ExecuteTask(_plObj);
                                if (dataTable.Rows.Count > 0)
                                {
                                    if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                                    {
                                        btnReset_Click(sender, e);
                                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Saved successfully!!", 1);
                                        //frmModelMaster_Load(null, null);
                                    }
                                    else
                                    {
                                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0]["RESULT"].ToString(), 3);
                                    }
                                }
                            }
                            else // if updating data
                            {
                                _plObj.DbType = "UPDATE";

                                 dataTable = _blObj.BL_ExecuteTask(_plObj);
                                if (dataTable.Rows.Count > 0)
                                {
                                    if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                                    {
                                        btnReset_Click(sender, e);
                                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Updated successfully!!", 1);
                                    }
                                    else
                                    {
                                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0]["RESULT"].ToString(), 3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Asset already exist!!", 3);
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtPartSearch.Text = "";
                Clear();
                BindGrid();

                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDec.Text))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Asset Code can't be blank!!", 3);
                    return;
                }
                if (GlobalVariable.mStoCustomFunction.ConfirmationMsg(GlobalVariable.mSatoApps, "Äre you sure to delete the record !!"))
                {
                    _plObj = new PL_AssetMaster();
                    _blObj = new BL_AssetMaster();
                    _plObj.AssetCode = txtAssetCode.Text.Trim().ToString();
                    _plObj.ID = ID;
                    _plObj.DbType = "DELETE";
                    DataTable dataTable = _blObj.BL_ExecuteTask(_plObj);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0][0].ToString().StartsWith("Y"))
                        {
                            btnReset_Click(sender, e);
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Deleted successfully!!", 1);
                            frmModelMaster_Load(null, null);
                        }
                        else
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0]["RESULT"].ToString(), 3);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "This is already in use!!!", 3);
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.ExportInCSV(dgv);
            }
            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        #endregion

        #region Methods

        private void GetPlant()
        {
            try
            {
                _plObj = new PL_AssetMaster();
                _plObj.DbType = "Get_Plant";
                cmbPlant.Items.Clear();
                cmbPlant.Items.Add("--Select--");
                dtPlant = _blObj.BL_ExecuteTask(_plObj);
                if (dtPlant.Rows.Count > 0)
                {
                    foreach (DataRow row in dtPlant.Rows)
                    {
                        cmbPlant.Items.Add(row["PlantCode"].ToString());
                    }

                    cmbPlant.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetFloor(string PlantCode)
        {
            try
            {
                _plObj = new PL_AssetMaster();
                _plObj.DbType = "Get_Floor";
                _plObj.PlantCode = PlantCode;
                cmbFloor.Items.Clear();
                cmbFloor.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbFloor.Items.Add(row["Floor"].ToString());
                    }

                    cmbFloor.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetFloor1()
        {
            try
            {
                _plObj = new PL_AssetMaster();
                _plObj.DbType = "Get_Floor1";
                
                dtFloor = _blObj.BL_ExecuteTask(_plObj);

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetSection1()
        {
            try
            {
                _plObj = new PL_AssetMaster();
                _plObj.DbType = "Get_Section1";
              
                dtSection = _blObj.BL_ExecuteTask(_plObj);
               

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetSection(string PlantCode ,string Floor)
        {
            try
            {
                _plObj = new PL_AssetMaster();
                _plObj.DbType = "Get_Section";
                _plObj.PlantCode = PlantCode;
                _plObj.Floor = Floor;
                cmbSection.Items.Clear();
                cmbSection.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbSection.Items.Add(row["Section"].ToString());
                    }

                    cmbSection.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void ValidateExcelPlant(DataTable dtExcelData)
        {
            for (int i = 0; i < dtExcelData.Rows.Count; i++)
            {
                var data = from c in dtPlant.AsEnumerable()
                           where c.Field<string>("PlantCode").ToUpper().Trim() == Convert.ToString(dtExcelData.Rows[i]["Plant"]).ToUpper().Trim()
                           //&& c.Field<string>("Color").ToUpper().Trim() == Convert.ToString(dtExcelData.Rows[i]["Color"]).ToUpper()
                           select c;
                if (data.AsDataView().Count == 0)
                {
                    dtExcelData.Rows[i]["Error1"] = "Invalid Plant";
                }

            }
        }

        private void ValidateExcelFloor(DataTable dtExcelData)
        {
            for (int i = 0; i < dtExcelData.Rows.Count; i++)
            {
                var data = from c in dtFloor.AsEnumerable()
                           where c.Field<string>("Floor").ToUpper().Trim() == Convert.ToString(dtExcelData.Rows[i]["Floor_No"]).ToUpper().Trim()
                           select c;
                if (data.AsDataView().Count == 0)
                {
                    dtExcelData.Rows[i]["Error2"] = "Invalid Floor";
                }

            }
        }
        private void ValidateExcelSection(DataTable dtExcelData)
        {
            for (int i = 0; i < dtExcelData.Rows.Count; i++)
            {
                var data = from c in dtSection.AsEnumerable()
                           where c.Field<string>("Section").ToUpper().Trim() == Convert.ToString(dtExcelData.Rows[i]["Section_No"]).ToUpper().Trim()
                           select c;
                if (data.AsDataView().Count == 0)
                {
                    dtExcelData.Rows[i]["Error3"] = "Invalid Section";
                }

            }
        }

        private void Clear()
        {
            try
            {
                ID = "";
                cmbPlant.SelectedIndex = -1;
                cmbFloor.SelectedIndex = -1;
                cmbSection.SelectedIndex = -1;
                txtDec.Text = "";
                txtAssetCode.Text = "";
                txtRfidTag.Text = "";
                txtBrandType.Text = "";
                GetPlant();
                txtAssetCode.Enabled = true;
                cmbPlant.Focus();
                btnDelete.Enabled = false;
                _IsUpdate = false;
                dgv.Visible = true;
                dgvUpload.Visible = false;
                dgvUpload.Height = 0;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        private void BindGrid()
        {
            try
            {
                _plObj = new PL_AssetMaster();
                _blObj = new BL_AssetMaster();
                _plObj.DbType = "SELECT";
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                dgv.DataSource = dt;
                lblCount.Text = "Rows Count : " + dgv.Rows.Count;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3); ;
            }
        }
        private bool ValidateInput()
        {
            try
            {
                if (cmbPlant.SelectedIndex ==0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Plant can't be blank!!", 3);
                    cmbPlant.Focus();
                    return false;
                }
                if (cmbFloor.SelectedIndex == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Floor can't be blank!!", 3);
                    cmbFloor.Focus();
                    return false;
                }
                if (cmbSection.SelectedIndex == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Section can't be blank!!", 3);
                    cmbSection.Focus();
                    return false;
                }
                if (txtAssetCode.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Asset Code can't be blank!!", 3);
                    txtAssetCode.Focus();
                    return false;
                }
                if (txtRfidTag.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "RFID Tag can't be blank!!", 3);
                    txtRfidTag.Focus();
                    return false;
                }
                if (txtBrandType.Text.Trim().Length == 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Brand can't be blank!!", 3);
                    txtBrandType.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Label Event

        #endregion

        #region DataGridView Events
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <= -1)
                {
                    return;
                }
                Clear();
                cmbPlant.SelectedItem= dgv.Rows[e.RowIndex].Cells["PlantCode"].Value.ToString();
                cmbFloor.SelectedItem = dgv.Rows[e.RowIndex].Cells["Floor"].Value.ToString();
                cmbSection.SelectedItem = dgv.Rows[e.RowIndex].Cells["Section"].Value.ToString();
                txtAssetCode.Text = dgv.Rows[e.RowIndex].Cells["AssetCode"].Value.ToString();
                txtDec.Text = dgv.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                txtBrandType.Text = dgv.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
                txtRfidTag.Text = dgv.Rows[e.RowIndex].Cells["RFID_Tag"].Value.ToString();
                ID = dgv.Rows[e.RowIndex].Cells["AssetID"].Value.ToString();
                txtAssetCode.Enabled=false;
                btnDelete.Enabled = true;
                _IsUpdate = true;
                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave, btnDelete);
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        #endregion

        #region TextBox Event

        private void txtPartSearch_TextChanged(object sender, EventArgs e)
        {

            if (dgv.Rows.Count > 0)
            {
               
             (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("PlantCode LIKE '%{0}%' OR AssetCode LIKE '%{0}%'", txtPartSearch.Text);
               
            }
            else
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "No Data Found", 3);

                BindGrid();
            }
        }

        #endregion

        private void cmbPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlant.SelectedIndex > 0)
            {
                GetFloor(cmbPlant.SelectedItem.ToString());
                
            }
        }

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlant.SelectedIndex > 0 && cmbFloor.SelectedIndex>0)
            {
                GetSection(cmbPlant.SelectedItem.ToString(), cmbFloor.SelectedItem.ToString());

            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string _ModuleType = string.Empty;
                DataTable _dtBindList = null;
                btnUpload.Cursor = Cursors.WaitCursor;
                OpenFileDialog openFileDialog= new OpenFileDialog();
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    openFileDialog.Filter = "xls files (*.xls)|*.Xls";
                    lblPath.Text = openFileDialog.FileName;
                    _dtBindList = new DataTable();
                    if (!openFileDialog.FileName.Contains(".xls") && !openFileDialog.FileName.Contains(".xlsx"))
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Invalid sheet", 3);
                        return;
                    }
                    _dtBindList = GlobalVariable.IMPORT_DATA(openFileDialog.FileName, _ModuleType);
                    if (!ValidateExcelColumn(_dtBindList))
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Invalid sheet", 3);
                        lblPath.Text = string.Empty;
                        return;
                    }
                    _dtBindList.Columns.Add("Error1");
                    _dtBindList.Columns.Add("Error2");
                    _dtBindList.Columns.Add("Error3");

                    if (_dtBindList.Rows.Count > 0)
                    {
                        ValidateExcelPlant(_dtBindList);
                        ValidateExcelFloor(_dtBindList);
                        ValidateExcelSection(_dtBindList);
                       
                        dgvUpload.Visible = true;
                        dgv.Height = 0;
                        dgvUpload.Height = 500;
                        dgv.Visible = false;
                        dgvUpload.DataSource = _dtBindList.DefaultView;
                    }
                    else
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "No Data available in Selected Excel!", 3);
                        lblPath.Text = string.Empty;
                        return;
                    }

                }
            }

            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("CHECK NUMBER OF COLUMNS "))
                { }
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
                lblPath.Text = string.Empty;
            }
            finally
            {
                btnUpload.Cursor = Cursors.Arrow;
            }
        }

        private bool ValidateExcelColumn(DataTable dt)
        {
            bool isValid = false;

            if (Convert.ToString(dt.Columns[0].ColumnName) != "Plant".Trim())
            {
                return isValid = false;
            }
            if (Convert.ToString(dt.Columns[1].ColumnName) != "Floor_No".Trim())
            {
                return isValid = false;
            }
            if (Convert.ToString(dt.Columns[2].ColumnName) != "Section_No".Trim())
            {
                return isValid = false;
            }
            else if (Convert.ToString(dt.Columns[3].ColumnName) != "Asset_Code".Trim())
            {
                return isValid = false;
            }
            else if (Convert.ToString(dt.Columns[4].ColumnName) != "RFIDTag".Trim())
            {
                return isValid = false;
            }
            else if (Convert.ToString(dt.Columns[5].ColumnName) != "Brand_Code".Trim())
            {
                return isValid = false;
            }


            else
            {
                dt.Columns[0].ColumnName = "Plant";
                dt.Columns[1].ColumnName = "Floor_No";
                dt.Columns[2].ColumnName = "Section_No";
                dt.Columns[3].ColumnName = "Asset_Code";
                dt.Columns[4].ColumnName = "RFIDTag";
                dt.Columns[5].ColumnName = "Brand_Code";

                return isValid = true;
            }
        }

        private void btnDownloadFormat_Click(object sender, EventArgs e)
        {
            try
            {
                btnDownloadFormat.Cursor = Cursors.WaitCursor;
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Documents" + "\\AssetMaster.xlsx"))
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Documents" + "\\AssetMaster.xlsx");
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "File Not Exis", 3);
                }
            }
            catch (Exception ex)
            { 
              btnDownloadFormat.Cursor = Cursors.Arrow; 
              GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
            finally
            {
                btnDownloadFormat.Cursor = Cursors.Arrow;
            }
        }
    }
}
