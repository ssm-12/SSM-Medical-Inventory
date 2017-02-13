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
using System.Text.RegularExpressions;

namespace medicalInventory
{
    public partial class purchaseBill : Form
    {
        BOPurchaseBill objBOPurchaseBill = new BOPurchaseBill();
        BALPurchaseBill objBALPurchaseBill = new BALPurchaseBill();
        static string local_packing;
        static decimal total_MRP;

        public purchaseBill()
        {
            InitializeComponent();
        }

        private void purchaseBill_Load(object sender, EventArgs e)
        {
            funcPopulateSupplierList();
            funcPopulateProductList();
            comboSupplier.Select();
        }

        private void funcPopulateSupplierList()
        {
            DataTable dt = new DataTable();
            dt = objBALPurchaseBill.funcPopulateSupplierList();
            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Supplier List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboSupplier.DataSource = dt;
                comboSupplier.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboSupplier.ValueMember = Convert.ToString(dt.Columns[0]);
            }
        }

        private void funcPopulateProductList()
        {
            DataTable dt = new DataTable();
            dt = objBALPurchaseBill.funcPopulateProductList();
            //Failed Scenario
            if (dt.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dt.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Product List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboProduct.DataSource = dt;
                comboProduct.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboProduct.ValueMember = Convert.ToString(dt.Columns[0]);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)//Add New Supplier
            {
                supplierDetails frmSupDetails = new supplierDetails(1);
                frmSupDetails.ShowDialog(this);
                funcPopulateSupplierList();
                return true;
            }
            if (keyData == Keys.F3)//Add New Product
            {
                productDetails frmProdDetails = new productDetails(1);
                frmProdDetails.ShowDialog(this);
                funcPopulateProductList();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void comboProduct_LostFocus(object sender, EventArgs e)
        {
            if (comboProduct.SelectedValue == null)
            {
                string msg = "Please select product from the list." + Environment.NewLine + "If you want to add new product in Product Master, Please press F3 Key";
                MessageBox.Show(msg,"Product Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            objBOPurchaseBill.product_id = Convert.ToInt32(comboProduct.SelectedValue);
            string packing = objBALPurchaseBill.funcCheckProductPacking(objBOPurchaseBill);
            if (packing == "")
            {
                //Call Update Packing Input Form

                //Check packing value in database again and save it to local_packing
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (funcValidateUserInput_product() == true)
            {
                if(funcCheckPacking()==true)
                {
                    if (txtTab.Text != "")
                    {
                        if (Convert.ToInt32(txtTab.Text) >= Convert.ToInt32(local_packing))
                        {
                            MessageBox.Show("Tab quantity is more than packing. Please enter appropriate number of strips", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTab.Select();
                            return;
                        }
                    }
                    funcAddToProductList();
                    btnClear_Click(sender, e);
                    comboProduct.Select();
                }
            }
        }

        private bool funcCheckPacking()
        {
            string id = comboProduct.SelectedValue.ToString();
            string name = comboProduct.Text.ToString();
            local_packing = objBALPurchaseBill.funcCheckProductPacking(objBOPurchaseBill);
            if (local_packing == null || local_packing == "")
            {
                updateProductPacking frmUpdateProdPacking = new updateProductPacking(id,name);
                frmUpdateProdPacking.ShowDialog(this);
                return false;
            }
            if (!local_packing.All(char.IsNumber))
            {
                updateProductPacking frmUpdateProdPacking = new updateProductPacking(id, name);
                frmUpdateProdPacking.ShowDialog(this);
                return false;
            }
            return true;
        }
        private void funcAddToProductList()
        { 
            string mfgDate="";
            string expiry = txtExpMonth.Text + "/" + txtExpYear.Text;
            decimal cost = Convert.ToDecimal(txtCostPerUnit.Text);
            decimal mrp = Convert.ToDecimal(txtMRP.Text);
            int stripQnt,tabQnt;
            decimal discount, totalCost;
            int packingQnt = Convert.ToInt32(local_packing);

            if (txtMfgMonth.Text != "")
            {
                mfgDate = txtMfgMonth.Text + "/" + txtMfgYear.Text;
            }
            if(txtStrip.Text ==""){
                stripQnt = 0;
            }
            else{
                stripQnt = Convert.ToInt32(txtStrip.Text);
            }
            if(txtTab.Text ==""){
                tabQnt = 0;
            }
            else{
                tabQnt = Convert.ToInt32(txtTab.Text);
            }
            if(txtDiscount.Text ==""){
                discount = 0;
            }
            else{
                discount = Convert.ToDecimal(txtDiscount.Text);
            }

            total_MRP += (stripQnt * mrp) + (mrp / packingQnt) * tabQnt;
            totalCost = (stripQnt*cost)+(cost/packingQnt)*tabQnt;
            totalCost = Math.Round(totalCost, 2);



            dataGridProductList.Rows.Add(comboProduct.SelectedValue, comboProduct.Text, txtBatch.Text, txtStrip.Text, txtTab.Text, mfgDate, expiry, txtMRP.Text, txtDiscount.Text, txtCostPerUnit.Text, totalCost.ToString(), txtRackNo.Text);
            
        }

        private bool funcValidateUserInput_product()
        {
            if (comboProduct.SelectedValue == null)
            {
                string msg = "Please select product from the list." + Environment.NewLine + "If you want to add new product in Product Master, Please press F3 Key";
                MessageBox.Show(msg, "Product Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboProduct.Select();
                return false;                
            }
            if (txtBatch.Text == "")
            {
                MessageBox.Show("Please Enter Batch Number", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBatch.Select();
                return false;
            }
            if (txtStrip.Text == "" && txtTab.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStrip.Select();
                return false;
            }
            if (!Regex.Match(txtStrip.Text, @"^[0-9]+$").Success && txtStrip.Text != "")
            {
                MessageBox.Show("Quantity should be numeric value only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStrip.Select();
                return false;
            }
            if (!Regex.Match(txtTab.Text, @"^[0-9]+$").Success && txtTab.Text != "")
            {
                MessageBox.Show("Quantity should be numeric value only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTab.Select();
                return false;
            }
            if (txtMRP.Text == "")
            {
                MessageBox.Show("Please Enter MRP", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMRP.Select();
                return false;
            }
            if (!Regex.Match(txtMRP.Text, @"^[0-9,.]+$").Success && txtMRP.Text != "")
            {
                MessageBox.Show("MRP should be numeric only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMRP.Select();
                return false;
            }
            if (!Regex.Match(txtDiscount.Text, @"^[0-9,.]+$").Success && txtDiscount.Text != "")
            {
                MessageBox.Show("Discount Percentage should be numeric only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiscount.Select();
                return false;
            }
            if (txtCostPerUnit.Text == "")
            {
                MessageBox.Show("Please Enter Cost per unit", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCostPerUnit.Select();
                return false;
            }
            if (!Regex.Match(txtCostPerUnit.Text, @"^[0-9,.]+$").Success && txtCostPerUnit.Text != "")
            {
                MessageBox.Show("Cost should be numeric only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCostPerUnit.Select();
                return false;
            }
            if (!(txtMfgMonth.Text == "" && txtMfgYear.Text == ""))
            {
                if (txtMfgMonth.Text == "")
                {
                    MessageBox.Show("Please Enter Mfg Month", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMfgMonth.Select();
                    return false;
                }
                if (txtMfgYear.Text == "")
                {
                    MessageBox.Show("Please Enter Mfg Year", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMfgYear.Select();
                    return false;
                }
            }
            if (txtMfgMonth.Text != "" && txtMfgYear.Text != "")
            {
                if (!txtMfgMonth.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Mfg Month should be numeric", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMfgMonth.Select();
                    return false;
                }
                else
                {
                    int mfgMonth = Convert.ToInt32(txtMfgMonth.Text);
                    if ( mfgMonth > 12 || mfgMonth < 1)
                    {
                        MessageBox.Show("Mfg Month should be between 1-12", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMfgMonth.Select();
                        return false;
                    }
                }

                if (!txtMfgYear.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Mfg Year should be numeric", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMfgYear.Select();
                    return false;
                }
                else
                {
                    int mfgYear = Convert.ToInt32(txtMfgYear.Text);
                    if (mfgYear < 2000)
                    {
                        MessageBox.Show("Invalid Mfg Year", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMfgYear.Select();
                        return false;
                    }
                }
            }
            if (!Regex.Match(txtExpMonth.Text, @"^[0-9]+$").Success)
            {
                MessageBox.Show("Expiry Month should be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpMonth.Select();
                return false;
            }
            if (!Regex.Match(txtExpYear.Text, @"^[0-9]+$").Success)
            {
                MessageBox.Show("Expiry Year should be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpYear.Select();
                return false;
            }
            int expMonth = Convert.ToInt32(txtExpMonth.Text);
            int expYear = Convert.ToInt32(txtExpYear.Text);
            int curMonth = DateTime.Today.Month;
            int curYear = DateTime.Today.Year;
            if (expMonth < 0 || expMonth > 12)
            {
                MessageBox.Show("Expiry Month should be between 1-12", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpMonth.Select();
                return false;
            }
            if (expYear < curYear)
            {
                MessageBox.Show("As per the expiry date, Product already expired", "Expired Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (expYear == curYear)
            {
                if (expMonth < curMonth)
                {
                    MessageBox.Show("As per the expiry date, Product already expired", "Expired Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void txtDiscount_LostFocus(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                return;
            }
            if (txtMRP.Text == "")
            {
                MessageBox.Show("Please Enter MRP", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMRP.Select();
                return;
            }
            if (!Regex.Match(txtMRP.Text, @"^[0-9,.]+$").Success && txtMRP.Text != "")
            {
                MessageBox.Show("MRP should be numeric only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMRP.Select();
                return;
            }
            if (!Regex.Match(txtDiscount.Text, @"^[0-9,.]+$").Success && txtDiscount.Text != "")
            {
                MessageBox.Show("Discount Percentage should be numeric only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiscount.Select();
                return;
            }
                       
            decimal discount, costPerUnit, mrp;
            mrp = Convert.ToDecimal(txtMRP.Text);
            discount = Convert.ToDecimal(txtDiscount.Text);
            costPerUnit = mrp * ((100-discount) / 100);
            txtCostPerUnit.Text = costPerUnit.ToString();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            comboProduct.SelectedIndex = 0;
            txtBatch.Text = "";
            txtStrip.Text = "";
            txtTab.Text = "";
            txtMRP.Text = "";
            txtDiscount.Text = "";
            txtCostPerUnit.Text = "";
            txtMfgMonth.Text = "";
            txtMfgYear.Text = "";
            txtExpMonth.Text = "";
            txtExpYear.Text = "";
            txtRackNo.Text = "";
            comboProduct.Select();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (funcValidationOnCalculate() == true)
            { 
                decimal totalCost,dueAmount,amountPaid;
                totalCost = 0;
                dueAmount = 0;
                amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                amountPaid = Math.Round(amountPaid, 2);
                //Calculate total mrp, cost and due amount
                foreach (DataGridViewRow dataGridRow in dataGridProductList.Rows)
                {
                    //totalMRP += Convert.ToDecimal(dataGridProductList.Rows[dataGridRow.Index].Cells["mrp"].Value);
                    totalCost += Convert.ToDecimal(dataGridProductList.Rows[dataGridRow.Index].Cells["total_cost"].Value);
                }
                totalCost = Math.Round(totalCost,2);
                //totalMRP = Math.Round(totalMRP,2);
                dueAmount = totalCost - amountPaid;
                //lblMRP.Text = totalMRP.ToString();
                lblCost.Text = totalCost.ToString("F");
                lblDueAmount.Text = dueAmount.ToString("F");
                lblAmountPaid.Text = amountPaid.ToString("F");
                lblMRP.Text = total_MRP.ToString("F");
            }
        }
        private bool funcValidationOnCalculate()
        {
            if (comboSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please Select Supplier from the list or Add new by pressing F2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboSupplier.Select();
                return false;
            }
            if (txtInvoice.Text == "")
            {
                MessageBox.Show("Please enter invoice number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoice.Select();
                return false;
            }
            if (dateTimePicker1.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Invoice date cannot be a future date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Select();
                return false;
            }
            if (txtAmountPaid.Text != "")
            {
                if (!Regex.Match(txtAmountPaid.Text, @"^[0-9,.]+$").Success)
                {
                    MessageBox.Show("Please enter numeric value for the paid amount", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmountPaid.Select();
                    return false;
                }
            }
            else
            {
                txtAmountPaid.Text = "0.00";
            }
            return true;
        }

        private void lblDueAmount_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             if (dataGridProductList.Rows.Count < 1)
             {
                 MessageBox.Show("Please enter product(s) in the list and try again", "No Product Enlisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 comboProduct.Select();
                 return;
             }
             else if(funcValidationOnCalculate()==true)
             {
                 btnCalculate_Click(sender, e);
                 decimal lblMRP_Value = Convert.ToDecimal(lblMRP.Text);
                 decimal lblDue_Value = Convert.ToDecimal(lblDueAmount.Text);
                 if (lblMRP_Value <= 0)
                 {
                     MessageBox.Show("Total MRP value cannot be zero or negative", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 if (lblDue_Value < 0)
                 {
                     MessageBox.Show("Due amount cannot be negative", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 //Insert Data into supplier_invoce_record, supplier_transaction_record (Update table amount_payable), supplier_invoice_details
                 //Update or Insert into inStock table
                 //Insert into cash_transaction
                 funcSaveInvoiceDetails();
             }

            
        }

        private void funcSaveInvoiceDetails()
        {
            //Data for table - supplier_invoice_record
            objBOPurchaseBill.invoice_number = txtInvoice.Text;
            objBOPurchaseBill.supplier_id = Convert.ToInt32(comboSupplier.SelectedValue);
            objBOPurchaseBill.transaction_id = "0";
            objBOPurchaseBill.totalMRP = Convert.ToDecimal(lblMRP.Text);
            objBOPurchaseBill.discount = 0;
            //objBOPurchaseBill.discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
            objBOPurchaseBill.totalCost = Convert.ToDecimal(lblCost.Text);
            objBOPurchaseBill.invoice_date = dateTimePicker1.Value.Date;
            objBOPurchaseBill.amount_paid = Convert.ToDecimal(txtAmountPaid.Text);
            objBOPurchaseBill.payment_method = "cash";
            //Creating dataTable for supplier_invoice_details
            DataTable dt_invoice_details = new DataTable();
            dt_invoice_details.Columns.AddRange(new DataColumn[]{
                new DataColumn("product-ID",typeof(int)),
                new DataColumn("batch_no",typeof(string)),
                new DataColumn("whole_quantity",typeof(int)),
                new DataColumn("loose_quantity",typeof(int)),
                new DataColumn("mrp_ps",typeof(decimal)),
                new DataColumn("discount",typeof(decimal)),
                new DataColumn("cost_per_unit",typeof(decimal)),
                new DataColumn("total_cost",typeof(decimal))
            }
            );
            string tmpBatch;
            int tmpProductID,tmpWhole,tmpLoose;
            decimal tmpMrp, tmpDiscount, tmpCost, tmpTotalCost;
            //foreach (DataGridViewCell oneCell in dataGridProdDetails.SelectedCells)
            foreach (DataGridViewRow dataGridRow in dataGridProductList.Rows)
            {
                tmpProductID = Convert.ToInt32(dataGridRow.Cells[0].Value);
                tmpBatch = dataGridRow.Cells[2].Value.ToString();
                if (dataGridRow.Cells[3].Value != "")
                    tmpWhole = Convert.ToInt32(dataGridRow.Cells[3].Value);
                else
                    tmpWhole = 0;
                if (dataGridRow.Cells[4].Value != "")
                    tmpLoose = Convert.ToInt32(dataGridRow.Cells[4].Value);
                else
                    tmpLoose = 0;
                tmpMrp = Convert.ToDecimal(dataGridRow.Cells[7].Value);
                if (dataGridRow.Cells[8].Value != "")
                    tmpDiscount = Convert.ToDecimal(dataGridRow.Cells[8].Value);
                else
                    tmpDiscount = 0;
                tmpCost = Convert.ToDecimal(dataGridRow.Cells[9].Value);
                tmpTotalCost = Convert.ToDecimal(dataGridRow.Cells[10].Value);
                dt_invoice_details.Rows.Add(tmpProductID, tmpBatch, tmpWhole, tmpLoose, tmpMrp, tmpDiscount, tmpCost, tmpTotalCost);
            }
            string retMsg = objBALPurchaseBill.funcSaveInvoiceDetails(objBOPurchaseBill,dt_invoice_details);
            if (retMsg == "success")
            {
                MessageBox.Show("Invoice details saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show(retMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }


    }
}
