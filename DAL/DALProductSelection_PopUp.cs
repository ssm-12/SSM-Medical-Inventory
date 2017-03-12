using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALProductSelection_PopUp
    {
        DB_Utility objDB_Utility;
        public DataTable populateProductDetails(string productID)
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                string cmdStr = "SELECT batch_no,FORMAT(expiry,'MM/yyyy'), whole_quant, ";
                cmdStr += "loose_quant, CONCAT('1*',packing), mrp, rack_no FROM InStock ";
                cmdStr += "WHERE product_id = '"+productID+"'";
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00021" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00021");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
