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
        static string strConnection = @"Data Source=SOUVIK_PC;Initial Catalog=DB_SSM_Medical_Inventory;Integrated Security=True";
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


    }
}
