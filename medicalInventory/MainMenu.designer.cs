namespace medicalInventory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btnRetail = new System.Windows.Forms.Button();
            this.btnSupply = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGoldPrice = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSilverPrice = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn3, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnDashboard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStock, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn2, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnRetail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSupply, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAccount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnReturn, 0, 5);
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
            // btn3
            // 
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.Location = new System.Drawing.Point(3, 331);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(182, 42);
            this.btn3.TabIndex = 7;
            this.btn3.Text = "Extra3";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(182, 35);
            this.btnDashboard.TabIndex = 8;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btNewOrder_Click);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStock.Location = new System.Drawing.Point(3, 44);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(182, 35);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_click);
            // 
            // btn2
            // 
            this.btn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2.Location = new System.Drawing.Point(3, 290);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(182, 35);
            this.btn2.TabIndex = 6;
            this.btn2.Text = "Extra2";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // btnRetail
            // 
            this.btnRetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRetail.Location = new System.Drawing.Point(3, 85);
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.Size = new System.Drawing.Size(182, 35);
            this.btnRetail.TabIndex = 1;
            this.btnRetail.Text = "Retail";
            this.btnRetail.UseVisualStyleBackColor = true;
            this.btnRetail.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSupply
            // 
            this.btnSupply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupply.Location = new System.Drawing.Point(3, 126);
            this.btnSupply.Name = "btnSupply";
            this.btnSupply.Size = new System.Drawing.Size(182, 35);
            this.btnSupply.TabIndex = 2;
            this.btnSupply.Text = "Supply";
            this.btnSupply.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            this.btn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1.Location = new System.Drawing.Point(3, 249);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(182, 35);
            this.btn1.TabIndex = 5;
            this.btn1.Text = "Extra1";
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // btnAccount
            // 
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAccount.Location = new System.Drawing.Point(3, 167);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(182, 35);
            this.btnAccount.TabIndex = 3;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReturn.Location = new System.Drawing.Point(3, 208);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(182, 35);
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
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "Gold Price (22 Carat)";
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel3.Text = "Silver Price";
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
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 425);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnRetail;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnSupply;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblGoldPrice;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblSilverPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}