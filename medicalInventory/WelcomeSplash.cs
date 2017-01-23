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
    public partial class splash : Form
    {
        [STAThread]
        static int Main(string[] args)
        {
            //...
            Application.Run(new splash());
            return 0;
        }

        public splash()
        {
            InitializeComponent();
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;

            if (progressBar.Value == 100)
            {
                timer1.Enabled = false;
                MessageBox.Show("Welcome to SSM Medical Inverntory System.");
                login frmLogin = new login();
                frmLogin.Show();
                this.Hide();
            }
            else
                progressBar.Value++;




        }
    }
}
