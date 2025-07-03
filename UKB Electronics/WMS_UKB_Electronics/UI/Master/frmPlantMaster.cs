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
    public partial class frmPlantMaster : Form
    {

        #region Variables

        private BL_PlantMaster _blObj = null;
        private PL_PlantMaster _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        DataTable dtAdd = new DataTable();
        DataTable dtAddUpdateRunTime = new DataTable();
        DataRow dr;
        private int rowIndex = 0;
        private bool _IsUpdate = false;
        string sID = "0";

        #endregion

        #region Form Methods

        public frmPlantMaster()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_PlantMaster();
                _plObj = new PL_PlantMaster();
                dtAdd.Columns.Add("Plant_Code");
                dtAdd.Columns.Add("Floor_Code");
                dtAdd.Columns.Add("Section_Code");
                dtAdd.Columns.Add("Location_Code");
                dtAdd.Columns.Add("Dpt_Code");
                dtAdd.Columns.Add("Desc");
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
                Clear();
                BindGrid();

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


        private void Clear()
        {
            try
            {
                txtPlant.Text = "";
                txtPicklistSearch.Text = "";
                txtFloor.Text = "";
                txtSection.Text = "";
                txtLocation.Text = "";
                txtDpt.Text = "";
                txtDesc.Text = "";
                txtPlant.Enabled = true;
                txtFloor.Enabled = true;
                txtSection.Enabled = true;
                txtLocation.Enabled = true;
                txtDpt.Enabled = true;
                btnAdd.Enabled = true;
                lblCount.Text = "Rows Count :0";
                dgvShow.Height = 500;
                dgvShow.Visible = true;
                sID = "0";
                dgvAdd.Visible = false;
                dgvAdd.Height = 0;
                _IsUpdate = false;
                dtAdd.Clear();
                txtPlant.Focus();

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
               if (txtPlant.Text=="")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please Enter Plant.", 3);
                    txtPlant.Focus();
                    return p;
                }
                if (txtFloor.Text == "")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please Enter Floor.", 3);
                    txtFloor.Focus();
                    return p;
                }
                if (txtSection.Text == "")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please Enter Section.", 3);
                    txtSection.Focus();
                    return p;
                }
                if (txtLocation.Text == "")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please Enter Location.", 3);
                    txtLocation.Focus();
                    return p;
                }
                if (txtDpt.Text == "")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please Enter Department.", 3);
                    txtDpt.Focus();
                    return p;
                }

            }
            return true;
        }

        private void BindGrid()
        {
            try
            {
                _plObj = new PL_PlantMaster();
                _blObj = new BL_PlantMaster();
                _plObj.DbType = "SELECT";
                dtBindGrid = _blObj.BL_ExecuteTask(_plObj);
                dgvShow.Height = 500;
                dgvShow.DataSource = dtBindGrid;
                lblCount.Text = "Rows Count : " + dgvShow.Rows.Count;
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
                    dgvShow.Visible = false;
                    dgvShow.Height = 0;
                    dgvAdd.Visible = true;
                    dgvAdd.Height = 500;
                    DataTable dt=  CheckDuplicate();
                    if (dt.Rows[0]["RESULT"].ToString() == "Y")
                    {
                        GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Plant (" + txtPlant.Text + ") Already Exist", 3);
                        ClearAdd();
                        return;
                    }
                    if (dtAdd.Rows.Count > 0)
                    {
                        string expression = "Plant_Code = '" + txtPlant.Text + "' and  Floor_Code ='" + txtFloor.Text + "' and Section_Code ='" + txtSection.Text + "'and Location_Code ='" + txtLocation.Text + "'and Dpt_Code ='" + txtDpt.Text + "'";
                       // DataRow[] foundAuthors = dtAdd.Select("Plant_Code = '" + txtPlant.Text + "' ");
                        DataRow[] foundAuthors = dtAdd.Select(expression);
                        if (foundAuthors.Length != 0)
                        {
                            GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Plant (" + txtPlant.Text + ") Already Exist", 3);
                            ClearAdd();
                        }
                        else
                        {
                            dr = dtAdd.NewRow();
                            dr["Plant_Code"] = txtPlant.Text;
                            dr["Floor_Code"] = txtFloor.Text;
                            dr["Section_Code"] = txtSection.Text;
                            dr["Location_Code"] = txtLocation.Text;
                            dr["Dpt_Code"] = txtDpt.Text;
                            dr["Desc"] = txtDesc.Text;
                            dtAdd.Rows.Add(dr);
                            dgvAdd.DataSource = dtAdd;
                            ClearAdd();
                        }
                    }
                    else
                    {
                        dr = dtAdd.NewRow();
                        dr["Plant_Code"] = txtPlant.Text;
                        dr["Floor_Code"] = txtFloor.Text;
                        dr["Section_Code"] = txtSection.Text;
                        dr["Location_Code"] = txtLocation.Text;
                        dr["Dpt_Code"] = txtDpt.Text;
                        dr["Desc"] = txtDesc.Text;
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

        private DataTable EditTable(DataTable dataTable)
        {
            var newTable = new DataTable();
            newTable = dataTable.Copy();
            foreach (DataRow row in newTable.Rows)
            {
                if (row[0].ToString().Length == 3)
                    row[0] = "00" + row[0].ToString();
            }
            return newTable;
        }

        private void ClearAdd()
        {
            txtPlant.Text = ""; ;
            txtFloor.Text = "";
            txtSection.Text = "";
            txtLocation.Text = "";
            txtDpt.Text = "";
            txtDesc.Text = "";
            // btnAdd.Enabled = false;
            lblCount.Text = "Rows Count : " + dgvAdd.Rows.Count;
            txtPlant.Focus();
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
                    if (dgvAdd.Rows.Count >= 0)
                    {
                       

                        for (int i = 0; i < dgvAdd.Rows.Count; i++)
                        {
                            _plObj = new PL_PlantMaster();
                            _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                            _plObj.PlantCode = dgvAdd.Rows[i].Cells["Plant_Code"].Value.ToString();
                            _plObj.Floor = dgvAdd.Rows[i].Cells["Floor_Code"].Value.ToString();
                            _plObj.Section = dgvAdd.Rows[i].Cells["Section_Code"].Value.ToString();
                            _plObj.Location = dgvAdd.Rows[i].Cells["Location_Code"].Value.ToString();
                            _plObj.Dept = dgvAdd.Rows[i].Cells["Dpt_Code"].Value.ToString();
                            _plObj.Desc = dgvAdd.Rows[i].Cells["Desc"].Value.ToString();
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

                    if (dgvShow.Rows.Count > 0)
                    {
                        _plObj = new PL_PlantMaster();
                        _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                        _plObj.PlantCode = txtPlant.Text;
                        _plObj.Floor = txtFloor.Text;
                        _plObj.Section = txtSection.Text;
                        _plObj.Location = txtLocation.Text;
                        _plObj.Dept = txtDpt.Text;
                        _plObj.Desc = txtDesc.Text;
                        _plObj.ID = sID;
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
                    dgvShow.Visible = true;
                    dgvShow.Height = 500;
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
     
        private void txtPicklistSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvShow.Rows.Count > 0)
                (dgvShow.DataSource as DataTable).DefaultView.RowFilter = string.Format("PlantCode LIKE '%{0}%'", txtPicklistSearch.Text);
        }

        private void dgvShowPickDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvShow.Columns["DeletePart"].Index && e.RowIndex >= 0) //make sure button index here
            {
                DataTable dt = new DataTable();
                DataGridViewRow row = dgvShow.Rows[e.RowIndex];
                _plObj = new PL_PlantMaster();
                _blObj = new BL_PlantMaster();
                _plObj.PlantCode = row.Cells["PlantCode"].Value.ToString();
                _plObj.Floor = row.Cells["Floor"].Value.ToString();
                _plObj.Section = row.Cells["Section"].Value.ToString();
                _plObj.Location = row.Cells["LocationCode"].Value.ToString();
                _plObj.Dept = row.Cells["DptCode"].Value.ToString();
                _plObj.ID = row.Cells["ID"].Value.ToString();
                _plObj.DbType = "DELETE";
                 dt = _blObj.BL_ExecuteTask(_plObj);

                if (dt.Rows[0]["RESULT"].ToString() == "Y")
                {
                    BindGrid();
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

        private DataTable CheckDuplicate()
        {
             DataTable dt = new DataTable();
            _plObj = new PL_PlantMaster();
            _blObj = new BL_PlantMaster();
            _plObj.PlantCode = txtPlant.Text;
            _plObj.Floor = txtFloor.Text;
            _plObj.Section = txtSection.Text;
            _plObj.Location =txtLocation.Text;
            _plObj.Dept = txtDpt.Text;
            _plObj.DbType = "CHECK_DUPLICATE";
            dt = _blObj.BL_ExecuteTask(_plObj);
            return dt;
           
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
                txtPlant.Text = dgvShow.Rows[e.RowIndex].Cells["PlantCode"].Value.ToString();
                txtFloor.Text= dgvShow.Rows[e.RowIndex].Cells["Floor"].Value.ToString();
                txtSection.Text = dgvShow.Rows[e.RowIndex].Cells["Section"].Value.ToString();
                txtLocation.Text = dgvShow.Rows[e.RowIndex].Cells["LocationCode"].Value.ToString();
                txtDpt.Text = dgvShow.Rows[e.RowIndex].Cells["DptCode"].Value.ToString();
                txtDesc.Text = dgvShow.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                sID = dgvShow.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtPlant.Enabled = false;
                txtFloor.Enabled=false;
                txtSection.Enabled = false;
                txtLocation.Enabled = false;
                txtDpt.Enabled = false;
                btnAdd.Enabled = false;
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

        private void gbPrintingParameter_Enter(object sender, EventArgs e)
        {

        }

        private void dgvAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAdd.Columns["Delete"].Index && e.RowIndex >= 0) //make sure button index here
            {
                DataGridViewRow row = dgvAdd.Rows[e.RowIndex];
                string Plant_Code = row.Cells["Plant_Code"].Value.ToString();
                string Floor_Code = row.Cells["Floor_Code"].Value.ToString();
                string Section_Code = row.Cells["Section_Code"].Value.ToString();
                string Location_Code = row.Cells["Location_Code"].Value.ToString();
                string Dpt_Code = row.Cells["Dpt_Code"].Value.ToString();
              
                for (int i = dtAdd.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtAdd.Rows[i];
                    if (dr["Plant_Code"].ToString() == Plant_Code && dr["Floor_Code"].ToString() == Floor_Code && dr["Section_Code"].ToString() == Section_Code && dr["Location_Code"].ToString() == Location_Code && dr["Dpt_Code"].ToString() == Dpt_Code)
                        dr.Delete();
                }
                dtAdd.AcceptChanges();
                dgvAdd.DataSource = dtAdd;
                lblCount.Text = "Rows Count : " + dgvAdd.Rows.Count;
            }
        }
    }
}
