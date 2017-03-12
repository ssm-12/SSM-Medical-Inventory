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
using System.Text.RegularExpressions;

namespace medicalInventory
{
    public partial class buyerDetails : Form
    {
        BALBuyerDetails objBALbuyerDL = new BALBuyerDetails();
        BOBuyerDetails objBObuyerDL = new BOBuyerDetails();
        public buyerDetails(int tabNo)
        {
            InitializeComponent();
            funcOpenTabPage(tabNo);

        }

        public void funcOpenTabPage(int pageNo)
        {
            if (pageNo == 1)
            {
                tabControl1.SelectedTab = tabPage1;
            }
            else if (pageNo == 2)
            {
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(funcValidateUserInput() == true)
            {
                objBObuyerDL.buyerName = txtBuyerName.Text;
                objBObuyerDL.buyerContactNo = txtBuyerContact.Text;
                objBObuyerDL.buyerAddr1 = txtBuyerAddr1.Text;
                objBObuyerDL.buyerAddr2 = txtBuyerAddr2.Text;
                objBObuyerDL.buyerTinNo = txtBuyerTIN.Text;
                objBObuyerDL.buyerDLNo = txtBuyerDL.Text;
                objBObuyerDL.buyerEmailId = txtBuyerEmail.Text;

                if (objBALbuyerDL.funcCheckDuplicateCust(objBObuyerDL) > 0)
                {
                    MessageBox.Show("Duplicate entry of the Customer. Please check existing Customer list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcClearAllFields();
                    txtBuyerName.Select();
                    return;
                }

                if (objBALbuyerDL.funcInsertCustDetails(objBObuyerDL) == true)
                {
                    MessageBox.Show("Customer Information Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcClearAllFields();
                    txtBuyerName.Select();
                    //TO DO: Clear all the text fields, set focus to name
                }
                else
                {
                    MessageBox.Show("Cannot save Customer details", "Error Code : 00016", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void funcClearAllFields()
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (Regex.Match(tableLayoutPanel1.Controls[i].Name, @"^txt[1]*").Success)
                    tableLayoutPanel1.Controls[i].Text = "";
            }
        }

        private bool funcValidateUserInput()
        {
            bool retVal = true;
            string strMsg = "Please correct the below mentioned error(s): \n";

            if (txtBuyerName.Text == "")
            {
                strMsg += "Enter Customer Name\n";
                retVal = false;
            }


            if (txtBuyerContact.Text == "")
            {
                strMsg += "Enter Contact Number \n";
                retVal = false;
            }
            if (!funcValidateContactNo(txtBuyerContact.Text))
            {
                strMsg += "Please enter 10 or 11 Digits Contact Number\n";
                retVal = false;
            }

            if (!funcValidateEmail(txtBuyerEmail.Text) && txtBuyerEmail.Text != "")
            {
                strMsg += "Please enter valid email id\n";
                retVal = false;
            }

            if (retVal == false)
                MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return retVal;
        }

        public bool funcValidateEmail(string email)
        {
            Regex expr = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (expr.IsMatch(email))
            {
                return true;
            }
            else return false;
        }

        public static bool funcValidateContactNo(string number)
        {
            return Regex.Match(number, @"^[0-9]{1}[0-9]{9,10}$").Success;
        }

        private void buyerDetails_Load(object sender, EventArgs e)
        {
            funcInitializeIndividualTab();
        }

        private void funcInitializeIndividualTab()
        {
            //Add Customer Tab - Initializations goes here
            if (tabControl1.SelectedIndex == 0)
            {
                txtBuyerName.Select();
            }
            //Modify Customer Tab - Initializations goes here
            else if (tabControl1.SelectedIndex == 1)
            {
                funcPopulateCustomerGrid();
            }
        }

        private void tabControl1_IndexChange(object sender, EventArgs e)
        {
            funcInitializeIndividualTab();
        }

        private void funcPopulateCustomerGrid()
        {
            DataTable dt = new DataTable();
            objBObuyerDL.searchBy = comboSearchBy.Text;
            objBObuyerDL.searchTerm = txtSearchText.Text;
            dt = objBALbuyerDL.funcPopulateCustGrid(objBObuyerDL);

            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Customer Details", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridCustDetails.DataSource = dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            funcPopulateCustomerGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Do you really want to Save Changes? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                bool retVal = objBALbuyerDL.funcUpdateCustomerMaster();
                if (retVal == false)
                {
                    MessageBox.Show("Unable to Save Customer Details to Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (retVal == true)
                {
                    MessageBox.Show("Customer Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow dataGridRow in dataGridCustDetails.SelectedRows)
            {
                if (dataGridRow.Selected)
                    count++;
            }
            if (count == 0)
            {
                MessageBox.Show("Please select Customer Record(s) to delete", "Record(s) not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult choice = MessageBox.Show("Record Selected: " + count + Environment.NewLine + "Do you really want to delete '" + count + "' Record(s):", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                //foreach (DataGridViewCell oneCell in dataGridProdDetails.SelectedCells)
                foreach (DataGridViewRow dataGridRow in dataGridCustDetails.SelectedRows)
                {
                    if (dataGridRow.Selected)
                    {
                        objBALbuyerDL.funcDeleteCustomerMaster(dataGridCustDetails.Rows[dataGridRow.Index].Cells[0].Value.ToString());
                        dataGridCustDetails.Rows.RemoveAt(dataGridRow.Index);
                    }
                    //dataGridProdDetails.Rows.RemoveAt(oneCell.RowIndex);
                }
                bool retVal = objBALbuyerDL.funcUpdateCustomerMaster();
                if (retVal == false)
                {
                    MessageBox.Show("Unable to delete Customer Record from the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (retVal == true)
                {
                    MessageBox.Show("Customer Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
