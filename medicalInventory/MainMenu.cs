﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace medicalInventory
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        //Customer Details - Button Click
        private void btnProduct_click(object sender, EventArgs e)
        {
            contextMenuOnProductBtn.Show(btnProduct, new Point(btnProduct.Width, 0));
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            

            
        }

        private void btNewOrder_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
 	        
        }

        private void btnRetail_Click(object sender, EventArgs e)
        {
            contextMenuRetailBtn.Show(btnRetail, new Point(btnRetail.Width, 0));
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            contextMenuPurchaseBtn.Show(btnPurchase, new Point(btnPurchase.Width, 0));
        }

        private void btnSuppDetails_Click(object sender, EventArgs e)
        {
            contextMenuSupplierL.Show(btnSuppDetails, new Point(btnSuppDetails.Width, 0));
        }

        //Check if the form is already open
        private bool funcIsFormOpen(string strFrmName)
        { 
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == strFrmName)
                {
                    return true;
                }
            }
            return false;
        }

        private void funcBringToFront(string strFrmName)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == strFrmName)
                {
                    Application.OpenForms[i].BringToFront();
                }
            }
        }

        private void btnSupply_Click(object sender, EventArgs e)
        {
            contextMenuSupply.Show(btnSupply, new Point(btnSupply.Width, 0));
        }

        private void toolStripAddProduct_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("productDetails"))
            {
                productDetails frmProdDetails = new productDetails(1);//Sent value denotes which tab to open
                frmProdDetails.MdiParent = this;
                frmProdDetails.Show();
            }
            else
            {
                funcBringToFront("productDetails");
            }
        }

        private void toolStripModifyProduct_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("productDetails"))
            {
                productDetails frmProdDetails = new productDetails(2);//Sent value denotes which tab to open
                frmProdDetails.MdiParent = this;
                frmProdDetails.Show();
            }
            else
            {
                funcBringToFront("productDetails");
            }
        }

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("supplierDetails"))
            {
                supplierDetails frmSupDetails = new supplierDetails(1);
                frmSupDetails.MdiParent = this;
                frmSupDetails.Show();
            }
            else
            {
                funcBringToFront("supplierDetails");
            }
        }

        private void viewModifySupplierDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("supplierDetails"))
            {
                supplierDetails frmSupDetails = new supplierDetails(2);
                frmSupDetails.MdiParent = this;
                frmSupDetails.Show();
            }
            else
            {
                funcBringToFront("supplierDetails");
            }
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("purchaseBill"))
            {
                pleaseWaitForm frmPleaseWait = new pleaseWaitForm();
                frmPleaseWait.Show();
                Application.DoEvents();
                purchaseBill frmSupDetails = new purchaseBill();
                frmSupDetails.MdiParent = this;
                frmSupDetails.Show();
                frmPleaseWait.Close();
            }
            else
            {
                funcBringToFront("purchaseBill");
            }
        }

        private void viewBillDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("purchaseBillDetails"))
            {
                purchaseBillDetails frmInvoiceDetails = new purchaseBillDetails();
                frmInvoiceDetails.MdiParent = this;
                frmInvoiceDetails.Show();
            }
            else
            {
                funcBringToFront("purchaseBillDetails");
            }
        }

        private void newBillToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("retailNewBill"))
            {
                try
                {
                    pleaseWaitForm frmPleaseWait = new pleaseWaitForm();
                    frmPleaseWait.Show();
                    Application.DoEvents();
                    retailNewBill frmRetailNewBill = new retailNewBill();
                    frmRetailNewBill.MdiParent = this;
                    Cursor.Position = this.PointToScreen(new Point(0,0));
                    frmRetailNewBill.Show();
                    frmPleaseWait.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Try Again...", "System Busy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                funcBringToFront("retailNewBill");
            }
        }

        private void btnCustomerMaster_Click(object sender, EventArgs e)
        {
            contextMenuCustomerMaster.Show(btnBuyerDetails, new Point(btnBuyerDetails.Width, 0));
        }

        private void toolStripMenuAddCustomer_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("buyerDetails"))
            {
                buyerDetails frmBuyerDetails = new buyerDetails(1);
                frmBuyerDetails.MdiParent = this;
                frmBuyerDetails.Show();
            }
            else
            {
                funcBringToFront("buyerDetails");
            }
        }

        private void toolStripMenuModifyCustomer_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("buyerDetails"))
            {
                buyerDetails frmBuyerDetails = new buyerDetails(2);
                frmBuyerDetails.MdiParent = this;
                frmBuyerDetails.Show();
            }
            else
            {
                funcBringToFront("buyerDetails");
            }
        }

        private void viewBillDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("retailBillDetails"))
            {
                retailBillDetails frmRetailBillDetails = new retailBillDetails();
                frmRetailBillDetails.MdiParent = this;
                frmRetailBillDetails.Show();
            }
            else
            {
                funcBringToFront("retailBillDetails");
            }
        }

        private void createChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("challan"))
            {
                pleaseWaitForm frmPleaseWait = new pleaseWaitForm();
                frmPleaseWait.Show();
                Application.DoEvents();
                challan frmChallan = new challan();
                frmChallan.MdiParent = this;
                Cursor.Position = this.PointToScreen(new Point(0, 0));
                frmChallan.Show();
                frmPleaseWait.Close();
            }
            else
            {
                funcBringToFront("challan");
            }
        }

        private void viewChallanDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!funcIsFormOpen("challanDetails"))
            {
                challanDetails frmChallan = new challanDetails();
                frmChallan.MdiParent = this;
                Cursor.Position = this.PointToScreen(new Point(0, 0));
                frmChallan.Show();
            }
            else
            {
                funcBringToFront("challanDetails");
            }
        }
    }
}