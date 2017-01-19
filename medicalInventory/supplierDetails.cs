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
    public partial class supplierDetails : Form
    {
        BALSuppDetails objBALSuppDetails = new BALSuppDetails();
        BOSuppDetails objBOSuppDetails = new BOSuppDetails();
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

                if (objBALSuppDetails.funcInsertSupDetails() == true)
                {
                    MessageBox.Show("Supplier Information Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TO DO: Clear all the text fields, set focus to name
                }
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
            if (!txtName.Text.All(char.IsLetterOrDigit))
            {
                strMsg += "Enter Supplier Name\n";
                retVal = false;
            }


            if (txtContact.Text == "")
            {
                strMsg += "Enter Contact Number \n";
                retVal = false;
            }
            if (!txtContact.Text.All(char.IsNumber))
            {
                strMsg += "Contact Number should only contain numbers \n";
                retVal = false;
            }

            if (retVal == false)
                MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return retVal;
        }
    }
}
