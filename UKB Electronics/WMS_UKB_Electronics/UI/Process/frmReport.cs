
using SATO_PRINTING_BL;
using SATO_PRINTING_COMMON;
using SATO_PRINTING_PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WMS_UKB_Electronics
{
    public partial class frmReport : Form
    {

        #region Variables

        private BL_REPORT _blObj = null;
        private PL_REPORT _plObj = null;
        private Common _comObj = null;
        private string _packType = string.Empty;
        private DataTable dtBindGrid = new DataTable();
        DataTable dt;
        #endregion

        #region Form Methods

        public frmReport()
        {
            try
            {
                InitializeComponent();
                _blObj = new BL_REPORT();
                _plObj = new PL_REPORT();
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void frmReprinting_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                dpToDate_CloseUp(null, null);

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
                dpFromDate.Value = dpFromDate.Value = DateTime.Now;

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _plObj = new PL_REPORT();
                _plObj.DbType = "GET_BARCODE_DATA";
                _plObj.FromDate = dpFromDate.Value.ToString("yyyy-MM-dd");
                _plObj.ToDate = dpToDate.Value.ToString("yyyy-MM-dd");

                DateTime dt1 = Convert.ToDateTime(dpFromDate.Value.ToString("yyyy-MM-dd"));
                DateTime dt2 = Convert.ToDateTime(dpToDate.Value.ToString("yyyy-MM-dd"));

                int days = (dt2 - dt1).Days;
                if (days < 0)
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "To date should not be less than from date ", 2);
                    dpToDate.Value = DateTime.Now;
                    return;
                }

                if (cmbAsset.SelectedIndex > 0)
                {
                    _plObj.PartNo = cmbAsset.SelectedItem.ToString();
                }
                else
                {
                    _plObj.PartNo = "";
                }
                if (cmbPlant.SelectedIndex > 0)
                {
                    _plObj.LineNo = cmbPlant.SelectedItem.ToString();
                }
                else
                {
                    _plObj.LineNo = "";
                }
                if (rbtnProductQR.Checked)
                {
                    _plObj.RPT_Type = "P";
                }
                else if (rbtnMrpEAN.Checked)
                {
                    _plObj.RPT_Type = "M";
                }
                else
                {
                    _plObj.RPT_Type = "C";
                }

                dtBindGrid = _blObj.BL_ExecuteTask(_plObj);
                if (dtBindGrid.Rows.Count > 0)
                {
                    dgv.DataSource = dtBindGrid.DefaultView;
                    lblTotalCount.Text = "Total Count: " + dgv.RowCount.ToString();
                }
                else
                {
                    GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, "No Data Found !!!", 2);
                    dgv.DataSource = null;
                    lblTotalCount.Text = "Total Count: " + "0";
                }

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
        private void btnExport_Click(object sender, EventArgs e)
        {
            GlobalVariable.ExportInCSV(dgv);
        }
        #endregion

        #region Methods

        private void GetPartNo()
        {
            try
            {
                _plObj = new PL_REPORT();
                _plObj.DbType = "GET_PARTNO";
                _plObj.FromDate = dpFromDate.Value.ToString("yyyy-MM-dd");
                _plObj.ToDate = dpToDate.Value.ToString("yyyy-MM-dd");
                cmbAsset.Items.Clear();
                cmbAsset.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbAsset.Items.Add(row["ProductCode"].ToString());
                    }
                
                    cmbAsset.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        private void GetLine()
        {
            try
            {
                _plObj = new PL_REPORT();
                _plObj.DbType = "GET_LINE";
                _plObj.FromDate = dpFromDate.Value.ToString("yyyy-MM-dd");
                _plObj.ToDate = dpToDate.Value.ToString("yyyy-MM-dd");
                cmbPlant.Items.Clear();
                cmbPlant.Items.Add("--Select--");
                DataTable dt = _blObj.BL_ExecuteTask(_plObj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPlant.Items.Add(row["Line_No"].ToString());
                    }

                    cmbPlant.SelectedIndex = 0;
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
                dpToDate.Value = DateTime.Now;
                dpFromDate.Value = DateTime.Now;
                cmbAsset.SelectedIndex = -1;
                cmbPlant.SelectedIndex = -1;
                dgv.DataSource = null;
               
            }
            catch (Exception ex)
            {
                GlobalVariable.mStoCustomFunction.setMessageBox(GlobalVariable.mSatoApps, ex.Message, 3);
            }
        }

        #endregion

        #region TextBox Event
        private void dpToDate_CloseUp(object sender, EventArgs e)
        {
            Clear();
            GetPartNo();
            GetLine();
        }
        private void dpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void dpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        private void rbtnProductQR_Click(object sender, EventArgs e)
        {
            Clear();
            GetPartNo();
            GetLine();
        }

        private void rbtnMrpEAN_Click(object sender, EventArgs e)
        {
            Clear();
            GetPartNo();
            GetLine();
        }

        private void rbtnCartonEAN_Click(object sender, EventArgs e)
        {
            Clear();
            GetPartNo();
            GetLine();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells["Status"].Value.ToString()=="NG")
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
}
