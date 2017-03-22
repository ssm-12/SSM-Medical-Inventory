using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BO;

namespace medicalInventory
{
    public partial class retailBillDetails : Form
    {
        BORetailBillDetails objBORetailBillDetails = new BORetailBillDetails();
        BALRetailBillDetails objBALRetailBillDetails = new BALRetailBillDetails();
        BORetailBillProductDetails objBORetailProductDetails = new BORetailBillProductDetails();
        public retailBillDetails()
        {
            InitializeComponent();
        }

        private void retailBillDetails_Load(object sender, EventArgs e)
        {
            dateTimeFrom.Value = Convert.ToDateTime(DateTime.Today.Year + "/" + DateTime.Today.Month + "/01");
            comboSearchBy.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridInvoiceList.Rows.Clear();
            objBORetailBillDetails.searchBy = comboSearchBy.Text;
            objBORetailBillDetails.searchText = txtSearch.Text;
            objBORetailBillDetails.fromDate = dateTimeFrom.Value;
            objBORetailBillDetails.toDate = dateTimeTo.Value;

            DataTable dt = new DataTable();
            dt = objBALRetailBillDetails.getInvoiceDetails(objBORetailBillDetails);
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Retail Invoice List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Invoice found!!!", "Invoice List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridInvoiceList.Rows.Add(dr.ItemArray);
                }
            }
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridInvoiceList.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    objBORetailProductDetails.invoiceNumber = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[0].Value);
                    objBORetailProductDetails.patientName = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[1].Value);
                    objBORetailProductDetails.address = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[2].Value);
                    objBORetailProductDetails.contactNo = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[3].Value);
                    objBORetailProductDetails.prescribedBy = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[4].Value);
                    objBORetailProductDetails.totalMRP = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[5].Value);
                    objBORetailProductDetails.discount = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[6].Value);
                    objBORetailProductDetails.invoiceAmount = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[7].Value);
                }
            }
            retailBillProductDetails frmProdDetails = new retailBillProductDetails(objBORetailProductDetails);
            frmProdDetails.ShowDialog(this);
        }

    }
}
