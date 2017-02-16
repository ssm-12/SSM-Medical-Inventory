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
    public partial class buyerDetails : Form
    {
        BALBuyerDetails objBALbuyerDL = new BALBuyerDetails();
        BOBuyerDetails objBObuyerDL = new BOBuyerDetails();
        public buyerDetails()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objBObuyerDL.buyerName = txtBuyerName.Text;
                objBObuyerDL.buyerContactNo = txtBuyerContact.Text;
                objBObuyerDL.buyerAddr1 = txtBuyerAddr1.Text;
                objBObuyerDL.buyerAddr2 = txtBuyerAddr2.Text;
                objBObuyerDL.buyerLlNo = txtBuyerDL.Text;
                objBObuyerDL.buyerTinNo = txtBuyerTIN.Text;
                objBObuyerDL.buyerEmailId = txtBuyerEmail.Text;

                int result = objBALbuyerDL.SaveBuyerDetails(objBObuyerDL);
                if(result>0)
                {
                    //Display Confirmation Message
                    lblMsg.Text = "Record Saved Successfully!";
                }
                else
                {
                    //Display Error Message
                }
            }
            catch(Exception ex)
            {
                //Error Handling
                throw;
            }
            finally
            {
                objBALbuyerDL = null;
                objBObuyerDL = null;
            }
        }

        private void buyerDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
