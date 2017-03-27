using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using BO;

namespace DAL
{
    public class DALChallan
    {
        DB_Utility objDB_Utility;
        public string getInvoiceID()
        {
            int invoiceID_suffix;
            string invoice_no = "CHL";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(challan_no)+1 FROM challan_record", con);
                invoiceID_suffix = Convert.ToInt32(cmd.ExecuteScalar());
                invoice_no += invoiceID_suffix.ToString();
                return invoice_no;
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00026" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
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

        public DataTable funcPopulateProductList()
        { 
            objDB_Utility = new DB_Utility();
            return objDB_Utility.funcPopulateProductList();
        }

        public DataTable funcPopulateCustomerList()
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT cust_id, cust_name FROM customer_master", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00027" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00027");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public DataTable funcGetBatchDetails(string batchNo, string productID)
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                string cmdStr = "SELECT inst.batch_no,pmas.product_name,CONCAT('1*',inst.packing), FORMAT(inst.expiry,'MM/yyyy'), pmas.schedule,inst.mrp, inst.whole_quant, inst.loose_quant ";
                cmdStr += "FROM InStock inst, product_master pmas ";
                cmdStr += "WHERE inst.product_id = pmas.product_id AND inst.batch_no = '" + batchNo + "' ";
                cmdStr += "AND inst.product_id = '" + productID + "' ";
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00028" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00028");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public string saveChallanDetails(BOChallan objBOChallan, DataTable productTable)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("sp_saveChallanDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Code to Insert Supplier Details Data into Database using stored procedure
                cmd.Parameters.AddWithValue("@challan_no", objBOChallan.challanNumber);
                cmd.Parameters.AddWithValue("@customer_id", objBOChallan.customerID);
                cmd.Parameters.AddWithValue("@challan_amount", objBOChallan.challanAmount);
                cmd.Parameters.AddWithValue("@payment_method", "cash");
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@dt_product_list", productTable);
                //tvparam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();
                return "success";

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00029" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return ex.Message;
            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
