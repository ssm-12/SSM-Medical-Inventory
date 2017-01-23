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
    public class DALBuyerDetails
    {
        DB_Utility objDB_Utility;

        public int SaveBuyerDetails(BOBuyerDetails objBObuyerDL)
        {
            int result=0;
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertBuyerDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Code to Insert Supplier Details Data into Database using stored procedure
                cmd.Parameters.AddWithValue("@cust_id", 0);
                cmd.Parameters.AddWithValue("@cust_name", objBObuyerDL.buyerName);
                cmd.Parameters.AddWithValue("@DL_no", objBObuyerDL.buyerLlNo);
                cmd.Parameters.AddWithValue("@TIN_no",objBObuyerDL.buyerTinNo );
                cmd.Parameters.AddWithValue("@address_line1", objBObuyerDL.buyerAddr1);
                cmd.Parameters.AddWithValue("@address_line2", objBObuyerDL.buyerAddr2);
                cmd.Parameters.AddWithValue("@contact_no", objBObuyerDL.buyerContactNo);
                cmd.Parameters.AddWithValue("@email", objBObuyerDL.buyerEmailId);
                cmd.Parameters.AddWithValue("@modified_date_time", System.DateTime.Today );
                
                result=cmd.ExecuteNonQuery();
                return result;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 10000" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return result;
            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
