using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DB_Utility
    {
        static string strConnection = @"Data Source=SOUVIK_PC;Initial Catalog=DB_SSM_Medical_Inventory;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlConnection con;
        public SqlConnection funcOpenConnection()
        {
            con = new SqlConnection(strConnection);
            if (con.State != ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            return con;
        }

        public SqlConnection funcCloseConnection()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }

        public DataTable funcPopulateProductList()
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                SqlConnection con = funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT product_id, product_name FROM product_master", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00x001" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00x001");
                return dt;

            }
            finally
            {
                funcCloseConnection();
            }
        }


    }
}
