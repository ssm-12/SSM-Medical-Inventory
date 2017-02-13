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

namespace medicalInventory
{
    public partial class updateProductPacking : Form
    {
        static string prodID, prodName;
        BALUpdateProductPacking objBALUpdateProdPacking = new BALUpdateProductPacking();
        public updateProductPacking(string id, string name)
        {
            InitializeComponent();
            prodID = id;
            prodName = name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateProductPacking_Load(object sender, EventArgs e)
        {
            lblProductID.Text = prodID;
            lblProductName.Text = prodName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtPacking.Text.All(char.IsNumber) || txtPacking.Text == "")
            {
                MessageBox.Show("Please enter numeric values", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (objBALUpdateProdPacking.funcUpdateProdPacking(prodID, txtPacking.Text) == true)
            {
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Updation Failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
