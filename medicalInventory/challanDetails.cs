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
    public partial class challanDetails : Form
    {
        BOChallanDetails objBOChallanDetails = new BOChallanDetails();
        BALChallanDetails objBALChallanDetails = new BALChallanDetails();
        public challanDetails()
        {
            InitializeComponent();
        }

        private void challanDetails_Load(object sender, EventArgs e)
        {
            dateTimeFrom.Value = Convert.ToDateTime(DateTime.Today.Year + "/" + DateTime.Today.Month + "/01");
            comboSearchBy.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridChallanList.Rows.Clear();
            objBOChallanDetails.searchBy = comboSearchBy.Text;
            objBOChallanDetails.searchText = txtSearch.Text;
            objBOChallanDetails.fromDate = dateTimeFrom.Value;
            objBOChallanDetails.toDate = dateTimeTo.Value;

            DataTable dt = new DataTable();
            dt = objBALChallanDetails.getChallanDetails(objBOChallanDetails);
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive List of Challan", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Challan found!!!", "Error Code: 00030", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridChallanList.Rows.Add(dr.ItemArray);
                }
            }
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            BOChallanProductDetails objBOChallanProdDetails = new BOChallanProductDetails();
            foreach (DataGridViewCell oneCell in dataGridChallanList.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    objBOChallanProdDetails.challanNo = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[0].Value);
                    objBOChallanProdDetails.customerName = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[1].Value);
                    objBOChallanProdDetails.challanAmount = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[2].Value);
                    objBOChallanProdDetails.convertedToBillFlag = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[3].Value);
                    objBOChallanProdDetails.challanDate = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[4].Value);
                }
            }
            challanProductDetails frmProdDetails = new challanProductDetails(objBOChallanProdDetails);
            frmProdDetails.ShowDialog(this); 
        }

        private void btnConvertToBill_Click(object sender, EventArgs e)
        {
            string challanNumber="", customerName="", challanAmount="";
            foreach (DataGridViewCell oneCell in dataGridChallanList.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    challanNumber = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[0].Value);
                    customerName = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[1].Value);
                    challanAmount = Convert.ToString(dataGridChallanList.Rows[oneCell.RowIndex].Cells[2].Value);
                }
            }
            challanToBill frmChallanToBill = new challanToBill(challanNumber, customerName, challanAmount);
            frmChallanToBill.ShowDialog(this);
        }

        
    }
}
