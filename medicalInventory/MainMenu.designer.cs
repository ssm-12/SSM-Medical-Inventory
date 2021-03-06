﻿namespace medicalInventory
{
    partial class MainMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnBuyerDetails = new System.Windows.Forms.Button();
            this.btnSuppDetails = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnRetail = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnSupply = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGoldPrice = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSilverPrice = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuOnProductBtn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripModifyProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSupplierL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewModifySupplierDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPurchaseBtn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBillDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRetailBtn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newBillToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBillDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCustomerMaster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuAddCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuModifyCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSupply = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createChallanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewChallanDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertChallanToBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBillDetailsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuOnProductBtn.SuspendLayout();
            this.contextMenuSupplierL.SuspendLayout();
            this.contextMenuPurchaseBtn.SuspendLayout();
            this.contextMenuRetailBtn.SuspendLayout();
            this.contextMenuCustomerMaster.SuspendLayout();
            this.contextMenuSupply.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Menu";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnDashboard, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn3, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnBuyerDetails, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnSuppDetails, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnProduct, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnRetail, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPurchase, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSupply, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReturn, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 376);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDashboard.Location = new System.Drawing.Point(6, 129);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(176, 32);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btNewOrder_Click);
            // 
            // btn3
            // 
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.Location = new System.Drawing.Point(6, 334);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(176, 36);
            this.btn3.TabIndex = 8;
            this.btn3.Text = "Extra3";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // btnBuyerDetails
            // 
            this.btnBuyerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuyerDetails.Location = new System.Drawing.Point(6, 293);
            this.btnBuyerDetails.Name = "btnBuyerDetails";
            this.btnBuyerDetails.Size = new System.Drawing.Size(176, 32);
            this.btnBuyerDetails.TabIndex = 7;
            this.btnBuyerDetails.Text = "Customer Master";
            this.btnBuyerDetails.UseVisualStyleBackColor = true;
            this.btnBuyerDetails.Click += new System.EventHandler(this.btnCustomerMaster_Click);
            // 
            // btnSuppDetails
            // 
            this.btnSuppDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuppDetails.Location = new System.Drawing.Point(6, 252);
            this.btnSuppDetails.Name = "btnSuppDetails";
            this.btnSuppDetails.Size = new System.Drawing.Size(176, 32);
            this.btnSuppDetails.TabIndex = 6;
            this.btnSuppDetails.Text = "Supplier Master";
            this.btnSuppDetails.UseVisualStyleBackColor = true;
            this.btnSuppDetails.Click += new System.EventHandler(this.btnSuppDetails_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProduct.Location = new System.Drawing.Point(6, 211);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(176, 32);
            this.btnProduct.TabIndex = 5;
            this.btnProduct.Text = "Product Master";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_click);
            // 
            // btnRetail
            // 
            this.btnRetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRetail.Location = new System.Drawing.Point(6, 6);
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.Size = new System.Drawing.Size(176, 32);
            this.btnRetail.TabIndex = 0;
            this.btnRetail.Text = "Retail";
            this.btnRetail.UseVisualStyleBackColor = true;
            this.btnRetail.Click += new System.EventHandler(this.btnRetail_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPurchase.Location = new System.Drawing.Point(6, 47);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(176, 32);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnSupply
            // 
            this.btnSupply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupply.Location = new System.Drawing.Point(6, 88);
            this.btnSupply.Name = "btnSupply";
            this.btnSupply.Size = new System.Drawing.Size(176, 32);
            this.btnSupply.TabIndex = 2;
            this.btnSupply.Text = "Supply";
            this.btnSupply.UseVisualStyleBackColor = true;
            this.btnSupply.Click += new System.EventHandler(this.btnSupply_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReturn.Location = new System.Drawing.Point(6, 170);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(176, 32);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblGoldPrice,
            this.toolStripStatusLabel3,
            this.lblSilverPrice});
            this.statusStrip1.Location = new System.Drawing.Point(200, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(699, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusLabel1.Text = "Footer 1";
            // 
            // lblGoldPrice
            // 
            this.lblGoldPrice.Name = "lblGoldPrice";
            this.lblGoldPrice.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(100, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusLabel3.Text = "Footer 2";
            // 
            // lblSilverPrice
            // 
            this.lblSilverPrice.Name = "lblSilverPrice";
            this.lblSilverPrice.Size = new System.Drawing.Size(0, 17);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(634, 411);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 4;
            // 
            // contextMenuOnProductBtn
            // 
            this.contextMenuOnProductBtn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuOnProductBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddProduct,
            this.toolStripModifyProduct});
            this.contextMenuOnProductBtn.Name = "contextMenuOnProductBtn";
            this.contextMenuOnProductBtn.Size = new System.Drawing.Size(201, 48);
            // 
            // toolStripAddProduct
            // 
            this.toolStripAddProduct.Name = "toolStripAddProduct";
            this.toolStripAddProduct.Size = new System.Drawing.Size(200, 22);
            this.toolStripAddProduct.Text = "Add New Product";
            this.toolStripAddProduct.Click += new System.EventHandler(this.toolStripAddProduct_Click);
            // 
            // toolStripModifyProduct
            // 
            this.toolStripModifyProduct.Name = "toolStripModifyProduct";
            this.toolStripModifyProduct.Size = new System.Drawing.Size(200, 22);
            this.toolStripModifyProduct.Text = "Modify Existing Product";
            this.toolStripModifyProduct.Click += new System.EventHandler(this.toolStripModifyProduct_Click);
            // 
            // contextMenuSupplierL
            // 
            this.contextMenuSupplierL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSupplierToolStripMenuItem,
            this.viewModifySupplierDetailsToolStripMenuItem});
            this.contextMenuSupplierL.Name = "contextMenuSupplierL";
            this.contextMenuSupplierL.Size = new System.Drawing.Size(227, 48);
            // 
            // addNewSupplierToolStripMenuItem
            // 
            this.addNewSupplierToolStripMenuItem.Name = "addNewSupplierToolStripMenuItem";
            this.addNewSupplierToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.addNewSupplierToolStripMenuItem.Text = "Add New Supplier";
            this.addNewSupplierToolStripMenuItem.Click += new System.EventHandler(this.addNewSupplierToolStripMenuItem_Click);
            // 
            // viewModifySupplierDetailsToolStripMenuItem
            // 
            this.viewModifySupplierDetailsToolStripMenuItem.Name = "viewModifySupplierDetailsToolStripMenuItem";
            this.viewModifySupplierDetailsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.viewModifySupplierDetailsToolStripMenuItem.Text = "View/Modify Supplier Details";
            this.viewModifySupplierDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewModifySupplierDetailsToolStripMenuItem_Click);
            // 
            // contextMenuPurchaseBtn
            // 
            this.contextMenuPurchaseBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBillToolStripMenuItem,
            this.viewBillDetailsToolStripMenuItem});
            this.contextMenuPurchaseBtn.Name = "contextMenuPurchaseBtn";
            this.contextMenuPurchaseBtn.Size = new System.Drawing.Size(157, 48);
            // 
            // newBillToolStripMenuItem
            // 
            this.newBillToolStripMenuItem.Name = "newBillToolStripMenuItem";
            this.newBillToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newBillToolStripMenuItem.Text = "New Bill";
            this.newBillToolStripMenuItem.Click += new System.EventHandler(this.newBillToolStripMenuItem_Click);
            // 
            // viewBillDetailsToolStripMenuItem
            // 
            this.viewBillDetailsToolStripMenuItem.Name = "viewBillDetailsToolStripMenuItem";
            this.viewBillDetailsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.viewBillDetailsToolStripMenuItem.Text = "View Bill Details";
            this.viewBillDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewBillDetailsToolStripMenuItem_Click);
            // 
            // contextMenuRetailBtn
            // 
            this.contextMenuRetailBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBillToolStripMenuItem1,
            this.viewBillDetailsToolStripMenuItem1});
            this.contextMenuRetailBtn.Name = "contextMenuRetailBtn";
            this.contextMenuRetailBtn.Size = new System.Drawing.Size(197, 48);
            // 
            // newBillToolStripMenuItem1
            // 
            this.newBillToolStripMenuItem1.Name = "newBillToolStripMenuItem1";
            this.newBillToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.newBillToolStripMenuItem1.Text = "New Bill (Retail)";
            this.newBillToolStripMenuItem1.Click += new System.EventHandler(this.newBillToolStripMenuItem1_Click);
            // 
            // viewBillDetailsToolStripMenuItem1
            // 
            this.viewBillDetailsToolStripMenuItem1.Name = "viewBillDetailsToolStripMenuItem1";
            this.viewBillDetailsToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.viewBillDetailsToolStripMenuItem1.Text = "View Bill Details (Retail)";
            this.viewBillDetailsToolStripMenuItem1.Click += new System.EventHandler(this.viewBillDetailsToolStripMenuItem1_Click);
            // 
            // contextMenuCustomerMaster
            // 
            this.contextMenuCustomerMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAddCustomer,
            this.toolStripMenuModifyCustomer});
            this.contextMenuCustomerMaster.Name = "contextMenuSupplierL";
            this.contextMenuCustomerMaster.Size = new System.Drawing.Size(236, 48);
            // 
            // toolStripMenuAddCustomer
            // 
            this.toolStripMenuAddCustomer.Name = "toolStripMenuAddCustomer";
            this.toolStripMenuAddCustomer.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuAddCustomer.Text = "Add New Customer";
            this.toolStripMenuAddCustomer.Click += new System.EventHandler(this.toolStripMenuAddCustomer_Click);
            // 
            // toolStripMenuModifyCustomer
            // 
            this.toolStripMenuModifyCustomer.Name = "toolStripMenuModifyCustomer";
            this.toolStripMenuModifyCustomer.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuModifyCustomer.Text = "View/Modify Customer Details";
            this.toolStripMenuModifyCustomer.Click += new System.EventHandler(this.toolStripMenuModifyCustomer_Click);
            // 
            // contextMenuSupply
            // 
            this.contextMenuSupply.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createChallanToolStripMenuItem,
            this.viewChallanDetailsToolStripMenuItem,
            this.convertChallanToBillToolStripMenuItem,
            this.viewBillDetailsToolStripMenuItem2});
            this.contextMenuSupply.Name = "contextMenuSupply";
            this.contextMenuSupply.Size = new System.Drawing.Size(193, 114);
            // 
            // createChallanToolStripMenuItem
            // 
            this.createChallanToolStripMenuItem.Name = "createChallanToolStripMenuItem";
            this.createChallanToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.createChallanToolStripMenuItem.Text = "Create Challan";
            this.createChallanToolStripMenuItem.Click += new System.EventHandler(this.createChallanToolStripMenuItem_Click);
            // 
            // viewChallanDetailsToolStripMenuItem
            // 
            this.viewChallanDetailsToolStripMenuItem.Name = "viewChallanDetailsToolStripMenuItem";
            this.viewChallanDetailsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewChallanDetailsToolStripMenuItem.Text = "View Challan Details";
            this.viewChallanDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewChallanDetailsToolStripMenuItem_Click);
            // 
            // convertChallanToBillToolStripMenuItem
            // 
            this.convertChallanToBillToolStripMenuItem.Name = "convertChallanToBillToolStripMenuItem";
            this.convertChallanToBillToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.convertChallanToBillToolStripMenuItem.Text = "Convert Challan to Bill";
            // 
            // viewBillDetailsToolStripMenuItem2
            // 
            this.viewBillDetailsToolStripMenuItem2.Name = "viewBillDetailsToolStripMenuItem2";
            this.viewBillDetailsToolStripMenuItem2.Size = new System.Drawing.Size(192, 22);
            this.viewBillDetailsToolStripMenuItem2.Text = "View Bill Details";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to SSM Inventory System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuOnProductBtn.ResumeLayout(false);
            this.contextMenuSupplierL.ResumeLayout(false);
            this.contextMenuPurchaseBtn.ResumeLayout(false);
            this.contextMenuRetailBtn.ResumeLayout(false);
            this.contextMenuCustomerMaster.ResumeLayout(false);
            this.contextMenuSupply.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnRetail;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnSupply;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnBuyerDetails;
        private System.Windows.Forms.Button btnSuppDetails;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblGoldPrice;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblSilverPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuOnProductBtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddProduct;
        private System.Windows.Forms.ToolStripMenuItem toolStripModifyProduct;
        private System.Windows.Forms.ContextMenuStrip contextMenuSupplierL;
        private System.Windows.Forms.ToolStripMenuItem addNewSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewModifySupplierDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuPurchaseBtn;
        private System.Windows.Forms.ToolStripMenuItem newBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBillDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuRetailBtn;
        private System.Windows.Forms.ToolStripMenuItem newBillToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewBillDetailsToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuCustomerMaster;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddCustomer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuModifyCustomer;
        private System.Windows.Forms.ContextMenuStrip contextMenuSupply;
        private System.Windows.Forms.ToolStripMenuItem createChallanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewChallanDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertChallanToBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBillDetailsToolStripMenuItem2;
    }
}