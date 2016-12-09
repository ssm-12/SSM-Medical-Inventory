using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;

namespace DAL
{
    public class DALlogin
    {
        DB_Utility objDB_Util;
       public int funcAuthenticate(BOlogin objBOlogin)
       {
           try
           {
               objDB_Util = new DB_Utility();
               SqlConnection con = objDB_Util.funcOpenConnection();
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = con;
               cmd.CommandText = "SELECT count(*) FROM tblLogin WHERE username = '" + objBOlogin.userName.ToString() + "' and password = '" + objBOlogin.password.ToString() + "'";
               int retVal = (int)cmd.ExecuteScalar();
               return retVal;
           }
           catch
           {
               //exception handling for login
               throw;
           }
           finally
           {
               objDB_Util.funcCloseConnection();
           }

           

           
       }
    }
}
