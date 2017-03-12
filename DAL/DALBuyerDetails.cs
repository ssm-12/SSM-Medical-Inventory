using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace DAL
{
    public class DALBuyerDetails
    {
        DB_Utility objDB_Utility;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        public bool funcInsertCustDetails(BOBuyerDetails objBOBuyerDetails)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("sp_insertCustDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Code to Insert Supplier Details Data into Database using stored procedure
                cmd.Parameters.AddWithValue("@cust_name", objBOBuyerDetails.buyerName);
                cmd.Parameters.AddWithValue("@dl_no", objBOBuyerDetails.buyerDLNo);
                cmd.Parameters.AddWithValue("@tin_no", objBOBuyerDetails.buyerTinNo);
                cmd.Parameters.AddWithValue("@addr1", objBOBuyerDetails.buyerAddr1);
                cmd.Parameters.AddWithValue("@addr2", objBOBuyerDetails.buyerAddr2);
                cmd.Parameters.AddWithValue("@contact_no", objBOBuyerDetails.buyerContactNo);
                cmd.Parameters.AddWithValue("@email_id", objBOBuyerDetails.buyerEmailId);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00016" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
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
        public int funcCheckDuplicateCust(BOBuyerDetails objBOBuyerDetails)
        {
            objDB_Utility = new DB_Utility();
            try
            {
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM customer_master WHERE UPPER(cust_name)=UPPER(@cust_name)", con);
                cmd.Parameters.AddWithValue("@cust_name", objBOBuyerDetails.buyerName);
                int retVal = Convert.ToInt32(cmd.ExecuteScalar());
                return retVal;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public DataTable funcPopulateCustGrid(string condition)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                string strCmd = "SELECT cust_id as \"Customer ID\", cust_name as \"Customer Name\", DL_no as \"DL Number\", ";
                strCmd += "TIN_no as \"TIN Number\", address_line1 as \"Address Line1\", address_line2 as \"Address Line2\", ";
                strCmd += "contact_no as \"Contact\", email as \"Email ID\", ";
                strCmd += "modified_date_time as \"Date\" ";
                strCmd += "FROM customer_master " + condition;
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Customer_Details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00017" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00017");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public bool funcDeleteCustomerRecord(string custID)
        {
            objDB_Utility = new DB_Utility();
            try
            {
                //Set a flag inactive for that customer record && also populate only active customers
                /*
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM cust_amount_receivable WHERE cust_id=@cust_id", con);
                cmd.Parameters.AddWithValue("@cust_id", custID);
                cmd.ExecuteNonQuery();
                 */
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public bool funcUpdateCustomerMaster()
        {
            try
            {
                SqlCommandBuilder cmb1 = new SqlCommandBuilder(da);
                da.Update(ds, "Customer_Details");
                return true;
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00018" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return false;
            }
        }
    }
}
