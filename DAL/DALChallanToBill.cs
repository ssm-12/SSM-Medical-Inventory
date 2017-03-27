using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;

namespace DAL
{
    public class DALChallanToBill
    {
        DB_Utility objDB_Utility;
        public string getInvoiceID()
        {
            int invoiceID_suffix;
            string invoice_no = "RTL";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(invoice_no)+1 FROM retail_invoice_record", con);
                invoiceID_suffix = Convert.ToInt32(cmd.ExecuteScalar());
                invoice_no += invoiceID_suffix.ToString();
                return invoice_no;
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00020" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                return "error";

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
