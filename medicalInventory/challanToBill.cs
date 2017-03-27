using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medicalInventory
{
    public partial class challanToBill : Form
    {
        
        public challanToBill(string refChallanNo, string refCustomerName, string refChallanAmount)
        {
            InitializeComponent();
            lblChallanNo.Text = refChallanNo;
            lblCustomerName.Text = refCustomerName;
            lblTotalMRP.Text = refChallanAmount;
        }

        private void lblChallanNo_Click(object sender, EventArgs e)
        {

        }

    }
}
