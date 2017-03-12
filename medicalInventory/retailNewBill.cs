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
    public partial class retailNewBill : Form
    {
        BALRetailNewBill objBALRetailNewBill = new BALRetailNewBill();
        private static string batchNumber = "";
        public retailNewBill()
        {
            InitializeComponent();
        }

        private void retailNewBill_Load(object sender, EventArgs e)
        {
            funcPopulateProductList();
            getInvoiceID();
        }

        private void getInvoiceID()
        {
            string retVal = objBALRetailNewBill.getInvoiceID();
            if (retVal == "error")
            {
                MessageBox.Show("Unable to get new invoice ID. Please double click on the invoice number field to enter manually", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceNo.Select();
            }
            else
            {
                txtInvoiceNo.Text = retVal;
                txtPatientName.Select();
            }
        }

        private void funcPopulateProductList()
        {
            DataTable dt = new DataTable();
            dt = objBALRetailNewBill.funcPopulateProductList();
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

       private void clearGlobal(object sender, System.EventArgs e)
       {
           batchNumber = "";
       }

        private void txtInvoiceNo_DoubleClickEvent(object sender, EventArgs e)
        {
            txtInvoiceNo.ReadOnly = false;
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
            if (!Regex.Match(txtStrip.Text, @"^[0-9]+$").Success && txtStrip.Text != "")
            {
                MessageBox.Show("Quantity should be numeric value only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStrip.Select();
                return;
            }
            if (!Regex.Match(txtTab.Text, @"^[0-9]+$").Success && txtTab.Text != "")
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

            DataTable dt = objBALRetailNewBill.funcGetBatchDetails(batchNumber, comboProductList.SelectedValue.ToString());
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
                available_quant = (available_strip*packing)+available_tab;
                selling_quant = (strip*packing)+tab;
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            funcCalculate();
        }

        private bool funcCalculate()
        {
            decimal bill_amount = 0, discount, amount_payable = 0;
            if (!Regex.Match(txtDiscount.Text, @"^[0-9,.]+$").Success && txtDiscount.Text != "")
            {
                MessageBox.Show("Discount Percentage should be numeric only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiscount.Select();
                return false;
            }
            if (txtDiscount.Text == "")
            {
                discount = 0;
            }
            else
            {
                discount = Convert.ToDecimal(txtDiscount.Text);
            }
            discount = Math.Round(discount, 2);
            foreach (DataGridViewRow drow in dataGridProductList.Rows)
            {
                bill_amount += Convert.ToDecimal(drow.Cells[8].Value);
            }
            lblBillAmount.Text = bill_amount.ToString();
            amount_payable = bill_amount * ((100 - discount) / 100);
            amount_payable = Math.Round(amount_payable, 2);
            lblAmountPayable.Text = amount_payable.ToString();
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!funcCalculate())
            {
                return;
            }
            if (Regex.IsMatch(txtInvoiceNo.Text, @"^[0-9,a-z,A-Z]{1,20}$") == false)
            {
                MessageBox.Show("Invalid Invoice Number, Please enter valid Invoice Number", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceNo.Select();
                return;
            }
            if (dataGridProductList.Rows.Count == 0)
            {
                MessageBox.Show("No product(s) selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProductList.Select();
                return;
            }
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            if (!funcCalculate())
            {
                return;
            }
            if (Regex.IsMatch(txtInvoiceNo.Text, @"^[0-9,a-z,A-Z]{1,20}$") == false)
            {
                MessageBox.Show("Invalid Invoice Number, Please enter valid Invoice Number", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceNo.Select();
                return;
            }
            if (dataGridProductList.Rows.Count == 0)
            {
                MessageBox.Show("No product(s) selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboProductList.Select();
                return;
            }
            
        }
    }
}
