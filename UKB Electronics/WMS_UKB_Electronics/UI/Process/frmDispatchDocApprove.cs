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
    public partial class frmDispatchDocApprove : Form
    {

        #region Variables

        private BL_AssetApprove _blObj = null;
        private PL_AssetApprove _plObj = null;
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

        public frmDispatchDocApprove()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_AssetApprove();
                _plObj = new PL_AssetApprove();
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
                GetPlant();
                BindGrid("");

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
                cmbPlant.Items.Clear();
                cmbPlant.Text = string.Empty;
                cmbPlant.DataSource = null;
                cmbDoc.Items.Clear();
                cmbDoc.Text = string.Empty;
                cmbDoc.DataSource = null;
                txtDocSearch.Text = "";
                rbtnExternalMovement.Checked = false;
                rbtnInternalMovement.Checked = true;
                lblCount.Text = "Rows Count :0";

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private bool ValidateInputs(bool p, string Mode)
        {
            if (cmbPlant.SelectedIndex == -1)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill plant", 3);
                cmbPlant.Focus();
                return p;
            }

           else if (cmbDoc.SelectedIndex == -1)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Please fill Doc No.", 3);
                cmbDoc.Focus();
                return p;
            }

            return true;
        }

        private void GetPlant()
        {
            try
            {
                _plObj = new PL_AssetApprove();
                _plObj.DbType = "GET_PLANT";
                cmbPlant.Items.Clear();
                cmbPlant.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
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

        private void GetDoc()
        {
            try
            {
                _plObj = new PL_AssetApprove();
                _plObj.Plant = cmbPlant.SelectedItem.ToString() ;
                _plObj.DbType = "GET_DOC_NO";
                cmbDoc.Items.Clear();
                cmbDoc.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbDoc.Items.Add(row["DocNo"].ToString());
                    }

                    cmbDoc.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }
        private void BindGrid(string Plant)
        {
            try
            {
                _plObj = new PL_AssetApprove();
                _blObj = new BL_AssetApprove();
                _plObj.DbType = "SELECT";
                _plObj.DocNo= Plant;
                dtBindGrid = _blObj.BL_ExecuteTask(_plObj);

                dgvShow.DataSource = dtBindGrid;
                lblCount.Text = "Rows Count : " + dgvShow.Rows.Count;
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }


        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dataTable = new DataTable();
                DialogResult MessResult = MessageBox.Show("Do You Really Want To Save.?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (MessResult == DialogResult.No)
                { return; }
                if (dgvShow.Rows.Count > 0)
                {

                    for (int i = 0; i < dgvShow.Rows.Count; i++)
                    {
                        _plObj = new PL_AssetApprove();
                        if (rbtnInternalMovement.Checked)
                        {
                            _plObj.MovementType = "Internal";
                        }
                        else
                        {
                            _plObj.MovementType = "External";
                        }
                        _plObj.DocNo=cmbDoc.SelectedItem.ToString();
                        _plObj.CreatedBy = GlobalVariable.mSatoAppsLoginUser;
                        _plObj.Plant = dgvShow.Rows[i].Cells["FromPlant"].Value.ToString();
                        _plObj.AssetCode = dgvShow.Rows[i].Cells["AssetCode"].Value.ToString();
                        _plObj.Qty = Convert.ToDecimal(dgvShow.Rows[i].Cells["Qty"].Value.ToString());
                        _plObj.DbType = "INSERT";
                        dataTable = _blObj.BL_ExecuteTask(_plObj);

                    }
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "At least one row grid!!!", 2);
                    return;
                }
                if (dataTable.Rows[0]["RESULT"].ToString() == "Y")
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "Save successfully!!", 1);
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
            (dgvShow.DataSource as DataTable).DefaultView.RowFilter = string.Format("AssetCode LIKE '%{0}%'", txtDocSearch.Text);
        }

       

        private void rbtnExternalMovement_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnInternalMovement_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlant.SelectedIndex>0)
            {
                GetDoc();
            }
        }

        private void cmbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoc.SelectedIndex>0)
            { BindGrid(cmbDoc.SelectedItem.ToString()); }
           
        }
    }
}
