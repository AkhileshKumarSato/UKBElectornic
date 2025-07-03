namespace WMS_UKB_Electronics
{
    partial class frmAssetMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssetMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.AssetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFID_Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.lblDec = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtPartSearch = new System.Windows.Forms.TextBox();
            this.lblSearchPart = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBrandType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPlant = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtRfidTag = new System.Windows.Forms.TextBox();
            this.lblRFIDTag = new System.Windows.Forms.Label();
            this.lblAssetCode = new System.Windows.Forms.Label();
            this.txtAssetCode = new System.Windows.Forms.TextBox();
            this.dgvUpload = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.Plant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asset_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFIDTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnDownloadFormat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssetID,
            this.PlantCode,
            this.Floor,
            this.Section,
            this.AssetCode,
            this.Description,
            this.RFID_Tag,
            this.Brand,
            this.CreatedBy,
            this.CreatedOn});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.AliceBlue;
            this.dgv.Location = new System.Drawing.Point(5, 202);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1225, 205);
            this.dgv.StandardTab = true;
            this.dgv.TabIndex = 187;
            this.dgv.TabStop = false;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // AssetID
            // 
            this.AssetID.DataPropertyName = "AssetID";
            this.AssetID.HeaderText = "AssetID";
            this.AssetID.Name = "AssetID";
            this.AssetID.ReadOnly = true;
            this.AssetID.Visible = false;
            // 
            // PlantCode
            // 
            this.PlantCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PlantCode.DataPropertyName = "PlantCode";
            this.PlantCode.HeaderText = "Plant";
            this.PlantCode.Name = "PlantCode";
            this.PlantCode.ReadOnly = true;
            this.PlantCode.Width = 110;
            // 
            // Floor
            // 
            this.Floor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Floor.DataPropertyName = "Floor";
            this.Floor.HeaderText = "Floor";
            this.Floor.Name = "Floor";
            this.Floor.ReadOnly = true;
            this.Floor.Width = 110;
            // 
            // Section
            // 
            this.Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            this.Section.Width = 120;
            // 
            // AssetCode
            // 
            this.AssetCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AssetCode.DataPropertyName = "AssetCode";
            this.AssetCode.HeaderText = "Asset Code";
            this.AssetCode.Name = "AssetCode";
            this.AssetCode.ReadOnly = true;
            this.AssetCode.Width = 130;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Decription";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 150;
            // 
            // RFID_Tag
            // 
            this.RFID_Tag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RFID_Tag.DataPropertyName = "RFID_Tag";
            this.RFID_Tag.HeaderText = "RFID Tag";
            this.RFID_Tag.Name = "RFID_Tag";
            this.RFID_Tag.ReadOnly = true;
            this.RFID_Tag.Width = 150;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "Make/Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 150;
            // 
            // CreatedBy
            // 
            this.CreatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "Created By";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            this.CreatedBy.Width = 130;
            // 
            // CreatedOn
            // 
            this.CreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreatedOn.DataPropertyName = "CreatedOn";
            this.CreatedOn.HeaderText = "Created On";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            // 
            // txtDec
            // 
            this.txtDec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDec.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtDec.Location = new System.Drawing.Point(488, 62);
            this.txtDec.MaxLength = 50;
            this.txtDec.Name = "txtDec";
            this.txtDec.Size = new System.Drawing.Size(247, 27);
            this.txtDec.TabIndex = 5;
            // 
            // lblDec
            // 
            this.lblDec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDec.AutoSize = true;
            this.lblDec.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblDec.Location = new System.Drawing.Point(395, 66);
            this.lblDec.Name = "lblDec";
            this.lblDec.Size = new System.Drawing.Size(84, 19);
            this.lblDec.TabIndex = 183;
            this.lblDec.Text = "Decription:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Calibri", 12F);
            this.lblCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblCount.Location = new System.Drawing.Point(6, 177);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(106, 19);
            this.lblCount.TabIndex = 182;
            this.lblCount.Text = "Rows Count : 0";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1250, 41);
            this.lblHeader.TabIndex = 212;
            this.lblHeader.Text = "ASSET MASTER";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtPartSearch);
            this.panel1.Controls.Add(this.lblSearchPart);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.dgvUpload);
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 480);
            this.panel1.TabIndex = 213;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(879, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 64);
            this.panel2.TabIndex = 248;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(5, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 47);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnReset.Location = new System.Drawing.Point(209, 5);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(67, 47);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnClose.Location = new System.Drawing.Point(277, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 47);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(73, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 47);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(72)))), ((int)(((byte)(146)))));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(141, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 47);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "&Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtPartSearch
            // 
            this.txtPartSearch.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtPartSearch.Location = new System.Drawing.Point(773, 172);
            this.txtPartSearch.Name = "txtPartSearch";
            this.txtPartSearch.Size = new System.Drawing.Size(457, 27);
            this.txtPartSearch.TabIndex = 8;
            this.txtPartSearch.TextChanged += new System.EventHandler(this.txtPartSearch_TextChanged);
            // 
            // lblSearchPart
            // 
            this.lblSearchPart.AutoSize = true;
            this.lblSearchPart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblSearchPart.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSearchPart.Location = new System.Drawing.Point(664, 175);
            this.lblSearchPart.Name = "lblSearchPart";
            this.lblSearchPart.Size = new System.Drawing.Size(103, 19);
            this.lblSearchPart.TabIndex = 191;
            this.lblSearchPart.Text = "Search Asset :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDownloadFormat);
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Controls.Add(this.txtBrandType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFloor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPlant);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.txtRfidTag);
            this.groupBox1.Controls.Add(this.lblRFIDTag);
            this.groupBox1.Controls.Add(this.lblAssetCode);
            this.groupBox1.Controls.Add(this.txtAssetCode);
            this.groupBox1.Controls.Add(this.txtDec);
            this.groupBox1.Controls.Add(this.lblDec);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 170);
            this.groupBox1.TabIndex = 193;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Details:";
            // 
            // txtBrandType
            // 
            this.txtBrandType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBrandType.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtBrandType.Location = new System.Drawing.Point(113, 92);
            this.txtBrandType.MaxLength = 50;
            this.txtBrandType.Name = "txtBrandType";
            this.txtBrandType.Size = new System.Drawing.Size(247, 27);
            this.txtBrandType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(5, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 271;
            this.label4.Text = "Make/Brand :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(753, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 269;
            this.label3.Text = "Select Section*:";
            // 
            // cmbSection
            // 
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(874, 26);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(247, 27);
            this.cmbSection.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(374, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 267;
            this.label2.Text = "Select Floor*:";
            // 
            // cmbFloor
            // 
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Location = new System.Drawing.Point(488, 26);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(247, 27);
            this.cmbFloor.TabIndex = 2;
            this.cmbFloor.SelectedIndexChanged += new System.EventHandler(this.cmbFloor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 265;
            this.label1.Text = "Select Plant*:";
            // 
            // cmbPlant
            // 
            this.cmbPlant.FormattingEnabled = true;
            this.cmbPlant.Location = new System.Drawing.Point(113, 23);
            this.cmbPlant.Name = "cmbPlant";
            this.cmbPlant.Size = new System.Drawing.Size(247, 27);
            this.cmbPlant.TabIndex = 1;
            this.cmbPlant.SelectedIndexChanged += new System.EventHandler(this.cmbPlant_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(1063, 130);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(145, 32);
            this.btnUpload.TabIndex = 14;
            this.btnUpload.Text = "Upload Asset";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtRfidTag
            // 
            this.txtRfidTag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtRfidTag.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtRfidTag.Location = new System.Drawing.Point(874, 59);
            this.txtRfidTag.MaxLength = 50;
            this.txtRfidTag.Name = "txtRfidTag";
            this.txtRfidTag.Size = new System.Drawing.Size(247, 27);
            this.txtRfidTag.TabIndex = 6;
            // 
            // lblRFIDTag
            // 
            this.lblRFIDTag.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRFIDTag.AutoSize = true;
            this.lblRFIDTag.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblRFIDTag.Location = new System.Drawing.Point(776, 62);
            this.lblRFIDTag.Name = "lblRFIDTag";
            this.lblRFIDTag.Size = new System.Drawing.Size(82, 19);
            this.lblRFIDTag.TabIndex = 226;
            this.lblRFIDTag.Text = "RFID Tag *:";
            // 
            // lblAssetCode
            // 
            this.lblAssetCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAssetCode.AutoSize = true;
            this.lblAssetCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblAssetCode.Location = new System.Drawing.Point(10, 62);
            this.lblAssetCode.Name = "lblAssetCode";
            this.lblAssetCode.Size = new System.Drawing.Size(103, 19);
            this.lblAssetCode.TabIndex = 199;
            this.lblAssetCode.Text = "Asset Code * :";
            // 
            // txtAssetCode
            // 
            this.txtAssetCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAssetCode.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtAssetCode.Location = new System.Drawing.Point(113, 59);
            this.txtAssetCode.MaxLength = 50;
            this.txtAssetCode.Name = "txtAssetCode";
            this.txtAssetCode.Size = new System.Drawing.Size(247, 27);
            this.txtAssetCode.TabIndex = 4;
            // 
            // dgvUpload
            // 
            this.dgvUpload.AllowUserToAddRows = false;
            this.dgvUpload.AllowUserToDeleteRows = false;
            this.dgvUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpload.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvUpload.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpload.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Plant,
            this.Floor_No,
            this.Section_No,
            this.Asset_Code,
            this.Desc,
            this.RFIDTag,
            this.Brand_Code,
            this.Error1,
            this.Error2,
            this.Error3});
            this.dgvUpload.EnableHeadersVisualStyles = false;
            this.dgvUpload.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvUpload.Location = new System.Drawing.Point(8, 202);
            this.dgvUpload.MultiSelect = false;
            this.dgvUpload.Name = "dgvUpload";
            this.dgvUpload.ReadOnly = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvUpload.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUpload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpload.Size = new System.Drawing.Size(1222, 205);
            this.dgvUpload.StandardTab = true;
            this.dgvUpload.TabIndex = 249;
            this.dgvUpload.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1196, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 214;
            this.label6.Text = "Minimize";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 215;
            this.pictureBox1.TabStop = false;
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
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1209, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 20);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // Plant
            // 
            this.Plant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Plant.DataPropertyName = "Plant";
            this.Plant.HeaderText = "Plant";
            this.Plant.Name = "Plant";
            this.Plant.ReadOnly = true;
            this.Plant.Width = 110;
            // 
            // Floor_No
            // 
            this.Floor_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Floor_No.DataPropertyName = "Floor_No";
            this.Floor_No.HeaderText = "Floor";
            this.Floor_No.Name = "Floor_No";
            this.Floor_No.ReadOnly = true;
            this.Floor_No.Width = 110;
            // 
            // Section_No
            // 
            this.Section_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Section_No.DataPropertyName = "Section_No";
            this.Section_No.HeaderText = "Section";
            this.Section_No.Name = "Section_No";
            this.Section_No.ReadOnly = true;
            this.Section_No.Width = 120;
            // 
            // Asset_Code
            // 
            this.Asset_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Asset_Code.DataPropertyName = "Asset_Code";
            this.Asset_Code.HeaderText = "Asset Code";
            this.Asset_Code.Name = "Asset_Code";
            this.Asset_Code.ReadOnly = true;
            this.Asset_Code.Width = 130;
            // 
            // Desc
            // 
            this.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Desc.DataPropertyName = "Desc";
            this.Desc.HeaderText = "Decription";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Width = 150;
            // 
            // RFIDTag
            // 
            this.RFIDTag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RFIDTag.DataPropertyName = "RFIDTag";
            this.RFIDTag.HeaderText = "RFID Tag";
            this.RFIDTag.Name = "RFIDTag";
            this.RFIDTag.ReadOnly = true;
            this.RFIDTag.Width = 150;
            // 
            // Brand_Code
            // 
            this.Brand_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Brand_Code.DataPropertyName = "Brand_Code";
            this.Brand_Code.HeaderText = "Make/Brand";
            this.Brand_Code.Name = "Brand_Code";
            this.Brand_Code.ReadOnly = true;
            this.Brand_Code.Width = 150;
            // 
            // Error1
            // 
            this.Error1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Error1.DataPropertyName = "Error1";
            this.Error1.HeaderText = "Error 1";
            this.Error1.Name = "Error1";
            this.Error1.ReadOnly = true;
            this.Error1.Width = 130;
            // 
            // Error2
            // 
            this.Error2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Error2.DataPropertyName = "Error2";
            this.Error2.HeaderText = "Error 2";
            this.Error2.Name = "Error2";
            this.Error2.ReadOnly = true;
            this.Error2.Width = 200;
            // 
            // Error3
            // 
            this.Error3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Error3.DataPropertyName = "Error3";
            this.Error3.HeaderText = "Error 3";
            this.Error3.Name = "Error3";
            this.Error3.ReadOnly = true;
            // 
            // lblPath
            // 
            this.lblPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblPath.Location = new System.Drawing.Point(817, 142);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(41, 19);
            this.lblPath.TabIndex = 272;
            this.lblPath.Text = "Path";
            // 
            // btnDownloadFormat
            // 
            this.btnDownloadFormat.Location = new System.Drawing.Point(1063, 92);
            this.btnDownloadFormat.Name = "btnDownloadFormat";
            this.btnDownloadFormat.Size = new System.Drawing.Size(145, 32);
            this.btnDownloadFormat.TabIndex = 250;
            this.btnDownloadFormat.Text = "Download Format";
            this.btnDownloadFormat.UseVisualStyleBackColor = true;
            this.btnDownloadFormat.Click += new System.EventHandler(this.btnDownloadFormat_Click);
            // 
            // frmAssetMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(194)))), ((int)(((byte)(191)))));
            this.ClientSize = new System.Drawing.Size(1250, 530);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAssetMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Master";
            this.Load += new System.EventHandler(this.frmModelMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.Label lblDec;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnMinimize;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPartSearch;
        private System.Windows.Forms.Label lblSearchPart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAssetCode;
        private System.Windows.Forms.TextBox txtAssetCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtRfidTag;
        private System.Windows.Forms.Label lblRFIDTag;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPlant;
        private System.Windows.Forms.TextBox txtBrandType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFID_Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridView dgvUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asset_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFIDTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error3;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnDownloadFormat;
    }
}