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
    public partial class retailBillProductDetails : Form
    {
        BORetailBillProductDetails objBORetailProductDetails = new BORetailBillProductDetails();
        BALRetailBillProductDetails objBALRetailProductDetails = new BALRetailBillProductDetails();
        public retailBillProductDetails(BORetailBillProductDetails objBOProdDetails)
        {
            InitializeComponent();
            objBORetailProductDetails = objBOProdDetails;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void retailBillProductDetails_Load(object sender, EventArgs e)
        {
            lblInvoiceNumber.Text = objBORetailProductDetails.invoiceNumber;
            lblPatientName.Text = objBORetailProductDetails.patientName;
            lblAddress.Text = objBORetailProductDetails.address;
            lblContactNo.Text = objBORetailProductDetails.contactNo;
            lblPrescribedBy.Text = objBORetailProductDetails.prescribedBy;
            lblTotalMRP.Text = objBORetailProductDetails.totalMRP;
            lblDiscont.Text = objBORetailProductDetails.discount;
            lblInvoiceAmount.Text = objBORetailProductDetails.invoiceAmount;

            DataTable dt = new DataTable();
            dt = objBALRetailProductDetails.getInvoiceProductDetails(lblInvoiceNumber.Text);
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
