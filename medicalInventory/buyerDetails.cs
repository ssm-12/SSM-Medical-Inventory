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
        BALBuyerDetails BALbuyerDL = new BALBuyerDetails();
        BOBuyerDetails BObuyerDL = new BOBuyerDetails();
        public buyerDetails()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BObuyerDL.buyerName = txtBuyerName.Text;
                BObuyerDL.buyerContactNo = txtBuyerContact.Text;
                BObuyerDL.buyerAddr1 = txtBuyerAddr1.Text;
                BObuyerDL.buyerAddr2 = txtBuyerAddr2.Text;
                BObuyerDL.buyerLlNo = txtBuyerDL.Text;
                BObuyerDL.buyerTinNo = txtBuyerTIN.Text;
                BObuyerDL.buyerEmailId = txtBuyerEmail.Text;

                int result = BALbuyerDL.SaveBuyerDetails(BObuyerDL);
                if(result>0)
                {
                    //Display Confirmation Message
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
                BALbuyerDL = null;
                BObuyerDL = null;
            }
        }

        private void buyerDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_SSM_Medical_InventoryDataSet.customer_master' table. You can move, or remove it, as needed.
            this.customer_masterTableAdapter.Fill(this.dB_SSM_Medical_InventoryDataSet.customer_master);

        }
    }
}
