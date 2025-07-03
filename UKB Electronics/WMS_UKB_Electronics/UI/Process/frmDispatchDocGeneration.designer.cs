namespace WMS_UKB_Electronics
{
    partial class frmDispatchDocGeneration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDispatchDocGeneration));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.gbPrintingParameter = new System.Windows.Forms.GroupBox();
            this.cmbToSection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFromSection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTofloor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFromFloor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbToPlant = new System.Windows.Forms.ComboBox();
            this.lblToPlant = new System.Windows.Forms.Label();
            this.cmbFromPlant = new System.Windows.Forms.ComboBox();
            this.lblLastGeneratedDocNo = new System.Windows.Forms.Label();
            this.lblCurrentBarcode = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDisQty = new System.Windows.Forms.TextBox();
            this.lblDispatchQty = new System.Windows.Forms.Label();
            this.lblAsset = new System.Windows.Forms.Label();
            this.cmbAsset = new System.Windows.Forms.ComboBox();
            this.lblFromPlant = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvShowPickDetails = new System.Windows.Forms.DataGridView();
            this.DocNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromFloor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToFloor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeletePart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtDocSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPicklist = new System.Windows.Forms.DataGridView();
            this.IsValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAdd = new System.Windows.Forms.DataGridView();
            this.From_Plant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From_Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From_Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_Plant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asset_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asset_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbPrintingParameter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowPickDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(90, 8);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 47);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "R&eset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnClose.Image = global::WMS_UKB_Electronics.Properties.Resources.Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(166, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackColor = System.Drawing.Color.Transparent;
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMini.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnMini.Image = ((System.Drawing.Image)(resources.GetObject("btnMini.Image")));
            this.btnMini.Location = new System.Drawing.Point(1137, 3);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(29, 22);
            this.btnMini.TabIndex = 210;
            this.btnMini.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // gbPrintingParameter
            // 
            this.gbPrintingParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrintingParameter.Controls.Add(this.cmbToSection);
            this.gbPrintingParameter.Controls.Add(this.label4);
            this.gbPrintingParameter.Controls.Add(this.cmbFromSection);
            this.gbPrintingParameter.Controls.Add(this.label6);
            this.gbPrintingParameter.Controls.Add(this.cmbTofloor);
            this.gbPrintingParameter.Controls.Add(this.label1);
            this.gbPrintingParameter.Controls.Add(this.cmbFromFloor);
            this.gbPrintingParameter.Controls.Add(this.label2);
            this.gbPrintingParameter.Controls.Add(this.cmbToPlant);
            this.gbPrintingParameter.Controls.Add(this.lblToPlant);
            this.gbPrintingParameter.Controls.Add(this.cmbFromPlant);
            this.gbPrintingParameter.Controls.Add(this.lblLastGeneratedDocNo);
            this.gbPrintingParameter.Controls.Add(this.lblCurrentBarcode);
            this.gbPrintingParameter.Controls.Add(this.btnAdd);
            this.gbPrintingParameter.Controls.Add(this.txtDisQty);
            this.gbPrintingParameter.Controls.Add(this.lblDispatchQty);
            this.gbPrintingParameter.Controls.Add(this.lblAsset);
            this.gbPrintingParameter.Controls.Add(this.cmbAsset);
            this.gbPrintingParameter.Controls.Add(this.lblFromPlant);
            this.gbPrintingParameter.Controls.Add(this.panel2);
            this.gbPrintingParameter.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbPrintingParameter.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbPrintingParameter.Location = new System.Drawing.Point(3, 3);
            this.gbPrintingParameter.Name = "gbPrintingParameter";
            this.gbPrintingParameter.Size = new System.Drawing.Size(1164, 200);
            this.gbPrintingParameter.TabIndex = 193;
            this.gbPrintingParameter.TabStop = false;
            this.gbPrintingParameter.Text = "Doc";
            this.gbPrintingParameter.Enter += new System.EventHandler(this.gbPrintingParameter_Enter);
            // 
            // cmbToSection
            // 
            this.cmbToSection.FormattingEnabled = true;
            this.cmbToSection.Location = new System.Drawing.Point(718, 57);
            this.cmbToSection.Name = "cmbToSection";
            this.cmbToSection.Size = new System.Drawing.Size(166, 27);
            this.cmbToSection.TabIndex = 247;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(617, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 246;
            this.label4.Text = "To Section *:";
            // 
            // cmbFromSection
            // 
            this.cmbFromSection.FormattingEnabled = true;
            this.cmbFromSection.Location = new System.Drawing.Point(718, 23);
            this.cmbFromSection.Name = "cmbFromSection";
            this.cmbFromSection.Size = new System.Drawing.Size(166, 27);
            this.cmbFromSection.TabIndex = 245;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(598, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 19);
            this.label6.TabIndex = 244;
            this.label6.Text = "From Section *:";
            // 
            // cmbTofloor
            // 
            this.cmbTofloor.FormattingEnabled = true;
            this.cmbTofloor.Location = new System.Drawing.Point(430, 56);
            this.cmbTofloor.Name = "cmbTofloor";
            this.cmbTofloor.Size = new System.Drawing.Size(157, 27);
            this.cmbTofloor.TabIndex = 243;
            this.cmbTofloor.SelectedIndexChanged += new System.EventHandler(this.cmbTofloor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 242;
            this.label1.Text = "To floor *:";
            // 
            // cmbFromFloor
            // 
            this.cmbFromFloor.FormattingEnabled = true;
            this.cmbFromFloor.Location = new System.Drawing.Point(430, 22);
            this.cmbFromFloor.Name = "cmbFromFloor";
            this.cmbFromFloor.Size = new System.Drawing.Size(157, 27);
            this.cmbFromFloor.TabIndex = 241;
            this.cmbFromFloor.SelectedIndexChanged += new System.EventHandler(this.cmbFromFloor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 240;
            this.label2.Text = "From floor *:";
            // 
            // cmbToPlant
            // 
            this.cmbToPlant.FormattingEnabled = true;
            this.cmbToPlant.Location = new System.Drawing.Point(137, 60);
            this.cmbToPlant.Name = "cmbToPlant";
            this.cmbToPlant.Size = new System.Drawing.Size(165, 27);
            this.cmbToPlant.TabIndex = 239;
            this.cmbToPlant.SelectedIndexChanged += new System.EventHandler(this.cmbToPlant_SelectedIndexChanged);
            // 
            // lblToPlant
            // 
            this.lblToPlant.AutoSize = true;
            this.lblToPlant.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToPlant.Location = new System.Drawing.Point(45, 64);
            this.lblToPlant.Name = "lblToPlant";
            this.lblToPlant.Size = new System.Drawing.Size(81, 19);
            this.lblToPlant.TabIndex = 238;
            this.lblToPlant.Text = "To Plant *:";
            // 
            // cmbFromPlant
            // 
            this.cmbFromPlant.FormattingEnabled = true;
            this.cmbFromPlant.Location = new System.Drawing.Point(137, 22);
            this.cmbFromPlant.Name = "cmbFromPlant";
            this.cmbFromPlant.Size = new System.Drawing.Size(166, 27);
            this.cmbFromPlant.TabIndex = 237;
            this.cmbFromPlant.SelectedIndexChanged += new System.EventHandler(this.cmbFromPlant_SelectedIndexChanged);
            // 
            // lblLastGeneratedDocNo
            // 
            this.lblLastGeneratedDocNo.BackColor = System.Drawing.Color.Yellow;
            this.lblLastGeneratedDocNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblLastGeneratedDocNo.Location = new System.Drawing.Point(153, 171);
            this.lblLastGeneratedDocNo.Name = "lblLastGeneratedDocNo";
            this.lblLastGeneratedDocNo.Size = new System.Drawing.Size(434, 21);
            this.lblLastGeneratedDocNo.TabIndex = 232;
            this.lblLastGeneratedDocNo.Text = "********************** ";
            // 
            // lblCurrentBarcode
            // 
            this.lblCurrentBarcode.AutoSize = true;
            this.lblCurrentBarcode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentBarcode.Location = new System.Drawing.Point(6, 173);
            this.lblCurrentBarcode.Name = "lblCurrentBarcode";
            this.lblCurrentBarcode.Size = new System.Drawing.Size(143, 19);
            this.lblCurrentBarcode.TabIndex = 231;
            this.lblCurrentBarcode.Text = "Generated Doc No.:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(897, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 47);
            this.btnAdd.TabIndex = 217;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDisQty
            // 
            this.txtDisQty.Location = new System.Drawing.Point(137, 97);
            this.txtDisQty.Name = "txtDisQty";
            this.txtDisQty.Size = new System.Drawing.Size(166, 27);
            this.txtDisQty.TabIndex = 216;
            this.txtDisQty.Text = "0";
            this.txtDisQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPickQty_KeyPress);
            // 
            // lblDispatchQty
            // 
            this.lblDispatchQty.AutoSize = true;
            this.lblDispatchQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDispatchQty.Location = new System.Drawing.Point(79, 100);
            this.lblDispatchQty.Name = "lblDispatchQty";
            this.lblDispatchQty.Size = new System.Drawing.Size(46, 19);
            this.lblDispatchQty.TabIndex = 214;
            this.lblDispatchQty.Text = "Qty*:";
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsset.Location = new System.Drawing.Point(367, 102);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(57, 19);
            this.lblAsset.TabIndex = 212;
            this.lblAsset.Text = "Asset*:";
            // 
            // cmbAsset
            // 
            this.cmbAsset.FormattingEnabled = true;
            this.cmbAsset.Location = new System.Drawing.Point(430, 97);
            this.cmbAsset.Name = "cmbAsset";
            this.cmbAsset.Size = new System.Drawing.Size(454, 27);
            this.cmbAsset.TabIndex = 211;
            // 
            // lblFromPlant
            // 
            this.lblFromPlant.AutoSize = true;
            this.lblFromPlant.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromPlant.Location = new System.Drawing.Point(31, 26);
            this.lblFromPlant.Name = "lblFromPlant";
            this.lblFromPlant.Size = new System.Drawing.Size(100, 19);
            this.lblFromPlant.TabIndex = 210;
            this.lblFromPlant.Text = "From Plant *:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(875, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 64);
            this.panel2.TabIndex = 195;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(15, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 47);
            this.btnSave.TabIndex = 206;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1184, 41);
            this.lblHeader.TabIndex = 212;
            this.lblHeader.Text = "Asset Movement";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnMinimize.Location = new System.Drawing.Point(1146, -72);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 32);
            this.btnMinimize.TabIndex = 211;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvShowPickDetails);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.txtDocSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvPicklist);
            this.panel1.Controls.Add(this.dgvAdd);
            this.panel1.Controls.Add(this.gbPrintingParameter);
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 514);
            this.panel1.TabIndex = 213;
            // 
            // dgvShowPickDetails
            // 
            this.dgvShowPickDetails.AllowUserToAddRows = false;
            this.dgvShowPickDetails.AllowUserToDeleteRows = false;
            this.dgvShowPickDetails.AllowUserToResizeRows = false;
            this.dgvShowPickDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShowPickDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowPickDetails.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvShowPickDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Garamond", 12.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowPickDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowPickDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowPickDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocNo1,
            this.FromPlant,
            this.FromFloor,
            this.FromSection,
            this.ToPlant,
            this.ToFloor,
            this.ToSection,
            this.AssetCode,
            this.Qty,
            this.DeletePart});
            this.dgvShowPickDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvShowPickDetails.EnableHeadersVisualStyles = false;
            this.dgvShowPickDetails.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvShowPickDetails.Location = new System.Drawing.Point(3, 243);
            this.dgvShowPickDetails.MultiSelect = false;
            this.dgvShowPickDetails.Name = "dgvShowPickDetails";
            this.dgvShowPickDetails.ReadOnly = true;
            this.dgvShowPickDetails.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvShowPickDetails.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowPickDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowPickDetails.Size = new System.Drawing.Size(1161, 140);
            this.dgvShowPickDetails.StandardTab = true;
            this.dgvShowPickDetails.TabIndex = 222;
            this.dgvShowPickDetails.TabStop = false;
            this.dgvShowPickDetails.Visible = false;
            this.dgvShowPickDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowPickDetails_CellContentClick);
            this.dgvShowPickDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowPickDetails_CellDoubleClick);
            // 
            // DocNo1
            // 
            this.DocNo1.DataPropertyName = "DocNo1";
            this.DocNo1.HeaderText = "Doc No.";
            this.DocNo1.Name = "DocNo1";
            this.DocNo1.ReadOnly = true;
            this.DocNo1.Visible = false;
            // 
            // FromPlant
            // 
            this.FromPlant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FromPlant.DataPropertyName = "FromPlant";
            this.FromPlant.HeaderText = "From Plant";
            this.FromPlant.Name = "FromPlant";
            this.FromPlant.ReadOnly = true;
            this.FromPlant.Width = 120;
            // 
            // FromFloor
            // 
            this.FromFloor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FromFloor.DataPropertyName = "FromFloor";
            this.FromFloor.HeaderText = "From floor";
            this.FromFloor.Name = "FromFloor";
            this.FromFloor.ReadOnly = true;
            this.FromFloor.Width = 130;
            // 
            // FromSection
            // 
            this.FromSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FromSection.DataPropertyName = "FromSection";
            this.FromSection.HeaderText = "From Section";
            this.FromSection.Name = "FromSection";
            this.FromSection.ReadOnly = true;
            this.FromSection.Width = 130;
            // 
            // ToPlant
            // 
            this.ToPlant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToPlant.DataPropertyName = "ToPlant";
            this.ToPlant.HeaderText = "To Plant";
            this.ToPlant.Name = "ToPlant";
            this.ToPlant.ReadOnly = true;
            this.ToPlant.Width = 120;
            // 
            // ToFloor
            // 
            this.ToFloor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToFloor.DataPropertyName = "ToFloor";
            this.ToFloor.HeaderText = "To Floor";
            this.ToFloor.Name = "ToFloor";
            this.ToFloor.ReadOnly = true;
            this.ToFloor.Width = 120;
            // 
            // ToSection
            // 
            this.ToSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToSection.DataPropertyName = "ToSection";
            this.ToSection.HeaderText = "To Section";
            this.ToSection.Name = "ToSection";
            this.ToSection.ReadOnly = true;
            this.ToSection.Width = 120;
            // 
            // AssetCode
            // 
            this.AssetCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AssetCode.DataPropertyName = "AssetCode";
            this.AssetCode.HeaderText = "Asset Code";
            this.AssetCode.Name = "AssetCode";
            this.AssetCode.ReadOnly = true;
            this.AssetCode.Width = 120;
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Disp Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // DeletePart
            // 
            this.DeletePart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeletePart.DataPropertyName = "DeletePart";
            this.DeletePart.HeaderText = "Delete";
            this.DeletePart.Name = "DeletePart";
            this.DeletePart.ReadOnly = true;
            this.DeletePart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeletePart.Text = "Delete";
            this.DeletePart.UseColumnTextForButtonValue = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(11, 215);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(106, 19);
            this.lblCount.TabIndex = 221;
            this.lblCount.Text = "Rows Count :0";
            // 
            // txtDocSearch
            // 
            this.txtDocSearch.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtDocSearch.Location = new System.Drawing.Point(692, 209);
            this.txtDocSearch.Name = "txtDocSearch";
            this.txtDocSearch.Size = new System.Drawing.Size(469, 27);
            this.txtDocSearch.TabIndex = 198;
            this.txtDocSearch.TextChanged += new System.EventHandler(this.txtPicklistSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(563, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 19);
            this.label3.TabIndex = 199;
            this.label3.Text = "Search Doc  No. :";
            // 
            // dgvPicklist
            // 
            this.dgvPicklist.AllowUserToAddRows = false;
            this.dgvPicklist.AllowUserToDeleteRows = false;
            this.dgvPicklist.AllowUserToResizeRows = false;
            this.dgvPicklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPicklist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPicklist.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvPicklist.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Garamond", 12.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPicklist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPicklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPicklist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsValid,
            this.DocNo,
            this.CreatedBy,
            this.CreatedOn});
            this.dgvPicklist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvPicklist.EnableHeadersVisualStyles = false;
            this.dgvPicklist.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvPicklist.Location = new System.Drawing.Point(2, 389);
            this.dgvPicklist.MultiSelect = false;
            this.dgvPicklist.Name = "dgvPicklist";
            this.dgvPicklist.ReadOnly = true;
            this.dgvPicklist.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvPicklist.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPicklist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPicklist.Size = new System.Drawing.Size(1162, 256);
            this.dgvPicklist.StandardTab = true;
            this.dgvPicklist.TabIndex = 195;
            this.dgvPicklist.TabStop = false;
            this.dgvPicklist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPicklist_CellContentClick);
            // 
            // IsValid
            // 
            this.IsValid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsValid.DataPropertyName = "IsValid";
            this.IsValid.HeaderText = "IsValid";
            this.IsValid.Name = "IsValid";
            this.IsValid.ReadOnly = true;
            this.IsValid.Width = 70;
            // 
            // DocNo
            // 
            this.DocNo.DataPropertyName = "DocNo";
            this.DocNo.HeaderText = "Doc No.";
            this.DocNo.Name = "DocNo";
            this.DocNo.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "Created By";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            this.CreatedOn.HeaderText = "Created On";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            // 
            // dgvAdd
            // 
            this.dgvAdd.AllowUserToAddRows = false;
            this.dgvAdd.AllowUserToDeleteRows = false;
            this.dgvAdd.AllowUserToResizeRows = false;
            this.dgvAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdd.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvAdd.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Garamond", 12.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.From_Plant,
            this.From_Floor,
            this.From_Section,
            this.To_Plant,
            this.To_Floor,
            this.To_Section,
            this.Asset_Code,
            this.Asset_Qty,
            this.Delete});
            this.dgvAdd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvAdd.EnableHeadersVisualStyles = false;
            this.dgvAdd.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvAdd.Location = new System.Drawing.Point(3, 243);
            this.dgvAdd.MultiSelect = false;
            this.dgvAdd.Name = "dgvAdd";
            this.dgvAdd.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvAdd.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdd.Size = new System.Drawing.Size(1161, 140);
            this.dgvAdd.StandardTab = true;
            this.dgvAdd.TabIndex = 194;
            this.dgvAdd.TabStop = false;
            this.dgvAdd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdd_CellContentClick);
            // 
            // From_Plant
            // 
            this.From_Plant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.From_Plant.DataPropertyName = "From_Plant";
            this.From_Plant.HeaderText = "From Plant";
            this.From_Plant.Name = "From_Plant";
            this.From_Plant.Width = 130;
            // 
            // From_Floor
            // 
            this.From_Floor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.From_Floor.DataPropertyName = "From_Floor";
            this.From_Floor.HeaderText = "From Floor";
            this.From_Floor.Name = "From_Floor";
            this.From_Floor.Width = 130;
            // 
            // From_Section
            // 
            this.From_Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.From_Section.DataPropertyName = "From_Section";
            this.From_Section.HeaderText = "From Section";
            this.From_Section.Name = "From_Section";
            this.From_Section.Width = 130;
            // 
            // To_Plant
            // 
            this.To_Plant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.To_Plant.DataPropertyName = "To_Plant";
            this.To_Plant.HeaderText = "To Plant";
            this.To_Plant.Name = "To_Plant";
            this.To_Plant.Width = 120;
            // 
            // To_Floor
            // 
            this.To_Floor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.To_Floor.DataPropertyName = "To_Floor";
            this.To_Floor.HeaderText = "To Floor";
            this.To_Floor.Name = "To_Floor";
            this.To_Floor.ReadOnly = true;
            this.To_Floor.Width = 120;
            // 
            // To_Section
            // 
            this.To_Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.To_Section.DataPropertyName = "To_Section";
            this.To_Section.HeaderText = "To Section";
            this.To_Section.Name = "To_Section";
            this.To_Section.Width = 120;
            // 
            // Asset_Code
            // 
            this.Asset_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Asset_Code.DataPropertyName = "Asset_Code";
            this.Asset_Code.HeaderText = "Asset Code";
            this.Asset_Code.Name = "Asset_Code";
            this.Asset_Code.Width = 130;
            // 
            // Asset_Qty
            // 
            this.Asset_Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Asset_Qty.DataPropertyName = "Asset_Qty";
            this.Asset_Qty.HeaderText = "Qty";
            this.Asset_Qty.Name = "Asset_Qty";
            this.Asset_Qty.Width = 120;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delete.DataPropertyName = "Delete";
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1126, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 214;
            this.label5.Text = "Minimize";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 262;
            this.pictureBox1.TabStop = false;
            // 
            // frmDispatchDocGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(194)))), ((int)(((byte)(191)))));
            this.ClientSize = new System.Drawing.Size(1184, 560);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDispatchDocGeneration";
            this.Text = "Dispatch Doc Generation";
            this.Load += new System.EventHandler(this.frmRMPicklistGeneration_Load);
            this.gbPrintingParameter.ResumeLayout(false);
            this.gbPrintingParameter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowPickDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.GroupBox gbPrintingParameter;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFromPlant;
        private System.Windows.Forms.Label lblAsset;
        private System.Windows.Forms.ComboBox cmbAsset;
        private System.Windows.Forms.Label lblDispatchQty;
        private System.Windows.Forms.TextBox txtDisQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvPicklist;
        private System.Windows.Forms.TextBox txtDocSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblLastGeneratedDocNo;
        private System.Windows.Forms.Label lblCurrentBarcode;
        private System.Windows.Forms.DataGridView dgvShowPickDetails;
        private System.Windows.Forms.ComboBox cmbFromPlant;
        private System.Windows.Forms.ComboBox cmbToPlant;
        private System.Windows.Forms.Label lblToPlant;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsValid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.ComboBox cmbToSection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFromSection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTofloor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFromFloor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromFloor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToFloor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewButtonColumn DeletePart;
        private System.Windows.Forms.DataGridViewTextBoxColumn From_Plant;
        private System.Windows.Forms.DataGridViewTextBoxColumn From_Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn From_Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_Plant;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asset_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asset_Qty;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}