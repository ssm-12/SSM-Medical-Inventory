using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class DALSuppDetails
    {
        DB_Utility objDB_Utility;
        public bool funcInsertSupDetails(BOSuppDetails objBOSupDetails)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("sp_insertSupDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Code to Insert Supplier Details Data into Database using stored procedure
                cmd.Parameters.AddWithValue("@sup_id", 0);
                cmd.Parameters.AddWithValue("@sup_name", objBOSupDetails.suppName);
                cmd.Parameters.AddWithValue("@dl_no", objBOSupDetails.dlNo);
                cmd.Parameters.AddWithValue("@tin_no", objBOSupDetails.tinNo);
                cmd.Parameters.AddWithValue("@addr1", objBOSupDetails.addr1);
                cmd.Parameters.AddWithValue("@addr2", objBOSupDetails.addr2);
                cmd.Parameters.AddWithValue("@contact_no", objBOSupDetails.contactNo);
                cmd.Parameters.AddWithValue("@email_id", objBOSupDetails.emailId);
                cmd.Parameters.AddWithValue("@modified_date_time", System.DateTime.Today);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch(Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00001" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return false;
            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
