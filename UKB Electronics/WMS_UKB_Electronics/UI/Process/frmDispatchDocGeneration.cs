using SATO_PRINTING_BL;
using SATO_PRINTING_COMMON;
using SATO_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_UKB_Electronics
{
    public partial class frmDispatchDocGeneration : Form
    {

        #region Variables

        private BL_AssetMovement _blObj = null;
        private PL_AssetMovement _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        DataTable dtPicklistNo = new DataTable();
        DataTable dtAddUpdateRunTime = new DataTable();
        DataTable dtAdd = new DataTable();
        private bool _IsUpdate = false;
        DataRow dr;
        private int rowIndex = 0;

        #endregion

        #region Form Methods

        public frmDispatchDocGeneration()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_AssetMovement();
                _plObj = new PL_AssetMovement();
              
                dtAdd.Columns.Add("From_Plant");
                dtAdd.Columns.Add("From_Floor");
                dtAdd.Columns.Add("From_Section");
                dtAdd.Columns.Add("To_Plant");
                dtAdd.Columns.Add("To_Floor");
                dtAdd.Columns.Add("To_Section");
                dtAdd.Columns.Add("Asset_Code");
                dtAdd.Columns.Add("Asset_Qty");
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmRMPicklistGeneration_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;


               
                BindGrid();
                Clear();
                GetPlant();
                GetAsset();

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
       
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                GetPlant();
                lblLastGeneratedDocNo.Text = "**********************";
                Clear();
                
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods
        private void GetPlant()
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _plObj.DbType = "GET_PLANT";
                cmbFromPlant.Items.Clear();
                cmbFromPlant.Items.Add("--Select--");
                cmbToPlant.Items.Clear();
                cmbToPlant.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbFromPlant.Items.Add(row["PlantCode"].ToString());
                    }

                    cmbFromPlant.SelectedIndex = 0;
                }
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbToPlant.Items.Add(row["PlantCode"].ToString());
                    }

                    cmbToPlant.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetFromFloor(string PlantCode)
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _plObj.DbType = "GET_FLOOR";
                _plObj.FromPlant = PlantCode;
                cmbFromFloor.Items.Clear();
                cmbFromFloor.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbFromFloor.Items.Add(row["Floor"].ToString());
                    }

                    cmbFromFloor.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetToFloor(string PlantCode)
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _plObj.DbType = "GET_FLOOR";
                _plObj.FromPlant = PlantCode;
                cmbTofloor.Items.Clear();
                cmbTofloor.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbTofloor.Items.Add(row["Floor"].ToString());
                    }

                    cmbTofloor.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetFromSection(string PlantCode, string Floor)
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _plObj.DbType = "GET_SECTION";
                _plObj.FromPlant = PlantCode;
                _plObj.FromFloor = Floor;
                cmbFromSection.Items.Clear();
                cmbFromSection.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbFromSection.Items.Add(row["Section"].ToString());
                    }

                    cmbFromSection.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void GetToSection(string PlantCode, string Floor)
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _plObj.DbType = "GET_SECTION";
                _plObj.FromPlant = PlantCode;
                _plObj.FromFloor = Floor;
                cmbToSection.Items.Clear();
                cmbToSection.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbToSection.Items.Add(row["Section"].ToString());
                    }

                    cmbToSection.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void GetAsset()
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _plObj.DbType = "GET_AssetCode";
                cmbAsset.Items.Clear();
                cmbAsset.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbAsset.Items.Add(row["AssetCode"].ToString());
                    }
                    cmbAsset.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }


        private void Clear()
        {
            try
            {
                cmbFromPlant.SelectedIndex = -1;
                cmbFromFloor.SelectedIndex = -1;
                cmbFromSection.SelectedIndex = -1;
                cmbToPlant.SelectedIndex = -1;
                cmbTofloor.SelectedIndex = -1;
                cmbToSection.SelectedIndex = -1;
                cmbAsset.SelectedIndex = -1;
                cmbFromPlant.Enabled=true;
                cmbFromFloor.Enabled = true;
                cmbFromSection.Enabled = true;
                cmbToPlant.Enabled = true;
                cmbTofloor.Enabled = true;
                cmbToSection.Enabled = true;
                cmbAsset.Enabled = true;
                txtDisQty.Text = "0";
                txtDocSearch.Text = "";
                lblCount.Text = "Rows Count :0";
                _IsUpdate = false;
                dtAdd.Clear();
                btnAdd.Enabled = true;

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private bool ValidateInputs(bool p, string Mode)
        {
            if (Mode == "ADD")
            {
               if (cmbFromPlant.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill from plant", 3);
                    cmbFromPlant.Focus();
                    return p;
                }
               else if (cmbFromFloor.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill from floor", 3);
                    cmbFromFloor.Focus();
                    return p;
                }
                else if (cmbFromSection.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill from section", 3);
                    cmbFromSection.Focus();
                    return p;
                }
                else if (cmbToPlant.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill to plant", 3);
                    cmbToPlant.Focus();
                    return p;
                }
                else if (cmbTofloor.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill to floor", 3);
                    cmbTofloor.Focus();
                    return p;
                }
                else if (cmbToSection.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill to section", 3);
                    cmbToSection.Focus();
                    return p;
                }
                else if (cmbAsset.SelectedIndex == -1)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill Asset", 3);
                    cmbAsset.Focus();
                    return p;
                }

                else if (Convert.ToDecimal(txtDisQty.Text)<=0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please Enter qty", 3);
                    txtDisQty.Focus();
                    return p;
                }


            }
            return true;
        }

        private DataTable GetDocNo()
        {
            DataTable dt = new DataTable();
            try
            {
                _plObj = new PL_AssetMovement();
                _blObj = new BL_AssetMovement();
                _plObj.DbType = "DocNo";
                dt = _blObj.BL_GetDocNo(_plObj);
                lblLastGeneratedDocNo.Text = dt.Rows[0]["Barcode"].ToString();

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
            return dt;
        }


        private void BindGrid()
        {
            try
            {
                _plObj = new PL_AssetMovement();
                _blObj = new BL_AssetMovement();
                if (_IsUpdate)
                {
                    _plObj.DbType = "GETPICKLISTDETAILS";
                    _plObj.DocNo = lblLastGeneratedDocNo.Text;
                    dtBindGrid = _blObj.BL_ExecuteTask(_plObj);
                    dgvShowPickDetails.DataSource = dtBindGrid;
                    lblCount.Text = "Rows Count : " + dgvPicklist.Rows.Count;
                }
                else
                {
                    _plObj.DbType = "SELECT";
                    dtBindGrid = _blObj.BL_ExecuteTask(_plObj);

                    dgvPicklist.DataSource = dtBindGrid;
                    lblCount.Text = "Rows Count : " + dgvPicklist.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }


        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_IsUpdate == false)
            {
                if (ValidateInputs(false, "ADD") == true)
                {
                    dgvShowPickDetails.Visible = false;
                    dgvShowPickDetails.Height = 0;
                    dgvAdd.Visible = true;
                    dgvAdd.Height = 173;
                    if (dtAdd.Rows.Count > 0)
                    {
                        string expression = "From_Plant = '" + cmbFromPlant.SelectedItem.ToString() + "' and  From_Floor ='" + cmbFromFloor.SelectedItem.ToString() + "' and From_Section ='" + cmbFromSection.SelectedItem.ToString() + "'and To_Plant ='" + cmbToPlant.SelectedItem.ToString() + "'and To_Floor ='" + cmbTofloor.SelectedItem.ToString() + "'and To_Section ='" + cmbToSection.SelectedItem.ToString() + "'";
                        DataRow[] foundAuthors = dtAdd.Select(expression);
                        if (foundAuthors.Length != 0)
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "This is Already Added", 3);
                            ClearAdd();
                        }
                        else
                        {
                            dr = dtAdd.NewRow();
                            dr["From_Plant"] = cmbFromPlant.SelectedItem.ToString();
                            dr["From_Floor"] = cmbFromFloor.SelectedItem.ToString();
                            dr["From_Section"] = cmbFromSection.SelectedItem.ToString();
                            dr["To_Plant"] = cmbToPlant.SelectedItem.ToString();
                            dr["To_Floor"] = cmbTofloor.SelectedItem.ToString();
                            dr["To_Section"] = cmbToSection.SelectedItem.ToString();
                            dr["Asset_Code"] = cmbAsset.SelectedItem.ToString();
                            dr["Asset_Qty"] = txtDisQty.Text;
                            dtAdd.Rows.Add(dr);
                            dgvAdd.DataSource = dtAdd;
                            ClearAdd();
                        }
                    }
                    else
                    {
                        dr = dtAdd.NewRow();
                        dr["From_Plant"] = cmbFromPlant.SelectedItem.ToString();
                        dr["From_Floor"] = cmbFromFloor.SelectedItem.ToString();
                        dr["From_Section"] = cmbFromSection.SelectedItem.ToString();
                        dr["To_Plant"] = cmbToPlant.SelectedItem.ToString();
                        dr["To_Floor"] = cmbTofloor.SelectedItem.ToString();
                        dr["To_Section"] = cmbToSection.SelectedItem.ToString();
                        dr["Asset_Code"] = cmbAsset.SelectedItem.ToString();
                        dr["Asset_Qty"] = txtDisQty.Text;
                        dtAdd.Rows.Add(dr);
                        dgvAdd.DataSource = dtAdd;
                        ClearAdd();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void ClearAdd()
        {
            cmbFromPlant.Enabled=false;
            cmbFromFloor.SelectedIndex= -1;
            cmbFromSection.SelectedIndex = -1;
            cmbToPlant.Enabled= false;
            cmbTofloor.SelectedIndex= -1;
            cmbToSection.SelectedIndex = -1;
            cmbAsset.SelectedIndex = -1;
            txtDisQty.Text = "";
            btnAdd.Enabled = true;
            cmbAsset.Focus();
        }

      
        private void txtPickQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAdd.Columns["Delete"].Index && e.RowIndex >= 0) //make sure button index here
            {
                DataGridViewRow row = dgvAdd.Rows[e.RowIndex];
                string From_Plant = row.Cells["From_Plant"].Value.ToString();
                string From_Floor = row.Cells["From_Floor"].Value.ToString();
                string From_Section = row.Cells["From_Section"].Value.ToString();
                string To_Plant = row.Cells["To_Plant"].Value.ToString();
                string To_Floor = row.Cells["To_Floor"].Value.ToString();
                string To_Section = row.Cells["To_Section"].Value.ToString();
                string Asset_Code = row.Cells["Asset_Code"].Value.ToString();

                for (int i = dtAdd.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtAdd.Rows[i];
                    if (dr["From_Plant"].ToString() == From_Plant && dr["From_Floor"].ToString() == From_Floor && dr["From_Section"].ToString() == From_Section && dr["To_Plant"].ToString() == To_Plant && dr["To_Floor"].ToString() == To_Floor && dr["To_Section"].ToString() == To_Section && dr["Asset_Code"].ToString() == Asset_Code)
                        dr.Delete();
                }
                dtAdd.AcceptChanges();
                dgvAdd.DataSource = dtAdd;
                cmbFromPlant.Enabled = true;
                cmbFromFloor.SelectedIndex = -1;
                cmbFromSection.SelectedIndex = -1;
                cmbToPlant.Enabled = true;
                cmbTofloor.SelectedIndex = -1;
                cmbToSection.SelectedIndex = -1;
                cmbAsset.SelectedIndex = -1;
                txtDisQty.Text = "";
                btnAdd.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dataTable = new DataTable();
                DialogResult MessResult = MessageBox.Show("Do You Really Want To Save.?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (MessResult == DialogResult.No)
                { return; }
                if (_IsUpdate == false)
                {
                    if (dgvAdd.Rows.Count > 0)
                    {
                        GetDocNo();
                        if (lblLastGeneratedDocNo.Text == "")
                        { return; }

                        for (int i = 0; i < dgvAdd.Rows.Count; i++)
                        {
                            _plObj = new PL_AssetMovement();
                            _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                            _plObj.DocNo = lblLastGeneratedDocNo.Text.Trim().ToString();
                            _plObj.FromPlant = dgvAdd.Rows[i].Cells["From_Plant"].Value.ToString();
                            _plObj.FromFloor = dgvAdd.Rows[i].Cells["From_Floor"].Value.ToString();
                            _plObj.FromSection = dgvAdd.Rows[i].Cells["From_Section"].Value.ToString();
                            _plObj.ToPlant = dgvAdd.Rows[i].Cells["To_Plant"].Value.ToString();
                            _plObj.ToFloor = dgvAdd.Rows[i].Cells["To_Floor"].Value.ToString();
                            _plObj.ToSection = dgvAdd.Rows[i].Cells["To_Section"].Value.ToString();
                            _plObj.AssetCode = dgvAdd.Rows[i].Cells["Asset_Code"].Value.ToString();
                            _plObj.Qty = Convert.ToDecimal(dgvAdd.Rows[i].Cells["Asset_Qty"].Value.ToString());
                            _plObj.DbType = "INSERT";
                            dataTable = _blObj.BL_ExecuteTask(_plObj);

                        }
                    }
                    else
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "At least one row grid!!!", 2);
                        return;
                    }
                }
                else
                {
                    if (dgvShowPickDetails.Rows.Count > 0)
                    {
                        if (lblLastGeneratedDocNo.Text == "")
                        { return; }
                        _plObj = new PL_AssetMovement();
                        _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                        _plObj.DocNo = lblLastGeneratedDocNo.Text.Trim().ToString();
                        _plObj.FromPlant = cmbFromPlant.SelectedItem.ToString();
                        _plObj.FromFloor = cmbFromFloor.SelectedItem.ToString();
                        _plObj.FromSection = cmbFromSection.SelectedItem.ToString();
                        _plObj.ToPlant = cmbToPlant.SelectedItem.ToString();
                        _plObj.ToFloor = cmbTofloor.SelectedItem.ToString();
                        _plObj.ToSection = cmbToSection.SelectedItem.ToString();
                        _plObj.AssetCode = cmbAsset.SelectedItem.ToString();
                        _plObj.Qty = Convert.ToDecimal(txtDisQty.Text);
                        _plObj.DbType = "UPDATE";
                        dataTable = _blObj.BL_ExecuteTask(_plObj);
                    }
                    else
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "At least one row grid!!!", 2);
                        return;
                    }
                }
                if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Save successfully!!", 1);
                    dgvAdd.Visible = false;
                    dgvShowPickDetails.Visible = true;
                    dgvShowPickDetails.Height = 130;
                    dgvAdd.Height = 0;
                    //Clear();
                    frmRMPicklistGeneration_Load(null, null);
                   
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dataTable.Rows[0]["Msg"].ToString(), 3);
                    dgvAdd.Visible = false;
                    dgvShowPickDetails.Visible = true;
                    dgvShowPickDetails.Height = 130;
                    dgvAdd.Height = 0;
                    Clear();
                    frmRMPicklistGeneration_Load(null, null);
                }
            }

            catch (Exception ex)
            {

                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void dgvPicklist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                     dgvAdd.Visible = false;
                     dgvShowPickDetails.Visible = true;
                     dgvShowPickDetails.Height = 130;
                     dgvAdd.Height = 0;
                    _plObj = new PL_AssetMovement();
                    _blObj = new BL_AssetMovement();
                    _plObj.DocNo = dgvPicklist.Rows[e.RowIndex].Cells["DocNo"].Value.ToString();
                    _plObj.DbType = "GETPICKLISTDETAILS";
                    dtAddUpdateRunTime = _blObj.BL_ExecuteTask(_plObj);
                    dgvShowPickDetails.DataSource = dtAddUpdateRunTime;
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void txtPicklistSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvPicklist.DataSource as DataTable).DefaultView.RowFilter = string.Format("DocNo LIKE '%{0}%'", txtDocSearch.Text);
        }

        private void dgvShowPickDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvShowPickDetails.Columns["DeletePart"].Index && e.RowIndex >= 0) //make sure button index here
            {
                DataTable dt = new DataTable();
                DataGridViewRow row = dgvShowPickDetails.Rows[e.RowIndex];
                _plObj = new PL_AssetMovement();
                _blObj = new BL_AssetMovement();
                _plObj.DocNo = row.Cells["DocNo"].Value.ToString();
                _plObj.AssetCode = row.Cells["AssetCode"].Value.ToString();
                _plObj.DbType = "DELETE";
                 dt = _blObj.BL_ExecuteTask(_plObj);

                if (dt.Rows[0]["RESULT"].ToString() == "Y")
                {
                    _plObj.DocNo = row.Cells["DocNo"].Value.ToString();
                    _plObj.DbType = "GETPICKLISTDETAILS";
                    dt = _blObj.BL_ExecuteTask(_plObj);
                    dgvShowPickDetails.DataSource = dt;
                    BindGrid();
                    lblLastGeneratedDocNo.Text = "********************** ";
                    dtAdd.Clear();
                    dtAdd.AcceptChanges();
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, dt.Rows[0]["Msg"].ToString(), 2);
                    return;
                }
            }
        }

        private void dgvShowPickDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex <= -1)
                {
                    return;
                }
                Clear();
                lblLastGeneratedDocNo.Text = dgvShowPickDetails.Rows[e.RowIndex].Cells["DocNo1"].Value.ToString();
                cmbFromPlant.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["FromPlant"].Value.ToString();
                cmbFromFloor.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["FromFloor"].Value.ToString();
                cmbFromSection.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["FromSection"].Value.ToString();
                cmbToPlant.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["ToPlant"].Value.ToString();
                cmbTofloor.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["ToFloor"].Value.ToString();
                cmbToSection.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["ToSection"].Value.ToString();
                cmbAsset.SelectedItem = dgvShowPickDetails.Rows[e.RowIndex].Cells["AssetCode"].Value.ToString();
                txtDisQty.Text = dgvShowPickDetails.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                cmbFromPlant.Enabled= false;
                cmbFromFloor.Enabled= false;
                cmbFromSection.Enabled= false;
                cmbToPlant.Enabled= false;
                cmbTofloor.Enabled= false;
                cmbToSection.Enabled= false;
                cmbAsset.Enabled= false;
                btnAdd.Enabled= false;
                _IsUpdate = true;
                if (GlobalVariable.UserGroup.ToUpper() != "ADMIN")
                {
                    Common common = new Common();
                    common.SetModuleChildSectionRights(this.Text, _IsUpdate, btnSave);
                }
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void gbPrintingParameter_Enter(object sender, EventArgs e)
        {

        }

        private void cmbFromPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFromPlant.SelectedIndex > 0)
            {
                GetFromFloor(cmbFromPlant.SelectedItem.ToString());

            }
        }

        private void cmbToPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToPlant.SelectedIndex > 0)
            {
                GetToFloor(cmbToPlant.SelectedItem.ToString());

            }
        }

        private void cmbFromFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFromPlant.SelectedIndex > 0 && cmbFromFloor.SelectedIndex > 0)
            {
                GetFromSection(cmbFromPlant.SelectedItem.ToString(), cmbFromFloor.SelectedItem.ToString());

            }
        }

        private void cmbTofloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToPlant.SelectedIndex > 0 && cmbTofloor.SelectedIndex > 0)
            {
                GetToSection(cmbToPlant.SelectedItem.ToString(), cmbTofloor.SelectedItem.ToString());

            }
        }
    }
}
