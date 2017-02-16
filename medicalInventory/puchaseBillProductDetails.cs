using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BO;
using BAL;

namespace medicalInventory
{
    public partial class puchaseBillProductDetails : Form
    {
        BOPurchaseBillProductDetails objBOPurchaseProductDetails = new BOPurchaseBillProductDetails();
        BALPurchaseBillProductDetails objBALPurchaseProductDetails = new BALPurchaseBillProductDetails();
        public puchaseBillProductDetails(BOPurchaseBillDetails objBOPurchaseBillDetails)
        {
            InitializeComponent();
            objBOPurchaseProductDetails.invoiceNumber = objBOPurchaseBillDetails.invoiceNumber;
            objBOPurchaseProductDetails.supplierName = objBOPurchaseBillDetails.supplierName;
            objBOPurchaseProductDetails.totalMRP = objBOPurchaseBillDetails.totalMRP;
            objBOPurchaseProductDetails.invoiceAmount = objBOPurchaseBillDetails.invoiceAmount;
            objBOPurchaseProductDetails.amountPaid = objBOPurchaseBillDetails.amountPaid;
            objBOPurchaseProductDetails.invoiceDate = objBOPurchaseBillDetails.invoiceDate;

        }

        private void puchaseBillProductDetails_Load(object sender, EventArgs e)
        {
            lblInvoiceNumber.Text = objBOPurchaseProductDetails.invoiceNumber;
            lblSupplierName.Text = objBOPurchaseProductDetails.supplierName;
            lblTotalMRP.Text = objBOPurchaseProductDetails.totalMRP;
            lblInvoiceAmount.Text = objBOPurchaseProductDetails.invoiceAmount;
            lblAmountPaid.Text = objBOPurchaseProductDetails.amountPaid;
            lblInvoiceDate.Text = objBOPurchaseProductDetails.invoiceDate;

            DataTable dt = new DataTable();
            dt = objBALPurchaseProductDetails.getInvoiceProductDetails(lblInvoiceNumber.Text);
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Product List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Product(s) found!!!", "Empty Product List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridProductDetails.Rows.Add(dr.ItemArray);
                }
            }
        }
    }
}
