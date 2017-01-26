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
using System.Data;
using System.Text.RegularExpressions;

namespace medicalInventory
{
    
    public partial class productDetails : Form
    {
        BALProductDetails objBALProductDetails = new BALProductDetails();
        BOProductDetails objBOProductDetails = new BOProductDetails();
        public productDetails(int tabNo)
        {
            InitializeComponent();
            funcOpenTabPage(tabNo);
        }

        
        private void funcPopulateBrand()
        {
            DataTable dt = new DataTable();
            dt = objBALProductDetails.funcPopulateBrand();
            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Brands", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboBrand.DataSource = dt;
                comboBrand.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboBrand.ValueMember = Convert.ToString(dt.Columns[0]);
            }

        }

        private void funcPopulateGeneric()
        {
            DataTable dt = new DataTable();
            dt = objBALProductDetails.funcPopulateGeneric();
            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Generic Names", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboGeneric.DataSource = dt;
                comboGeneric.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboGeneric.ValueMember = Convert.ToString(dt.Columns[0]);
            }

        }
        

        private void funcOpenTabPage(int pageNo)
        {
            if (pageNo == 1)
            {
                tabControl1.SelectedTab = tabPage1;
                txtMedName.Select();
            }
            else if (pageNo == 2)
            {
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void productDetails_Load(object sender, EventArgs e)
        {
            funcInitializeIndividualTab();//All the initialization inside this function

        }

        //Important - All the functions or initialization while loading page goes here - tab wise
        private void funcInitializeIndividualTab()
        {
            //Add Medicine Tab - Initializations goes here
            if (tabControl1.SelectedIndex == 0)
            {
                funcPopulateBrand();
                funcPopulateGeneric();
                funcFormulationList();
                
            }
            //Modify Medicine Tab - Initializations goes here
            else if (tabControl1.SelectedIndex == 1)//Opened Modify Existing Product Tab
            {
                funcPopulateProductGrid();
            }
        }

        private void funcPopulateProductGrid()
        {
            DataTable dt = new DataTable();
            objBOProductDetails.searchBy = comboSearchBy.Text;
            objBOProductDetails.searchTerm = txtSearchText.Text;
            dt = objBALProductDetails.funcPopulateProductGrid(objBOProductDetails);

            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable Retreive Product Details", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridProdDetails.DataSource = dt;
            }
        }

        private void tabControl1_IndexChange(object sender, EventArgs e)
        {
            funcInitializeIndividualTab();
        }

        private void funcFormulationList()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                    {
                        "Tab",
                        "Inj",
                        "Gel",
                        "Vial",
                        "Cap",
                        "Drop"
                    });
            txtFormulation.AutoCompleteCustomSource = source;
        }

        private void comboBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBrand.DroppedDown = false;
        }
        private void comboGeneric_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboGeneric.DroppedDown = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (funcUserInputValidation() == true)
            {
                objBOProductDetails.medName = txtMedName.Text + " " + txtStrength.Text + " " + txtFormulation.Text;
                objBOProductDetails.company = comboBrand.Text;
                objBOProductDetails.genericName = comboGeneric.Text;
                objBOProductDetails.packing = txtPacking.Text;
                objBOProductDetails.unit = txtUnit.Text;
                objBOProductDetails.schedule = txtSchedule.Text;
                objBOProductDetails.contents = txtContents.Text;

                if (objBALProductDetails.funcInsertProductMaster(objBOProductDetails) == true)
                {
                    MessageBox.Show("Product Info Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcClearAllFields();
                    //TO DO: Clear all the text fields, set focus to name
                }
                else
                {
                    MessageBox.Show("Cannot product details", "Error Code : 00003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void funcClearAllFields()
        { 
            //All the field clearing tasks goes here
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (Regex.Match(tableLayoutPanel1.Controls[i].Name, @"^txt[1]*").Success)
                    tableLayoutPanel1.Controls[i].Text = "";
            }
            comboBrand.SelectedIndex = 0;
            comboGeneric.SelectedIndex = 0;
            txtMedName.Select();
        }

        private bool funcUserInputValidation()
        {
            bool retVal = true;
            string strMsg = "Please correct the below mentioned error(s): \n";
            if (txtMedName.Text == "")
            {
                retVal = false;
                strMsg += "Please Enter Medicine Name\n";
            }
            if (comboBrand.SelectedValue == null)
            {
                retVal = false;
                strMsg += "Please select company name from the list\n";
            }
            if (comboGeneric.SelectedValue == null)
            {
                retVal = false;
                strMsg += "Please select Generic name from the list\n";
            }
            if (txtPacking.Text == "")
            {
                retVal = false;
                strMsg += "Please Enter packing details of the product\n";
            }

            if (retVal == false)
            {
                MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

            return retVal;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool retVal = objBALProductDetails.funcUpdateProductMaster();
            if (retVal == false)
            {
                MessageBox.Show("Unable to Save Product Details to Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (retVal == true)
            {
                MessageBox.Show("Product Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow dataGridRow in dataGridProdDetails.SelectedRows)
            {
                if (dataGridRow.Selected)
                    count++;
            }
            if (count == 0)
            {
                MessageBox.Show("Please select product(s) to delete", "Product not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult choice = MessageBox.Show("Selected Product: " + count + Environment.NewLine + "Do you really want to delete '" + count + "' product(s):", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                //foreach (DataGridViewCell oneCell in dataGridProdDetails.SelectedCells)
                foreach (DataGridViewRow dataGridRow in dataGridProdDetails.SelectedRows)
                {
                    if (dataGridRow.Selected)
                        dataGridProdDetails.Rows.RemoveAt(dataGridRow.Index);
                        //dataGridProdDetails.Rows.RemoveAt(oneCell.RowIndex);
                }
                bool retVal = objBALProductDetails.funcUpdateProductMaster();
                if (retVal == false)
                {
                    MessageBox.Show("Unable to delete product details from the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (retVal == true)
                {
                    MessageBox.Show("Product Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            funcPopulateProductGrid();
        }


    }
}
