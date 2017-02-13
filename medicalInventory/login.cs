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
    public partial class login : Form
    {
        BALlogin objBAlogin = new BALlogin();
        BOlogin objBOlogin = new BOlogin();

        public login()
        {
            InitializeComponent();
            txtPassword.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int val;
            objBOlogin.userName = txtPassword.Text;
            objBOlogin.password = txtUserName.Text;

            val=objBAlogin.funcAuthenticate(objBOlogin);
            if (val == -1)
            {
                MessageBox.Show("Unable to connect Database", "Connectivity Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(val!=1)
            {
                MessageBox.Show("Invalid Login Credentials!!! Please try again");
                txtPassword.Text = "";
                txtUserName.Text = "";
                txtUserName.Focus();
                //Failure Msg

            }
            else
            {
                MainMenu frmMainMenu = new MainMenu();
                frmMainMenu.Show();
                this.Hide();
            }
        }
        private void txtPassword_keypress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(sender, e);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
    }
}
