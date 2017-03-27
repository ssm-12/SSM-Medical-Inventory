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
    public partial class challanProductDetails : Form
    {
        BOChallanProductDetails objProdDetails = new BOChallanProductDetails();
        BALChallanProductDetails objBALChallanProdDetails = new BALChallanProductDetails();
        public challanProductDetails(BOChallanProductDetails objBOChallanProdDetails)
        {
            objProdDetails = objBOChallanProdDetails;
            InitializeComponent();
        }

        private void challanProductDetails_Load(object sender, EventArgs e)
        {
            lblChallanNo.Text = objProdDetails.challanNo;
            lblCustomerName.Text = objProdDetails.customerName;
            lblConvertedToBillFlag.Text = objProdDetails.convertedToBillFlag;
            lblChallanDate.Text = objProdDetails.challanDate;
            lblChallanAmount.Text = objProdDetails.challanAmount;

            DataTable dt = new DataTable();
            dt = objBALChallanProdDetails.getChallanProductDetails(lblChallanNo.Text);
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Product List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
