using System;
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

        private void button2_Click(object sender, EventArgs e)
        {
            
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
    }
}