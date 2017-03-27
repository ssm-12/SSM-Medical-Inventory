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
    public partial class challan : Form
    {
        BALChallan objBALChallan = new BALChallan();
        BOChallan objBOChallan = new BOChallan();
        private static string batchNumber = "";
        public challan()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void challan_Load(object sender, EventArgs e)
        {
            getInvoiceID();
            funcPopulateCustomerList();
            populateProductList();
        }

        private void populateProductList()
        {
            DataTable dt = new DataTable();
            dt = objBALChallan.funcPopulateProductList();
            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Product List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboProductList.DataSource = dt;
                comboProductList.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboProductList.ValueMember = Convert.ToString(dt.Columns[0]);
            }
        }

        private void getInvoiceID()
        {
            string retVal = objBALChallan.getInvoiceID();
            if (retVal == "error")
            {
                MessageBox.Show("Unable to get new invoice ID. Please double click on the invoice number field to enter manually", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChallanNo.Select();
            }
            else
            {
                txtChallanNo.ReadOnly = true;
                txtChallanNo.Text = retVal;
                comboCustomerList.Select();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)//Add New Supplier
            {
                buyerDetails frmBuyerDetails = new buyerDetails(1);
                frmBuyerDetails.ShowDialog(this);
                funcPopulateCustomerList();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void funcPopulateCustomerList()
        { 
            DataTable dt = new DataTable();
            dt = objBALChallan.funcPopulateCustomerList();
            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Customer List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboCustomerList.DataSource = dt;
                comboCustomerList.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboCustomerList.ValueMember = Convert.ToString(dt.Columns[0]);
            }
        }

        private void txtChallanNo_DoubleClick(object sender, EventArgs e)
        {
            txtChallanNo.ReadOnly = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validation Starts
            if (comboProductList.SelectedValue == null)
            {
                MessageBox.Show("Please select product from the list", "Product Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProductList.Select();
                return;
            }
            if (txtStrip.Text == "" && txtTab.Text == "")
            {
                MessageBox.Show("Please enter quantity", "Quantity Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStrip.Select();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.Match(txtStrip.Text, @"^[0-9]+$").Success && txtStrip.Text != "")
            {
                MessageBox.Show("Quantity should be numeric value only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStrip.Select();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.Match(txtTab.Text, @"^[0-9]+$").Success && txtTab.Text != "")
            {
                MessageBox.Show("Quantity should be numeric value only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTab.Select();
                return;
            }
            if (batchNumber == "" || batchNumber == null)
            {
                MessageBox.Show("Please select particular batch by pressing enter on product field", "Batch not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProductList.Select();
                return;
            }
            //Validation Ends

            DataTable dt = objBALChallan.funcGetBatchDetails(batchNumber, comboProductList.SelectedValue.ToString());
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to get selected product details", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                decimal mrp_per_unit, total_mrp, available_strip, available_tab, available_quant, selling_quant;
                int strip, tab, packing;
                string prod_packing = "";
                if (txtStrip.Text != "")
                {
                    strip = Convert.ToInt32(txtStrip.Text);
                }
                else
                {
                    strip = 0;
                }
                if (txtTab.Text != "")
                {
                    tab = Convert.ToInt32(txtTab.Text);
                }
                else
                {
                    tab = 0;
                }
                prod_packing = dt.Rows[0][2].ToString();
                prod_packing = prod_packing.Substring(2, prod_packing.Length - 2);
                packing = Convert.ToInt32(prod_packing);
                mrp_per_unit = Convert.ToDecimal(dt.Rows[0][5]);
                available_strip = Convert.ToDecimal(dt.Rows[0][6]);
                available_tab = Convert.ToDecimal(dt.Rows[0][7]);
                available_quant = (available_strip * packing) + available_tab;
                selling_quant = (strip * packing) + tab;
                if (tab >= packing)
                {
                    MessageBox.Show("Tab Quantity cannot be greater than or equal to packing quantity", "Invalid Tab Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTab.Select();
                    return;
                }
                if (selling_quant > available_quant)
                {
                    MessageBox.Show("Selling quantity exceeding available quantity", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStrip.Select();
                    return;
                }
                total_mrp = (strip * mrp_per_unit) + (mrp_per_unit / packing) * tab;
                total_mrp = Math.Round(total_mrp, 2);
                dataGridProductList.Rows.Add(dt.Rows[0][0], dt.Rows[0][1], dt.Rows[0][2], dt.Rows[0][3], dt.Rows[0][4], txtStrip.Text, txtTab.Text, dt.Rows[0][5], total_mrp.ToString());
                comboProductList.SelectedIndex = 0;
                txtStrip.Text = "";
                txtTab.Text = "";
                batchNumber = "";
                comboProductList.Select();
            }

        }

        private void clearGlobal(object sender, System.EventArgs e)
        {
            batchNumber = "";
        }

        private void comboProductList_OnChange(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                showProductPopUp();
            }
        }

        private void showProductPopUp()
        {
            if (comboProductList.SelectedValue == null)
            {
                MessageBox.Show("Please select product from the list", "Product Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            productSelection_Popup frmProductPopUp = new productSelection_Popup(comboProductList.SelectedValue.ToString());
            frmProductPopUp.ShowDialog(this);
            batchNumber = frmProductPopUp.getResult();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            funcCalculate();
        }

        private bool funcCalculate()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow drow in dataGridProductList.Rows)
            {
                totalAmount += Convert.ToDecimal(drow.Cells[8].Value);
            }
            totalAmount = Math.Round(totalAmount, 2);
            lblChallanAmount.Text = totalAmount.ToString();

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!userInputValidation() || !funcCalculate())
            {
                return;
            }
            if (saveChallanDetails())
            { 
                //Success
            }

        }

        private bool saveChallanDetails()
        {
            objBOChallan.challanNumber = txtChallanNo.Text;
            objBOChallan.challanDate = dateTimePicker1.Value;
            objBOChallan.customerID = comboCustomerList.SelectedValue.ToString();
            objBOChallan.challanAmount = Convert.ToDecimal(lblChallanAmount.Text);
            //Product Table - Start Here
            DataTable productTable = new DataTable();
            productTable.Columns.AddRange(new DataColumn[]{
                new DataColumn("batch_no",typeof(string)),
                new DataColumn("product_name",typeof(string)),
                new DataColumn("packing",typeof(string)),
                new DataColumn("expiry", typeof(DateTime)),
                new DataColumn("whole_quantity",typeof(int)),
                new DataColumn("loose_quantity",typeof(int)),
                new DataColumn("mrp_ps",typeof(decimal)),
                new DataColumn("total_amount",typeof(decimal))
            }
            );
            string tmpBatch, tmpYear, tmpMonth, tmpDate, tmpExp, tmpProductName, tmpPacking;
            int tmpWhole, tmpLoose;
            decimal tmpMrp, tmpTotalAmount;
            DateTime? tmpExpDate;
            //Parsing through DataGridRow
            foreach (DataGridViewRow dRow in dataGridProductList.Rows)
            {
                tmpBatch = dRow.Cells[0].Value.ToString();
                tmpProductName = dRow.Cells[1].Value.ToString();
                //Packing manipulation - Starts
                {
                    string strPacking = dRow.Cells[2].Value.ToString();
                    tmpPacking = strPacking.Substring(2, strPacking.Length - 2);
                }
                //Packing manipulation - Ends

                //Expiry Date - Starts
                tmpExp = Convert.ToString(dRow.Cells[3].Value);
                tmpMonth = tmpExp.Substring(0, 2);
                tmpYear = tmpExp.Substring(3, 4);
                tmpDate = Convert.ToString(DateTime.DaysInMonth(Convert.ToInt32(tmpYear), Convert.ToInt32(tmpMonth)));
                tmpExp = tmpMonth + "/" + tmpDate + "/" + tmpYear;
                tmpExpDate = DateTime.ParseExact(tmpExp, @"M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //Expiry Date - Ends
                //Product Quantity - Starts Here
                if (dRow.Cells[5].Value != "")
                    tmpWhole = Convert.ToInt32(dRow.Cells[5].Value);
                else
                    tmpWhole = 0;
                if (dRow.Cells[6].Value != "")
                    tmpLoose = Convert.ToInt32(dRow.Cells[6].Value);
                else
                    tmpLoose = 0;
                //Product Quantity - Ends Here
                tmpMrp = Convert.ToDecimal(dRow.Cells[7].Value);
                tmpTotalAmount = Convert.ToDecimal(dRow.Cells[8].Value);
                productTable.Rows.Add(tmpBatch, tmpProductName, tmpPacking, tmpExpDate, tmpWhole, tmpLoose, tmpMrp, tmpTotalAmount);
            }
            //Insertion Ends here
            //Product Table - Ends Here
            string retMsg = objBALChallan.saveChallanDetails(objBOChallan, productTable);
            if (retMsg == "success")
            {
                MessageBox.Show("Challan Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanUpOnSubmission();
                return true;
            }
            else
            {
                MessageBox.Show(retMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cleanUpOnSubmission()
        {
            lblChallanAmount.Text = "0.00";
            dataGridProductList.Rows.Clear();
            comboProductList.SelectedIndex = 0;
            txtStrip.Text = "";
            txtTab.Text = "";
            comboCustomerList.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today;
            getInvoiceID();
        }

        private bool userInputValidation()
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtChallanNo.Text, @"^[0-9,a-z,A-Z]{1,20}$") == false)
            {
                MessageBox.Show("Invalid Challan Number, Please enter valid Challan Number", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChallanNo.Select();
                return false;
            }
            if (dataGridProductList.Rows.Count == 0)
            {
                MessageBox.Show("No product(s) selected", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProductList.Select();
                return false;
            }
            if (comboCustomerList.SelectedValue == null)
            {
                MessageBox.Show("Please select customer", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboCustomerList.Select();
                return false;
            }
            return true;
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            if (!userInputValidation() || !funcCalculate())
            {
                return;
            }
            if (saveChallanDetails())
            {
                //Success + Printing Code goes here
            }
        }
    }
}
