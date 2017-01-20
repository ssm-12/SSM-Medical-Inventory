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
        public supplierDetails()
        {
            InitializeComponent();
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

                if (objBALSuppDetails.funcInsertSupDetails(objBOSuppDetails) == true)
                {
                    MessageBox.Show("Supplier Information Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcClearAllFields();
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
    }
}
