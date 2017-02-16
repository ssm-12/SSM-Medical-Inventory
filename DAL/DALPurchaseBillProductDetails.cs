using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public class DALPurchaseBillProductDetails
    {
        DB_Utility objDB_Utility;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataTable getInvoiceProductDetails(string invoiceNumber)
        {
            string strCmd = "";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                strCmd = "SELECT supinv.batch_no, prm.product_name, supinv.packing, supinv.whole_quant, supinv.loose_quant, supinv.mrp_ps, supinv.discount, ";
                strCmd += "supinv.cost_per_unit, supinv.total_cost ";
                strCmd += "FROM supplier_invoice_details supinv,InStock ins,product_master prm ";
                strCmd += "WHERE supinv.invoice_no = '"+invoiceNumber+"' AND supinv.batch_no=ins.batch_no ";
                strCmd += "AND prm.product_id = ins.product_id ";
                strCmd += "AND prm.product_id = (SELECT product_id FROM InStock WHERE batch_no = supinv.batch_no)";
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Invoice_Product_Details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00015" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine(strCmd);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00015");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
