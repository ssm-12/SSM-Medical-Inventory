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
    public partial class productSelection_Popup : Form
    {
        static private string batchNo = "";
        BALProductSelection_PopUp objBALProductSelection_PopUp = new BALProductSelection_PopUp();

        public productSelection_Popup(string productID)
        {
            InitializeComponent();
            batchNo = "";
            System.Data.DataTable dtBatchList = objBALProductSelection_PopUp.populateProductDetails(productID);

            if (dtBatchList.Columns[0].ColumnName == "error")
            {
                string errorCode = Convert.ToString(dtBatchList.Rows[0]["error"]);
                MessageBox.Show("Unable to Retreive Product List", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                foreach (DataRow r in dtBatchList.Rows)
                {
                    dataGridProductList.Rows.Add(r.ItemArray);
                }
            }
        }
        public string getResult()
        {
            return batchNo;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if(keyData == Keys.Enter)
            {
                foreach (DataGridViewRow dRow in dataGridProductList.SelectedRows)
                {
                    if (dRow.Selected)
                    {
                        batchNo = dataGridProductList.Rows[dRow.Index].Cells[0].Value.ToString();
                        this.Close();
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
