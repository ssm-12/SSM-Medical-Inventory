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
using System.Data;

namespace medicalInventory
{
    
    public partial class productDetails : Form
    {
        BALProductDetails objBALProductDetails = new BALProductDetails();
        BOProductDetails objBOProductDetails = new BOProductDetails();
        public productDetails(int tabNo)
        {
            InitializeComponent();
            funcOpenTabPage(tabNo);
        }

        /*
        private void funcPopulateBrand()
        {
            DataTable dt = new DataTable();
            dt = objBALProductDetails.funcPopulateBrand();
            //Failed Scenario
            if (dt.Columns.Count == 1)
            {
                string errorCode = Convert.ToString(dt.Rows[1]["error"]);
                MessageBox.Show("Unable Retreive Brands", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Success Scenario
            else
            {
                comboBrand.DataSource = dt;
                comboBrand.DisplayMember = Convert.ToString(dt.Columns[1]);
                comboBrand.ValueMember = Convert.ToString(dt.Columns[0]);
            }

        }
        */

        private void funcOpenTabPage(int pageNo)
        {
            if (pageNo == 1)
            {
                tabControl1.SelectedTab = tabPage1;
            }
            else if (pageNo == 2)
            {
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void productDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetBrand.Brand' table. You can move, or remove it, as needed.
            this.brandTableAdapter.Fill(this.dataSetBrand.Brand);
            // TODO: This line of code loads data into the 'dataSetGenerics.Generics' table. You can move, or remove it, as needed.
            this.genericsTableAdapter.Fill(this.dataSetGenerics.Generics);
            
        }

        private void comboBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBrand.DroppedDown = false;
        }
        private void comboGeneric_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboGeneric.DroppedDown = false;
        }

    }
}
