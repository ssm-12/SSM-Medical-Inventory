namespace medicalInventory
{
    partial class buyerDetails
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuyerName = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblBuyerAdd1 = new System.Windows.Forms.Label();
            this.lblBuyerAdd2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.txtBuyerContact = new System.Windows.Forms.TextBox();
            this.txtBuyerAddr1 = new System.Windows.Forms.TextBox();
            this.txtBuyerAddr2 = new System.Windows.Forms.TextBox();
            this.txtBuyerDL = new System.Windows.Forms.TextBox();
            this.txtBuyerTIN = new System.Windows.Forms.TextBox();
            this.txtBuyerEmail = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdBuyerDetails = new System.Windows.Forms.DataGridView();
            this.dB_SSM_Medical_InventoryDataSet = new medicalInventory.DB_SSM_Medical_InventoryDataSet();
            this.customermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customer_masterTableAdapter = new medicalInventory.DB_SSM_Medical_InventoryDataSetTableAdapters.customer_masterTableAdapter();
            this.custidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dLnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tINnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressline1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressline2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuyerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_SSM_Medical_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customermasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(500, 50);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1022, 432);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMsg);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1014, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Buyer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSubmit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(394, 218);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(499, 47);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(3, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(243, 41);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Save Details";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(252, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(244, 41);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBuyerName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblContact, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBuyerAdd1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBuyerAdd2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerContact, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerAddr1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerAddr2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerDL, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerTIN, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBuyerEmail, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(121, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.23077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 191);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(766, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buyer Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBuyerName
            // 
            this.lblBuyerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuyerName.AutoSize = true;
            this.lblBuyerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerName.Location = new System.Drawing.Point(3, 45);
            this.lblBuyerName.Name = "lblBuyerName";
            this.lblBuyerName.Size = new System.Drawing.Size(83, 36);
            this.lblBuyerName.TabIndex = 1;
            this.lblBuyerName.Text = "Buyer Name";
            this.lblBuyerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContact
            // 
            this.lblContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(388, 45);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(77, 36);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Contact No.";
            this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyerAdd1
            // 
            this.lblBuyerAdd1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuyerAdd1.AutoSize = true;
            this.lblBuyerAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerAdd1.Location = new System.Drawing.Point(3, 81);
            this.lblBuyerAdd1.Name = "lblBuyerAdd1";
            this.lblBuyerAdd1.Size = new System.Drawing.Size(94, 36);
            this.lblBuyerAdd1.TabIndex = 1;
            this.lblBuyerAdd1.Text = "Address Line1";
            this.lblBuyerAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyerAdd2
            // 
            this.lblBuyerAdd2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuyerAdd2.AutoSize = true;
            this.lblBuyerAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerAdd2.Location = new System.Drawing.Point(388, 81);
            this.lblBuyerAdd2.Name = "lblBuyerAdd2";
            this.lblBuyerAdd2.Size = new System.Drawing.Size(94, 36);
            this.lblBuyerAdd2.TabIndex = 1;
            this.lblBuyerAdd2.Text = "Address Line2";
            this.lblBuyerAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 36);
            this.label6.TabIndex = 1;
            this.label6.Text = "DL No.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(388, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 36);
            this.label7.TabIndex = 1;
            this.label7.Text = "TIN No.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 38);
            this.label8.TabIndex = 1;
            this.label8.Text = "Email ID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerName.Location = new System.Drawing.Point(157, 48);
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.Size = new System.Drawing.Size(225, 22);
            this.txtBuyerName.TabIndex = 2;
            // 
            // txtBuyerContact
            // 
            this.txtBuyerContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerContact.Location = new System.Drawing.Point(542, 48);
            this.txtBuyerContact.Name = "txtBuyerContact";
            this.txtBuyerContact.Size = new System.Drawing.Size(227, 22);
            this.txtBuyerContact.TabIndex = 2;
            // 
            // txtBuyerAddr1
            // 
            this.txtBuyerAddr1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerAddr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerAddr1.Location = new System.Drawing.Point(157, 84);
            this.txtBuyerAddr1.Name = "txtBuyerAddr1";
            this.txtBuyerAddr1.Size = new System.Drawing.Size(225, 22);
            this.txtBuyerAddr1.TabIndex = 2;
            // 
            // txtBuyerAddr2
            // 
            this.txtBuyerAddr2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerAddr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerAddr2.Location = new System.Drawing.Point(542, 84);
            this.txtBuyerAddr2.Name = "txtBuyerAddr2";
            this.txtBuyerAddr2.Size = new System.Drawing.Size(227, 22);
            this.txtBuyerAddr2.TabIndex = 2;
            // 
            // txtBuyerDL
            // 
            this.txtBuyerDL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerDL.Location = new System.Drawing.Point(157, 120);
            this.txtBuyerDL.Name = "txtBuyerDL";
            this.txtBuyerDL.Size = new System.Drawing.Size(225, 22);
            this.txtBuyerDL.TabIndex = 2;
            // 
            // txtBuyerTIN
            // 
            this.txtBuyerTIN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerTIN.Location = new System.Drawing.Point(542, 120);
            this.txtBuyerTIN.Name = "txtBuyerTIN";
            this.txtBuyerTIN.Size = new System.Drawing.Size(227, 22);
            this.txtBuyerTIN.TabIndex = 2;
            // 
            // txtBuyerEmail
            // 
            this.txtBuyerEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerEmail.Location = new System.Drawing.Point(157, 156);
            this.txtBuyerEmail.Name = "txtBuyerEmail";
            this.txtBuyerEmail.Size = new System.Drawing.Size(225, 22);
            this.txtBuyerEmail.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdBuyerDetails);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1014, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit/Remove Buyer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(228, 249);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(11, 13);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buyer Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdBuyerDetails
            // 
            this.grdBuyerDetails.AllowUserToAddRows = false;
            this.grdBuyerDetails.AutoGenerateColumns = false;
            this.grdBuyerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBuyerDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.custidDataGridViewTextBoxColumn,
            this.custnameDataGridViewTextBoxColumn,
            this.dLnoDataGridViewTextBoxColumn,
            this.tINnoDataGridViewTextBoxColumn,
            this.addressline1DataGridViewTextBoxColumn,
            this.addressline2DataGridViewTextBoxColumn,
            this.contactnoDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.grdBuyerDetails.DataSource = this.customermasterBindingSource;
            this.grdBuyerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBuyerDetails.Location = new System.Drawing.Point(3, 25);
            this.grdBuyerDetails.Name = "grdBuyerDetails";
            this.grdBuyerDetails.Size = new System.Drawing.Size(1008, 346);
            this.grdBuyerDetails.TabIndex = 2;
            // 
            // dB_SSM_Medical_InventoryDataSet
            // 
            this.dB_SSM_Medical_InventoryDataSet.DataSetName = "DB_SSM_Medical_InventoryDataSet";
            this.dB_SSM_Medical_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customermasterBindingSource
            // 
            this.customermasterBindingSource.DataMember = "customer_master";
            this.customermasterBindingSource.DataSource = this.dB_SSM_Medical_InventoryDataSet;
            // 
            // customer_masterTableAdapter
            // 
            this.customer_masterTableAdapter.ClearBeforeFill = true;
            // 
            // custidDataGridViewTextBoxColumn
            // 
            this.custidDataGridViewTextBoxColumn.DataPropertyName = "cust_id";
            this.custidDataGridViewTextBoxColumn.HeaderText = "cust_id";
            this.custidDataGridViewTextBoxColumn.Name = "custidDataGridViewTextBoxColumn";
            // 
            // custnameDataGridViewTextBoxColumn
            // 
            this.custnameDataGridViewTextBoxColumn.DataPropertyName = "cust_name";
            this.custnameDataGridViewTextBoxColumn.HeaderText = "cust_name";
            this.custnameDataGridViewTextBoxColumn.Name = "custnameDataGridViewTextBoxColumn";
            // 
            // dLnoDataGridViewTextBoxColumn
            // 
            this.dLnoDataGridViewTextBoxColumn.DataPropertyName = "DL_no";
            this.dLnoDataGridViewTextBoxColumn.HeaderText = "DL_no";
            this.dLnoDataGridViewTextBoxColumn.Name = "dLnoDataGridViewTextBoxColumn";
            // 
            // tINnoDataGridViewTextBoxColumn
            // 
            this.tINnoDataGridViewTextBoxColumn.DataPropertyName = "TIN_no";
            this.tINnoDataGridViewTextBoxColumn.HeaderText = "TIN_no";
            this.tINnoDataGridViewTextBoxColumn.Name = "tINnoDataGridViewTextBoxColumn";
            // 
            // addressline1DataGridViewTextBoxColumn
            // 
            this.addressline1DataGridViewTextBoxColumn.DataPropertyName = "address_line1";
            this.addressline1DataGridViewTextBoxColumn.HeaderText = "address_line1";
            this.addressline1DataGridViewTextBoxColumn.Name = "addressline1DataGridViewTextBoxColumn";
            // 
            // addressline2DataGridViewTextBoxColumn
            // 
            this.addressline2DataGridViewTextBoxColumn.DataPropertyName = "address_line2";
            this.addressline2DataGridViewTextBoxColumn.HeaderText = "address_line2";
            this.addressline2DataGridViewTextBoxColumn.Name = "addressline2DataGridViewTextBoxColumn";
            // 
            // contactnoDataGridViewTextBoxColumn
            // 
            this.contactnoDataGridViewTextBoxColumn.DataPropertyName = "contact_no";
            this.contactnoDataGridViewTextBoxColumn.HeaderText = "contact_no";
            this.contactnoDataGridViewTextBoxColumn.Name = "contactnoDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // buyerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 432);
            this.Controls.Add(this.tabControl1);
            this.Name = "buyerDetails";
            this.Text = "buyerDetails";
            this.Load += new System.EventHandler(this.buyerDetails_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuyerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_SSM_Medical_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customermasterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBuyerName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblBuyerAdd1;
        private System.Windows.Forms.Label lblBuyerAdd2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBuyerName;
        private System.Windows.Forms.TextBox txtBuyerContact;
        private System.Windows.Forms.TextBox txtBuyerAddr1;
        private System.Windows.Forms.TextBox txtBuyerAddr2;
        private System.Windows.Forms.TextBox txtBuyerDL;
        private System.Windows.Forms.TextBox txtBuyerTIN;
        private System.Windows.Forms.TextBox txtBuyerEmail;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridView grdBuyerDetails;
        private System.Windows.Forms.Label label2;
        private DB_SSM_Medical_InventoryDataSet dB_SSM_Medical_InventoryDataSet;
        private System.Windows.Forms.BindingSource customermasterBindingSource;
        private DB_SSM_Medical_InventoryDataSetTableAdapters.customer_masterTableAdapter customer_masterTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn custidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dLnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tINnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressline1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressline2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
    }
}