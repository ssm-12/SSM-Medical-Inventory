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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        //Customer Details - Button Click
        private void btnStock_click(object sender, EventArgs e)
        {
            stock frmStock = new stock();
            frmStock.MdiParent = this;
            frmStock.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            

            
        }

        private void btNewOrder_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
 	        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }
    }
}