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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            objBOlogin.userName = txtUserName.Text;
            objBOlogin.password = txtPassword.Text;

            objBAlogin.funcAuthenticate(objBOlogin);

            MainMenu frmMainMenu = new MainMenu();
            frmMainMenu.Show();

            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            Application.Exit();
        }
    }
}
