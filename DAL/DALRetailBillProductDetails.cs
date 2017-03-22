using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public class DALRetailBillProductDetails
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
                strCmd = "SELECT rid.batch_no, pms.product_name, pms.packing, rid.whole_quant, rid.loose_quant, rid.mrp_ps, rid.discount, rid.mrp_ps_ad, rid.total_amount ";
                strCmd += "FROM InStock ins, retail_invoice_details rid, product_master pms ";
                strCmd += "WHERE rid.invoice_no = '"+invoiceNumber+"' and rid.batch_no = ins.batch_no ";
                strCmd += "AND pms.product_id = ins.product_id ";
                strCmd += "AND pms.product_id = (SELECT product_id FROM InStock WHERE batch_no=rid.batch_no) ";
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
                    writer.WriteLine("Error Code : 00025" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine(strCmd);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00025");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
