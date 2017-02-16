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
    public partial class purchaseBillDetails : Form
    {
        BOPurchaseBillDetails objBOPurchaseBillDetails = new BOPurchaseBillDetails();
        BALPurchaseBillDetails objBALPurchaseBillDetails = new BALPurchaseBillDetails();
        public purchaseBillDetails()
        {
            InitializeComponent();
        }

        private void purchaseBillDetails_Load(object sender, EventArgs e)
        {
            dateTimeFrom.Value = Convert.ToDateTime(DateTime.Today.Year + "/" + DateTime.Today.Month + "/01");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridInvoiceList.Rows.Clear();
            objBOPurchaseBillDetails.searchBy = comboSearchBy.Text;
            objBOPurchaseBillDetails.searchText = txtSearch.Text;
            objBOPurchaseBillDetails.fromDate = dateTimeFrom.Value;
            objBOPurchaseBillDetails.toDate = dateTimeTo.Value;

            DataTable dt = new DataTable();
            dt = objBALPurchaseBillDetails.getInvoiceDetails(objBOPurchaseBillDetails);
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Invoice List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    objBOPurchaseBillDetails.invoiceNumber = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[0].Value);
                    objBOPurchaseBillDetails.supplierName = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[1].Value);
                    objBOPurchaseBillDetails.totalMRP = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[2].Value);
                    objBOPurchaseBillDetails.invoiceAmount = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[3].Value);
                    objBOPurchaseBillDetails.amountPaid = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[4].Value);
                    objBOPurchaseBillDetails.invoiceDate = Convert.ToString(dataGridInvoiceList.Rows[oneCell.RowIndex].Cells[5].Value);
                }
            }
            puchaseBillProductDetails frmProdDetails = new puchaseBillProductDetails(objBOPurchaseBillDetails);
            frmProdDetails.ShowDialog(this);
        }
    }
}
