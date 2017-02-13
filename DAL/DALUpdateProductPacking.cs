using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class DALUpdateProductPacking
    {
        DB_Utility objDB_Utility;
        public bool funcUpdateProdPacking(string id, string packing)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                string commandText = "Update product_master SET packing='"+packing+"' WHERE product_id = "+id+"";
                SqlCommand cmd = new SqlCommand(commandText, con);

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00012" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
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
