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
    public partial class supplierDetails : Form
    {
        private BALSuppDetails objBALSuppDetails = new BALSuppDetails();
        private BOSuppDetails objBOSuppDetails = new BOSuppDetails();
        public supplierDetails(int tabNo)
        {
            InitializeComponent();
            funcOpenTabPage(tabNo);
        }

        private void funcOpenTabPage(int pageNo)
        {
            if (pageNo == 1)
            {
                tabControl1.SelectedTab = tabPage1;
                txtName.Select();
            }
            else if (pageNo == 2)
            {
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (funcValidateField())
            {
                objBOSuppDetails.suppName = txtName.Text;
                objBOSuppDetails.contactNo = txtContact.Text;
                objBOSuppDetails.addr1 = txtAddr1.Text;
                objBOSuppDetails.addr2 = txtAddr2.Text;
                objBOSuppDetails.dlNo = txtDL.Text;
                objBOSuppDetails.tinNo = txtTIN.Text;
                objBOSuppDetails.emailId = txtEmail.Text;

                if (objBALSuppDetails.funcCheckDuplicateSup(objBOSuppDetails) > 0)
                {
                    MessageBox.Show("Duplicate entry of the Supplier. Please check existing supplier list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcClearAllFields();
                    txtName.Select();
                    return;
                }

                if (objBALSuppDetails.funcInsertSupDetails(objBOSuppDetails) == true)
                {
                    MessageBox.Show("Supplier Information Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcClearAllFields();
                    txtName.Select();
                    //TO DO: Clear all the text fields, set focus to name
                }
                else
                {
                    MessageBox.Show("Cannot save supplier details", "Error Code : 00001", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool funcValidateField()
        {
            bool retVal = true;
            string strMsg = "Please correct the below mentioned error(s): \n";

            if (txtName.Text == "")
            {
                strMsg += "Enter Supplier Name\n";
                retVal = false;
            }


            if (txtContact.Text == "")
            {
                strMsg += "Enter Contact Number \n";
                retVal = false;
            }
            if (!funcValidateContactNo(txtContact.Text))
            {
                strMsg += "Please enter 10 or 11 Digits Contact Number\n";
                retVal = false;
            }

            if (!funcValidateEmail(txtEmail.Text) && txtEmail.Text != "")
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supplierDetails_Load(object sender, EventArgs e)
        {
            funcInitializeIndividualTab();

        }

        private void funcInitializeIndividualTab()
        {
            //Add Supplier Tab - Initializations goes here
            if (tabControl1.SelectedIndex == 0)
            {

            }
            //Modify Supplier Tab - Initializations goes here
            else if (tabControl1.SelectedIndex == 1)
            {
                funcPopulateSupplierGrid();
            }
        }

        private void funcPopulateSupplierGrid()
        {
            DataTable dt = new DataTable();
            objBOSuppDetails.searchBy = comboSearchBy.Text;
            objBOSuppDetails.searchTerm = txtSearchText.Text;
            dt = objBALSuppDetails.funcPopulateSupplierGrid(objBOSuppDetails);

            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Supplier Details", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridSupDetails.DataSource = dt;
            }
        }

        private void tabControl1_IndexChange(object sender, EventArgs e)
        {
            funcInitializeIndividualTab();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            funcPopulateSupplierGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Do you really want to Save Changes? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                bool retVal = objBALSuppDetails.funcUpdateSupplierMaster();
                if (retVal == false)
                {
                    MessageBox.Show("Unable to Save Supplier Details to Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (retVal == true)
                {
                    MessageBox.Show("Supplier Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow dataGridRow in dataGridSupDetails.SelectedRows)
            {
                if (dataGridRow.Selected)
                    count++;
            }
            if (count == 0)
            {
                MessageBox.Show("Please select Supplier Record(s) to delete", "Record(s) not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult choice = MessageBox.Show("Record Selected: " + count + Environment.NewLine + "Do you really want to delete '" + count + "' Record(s):", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                //foreach (DataGridViewCell oneCell in dataGridProdDetails.SelectedCells)
                foreach (DataGridViewRow dataGridRow in dataGridSupDetails.SelectedRows)
                {
                    if (dataGridRow.Selected)
                    {
                        objBALSuppDetails.funcDeleteSupplierMaster(dataGridSupDetails.Rows[dataGridRow.Index].Cells[0].Value.ToString());
                        dataGridSupDetails.Rows.RemoveAt(dataGridRow.Index);

                    }
                    //dataGridProdDetails.Rows.RemoveAt(oneCell.RowIndex);
                }
                bool retVal = objBALSuppDetails.funcUpdateSupplierMaster();
                if (retVal == false)
                {
                    MessageBox.Show("Unable to delete Supplier Record from the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (retVal == true)
                {
                    MessageBox.Show("Supplier Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
