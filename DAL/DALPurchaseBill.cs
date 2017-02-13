using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class DALPurchaseBill
    {
        DB_Utility objDB_Utility;
        public DataTable funcPopulateSupplierList()
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT supp_id, supp_name FROM supplier_master", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00009" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00009");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public DataTable funcPopulateProductList()
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT product_id, product_name FROM product_master", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00010" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00010");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public string funcCheckProductPacking(BOPurchaseBill objBOPurchaseBill)
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                string cmdText = "SELECT packing FROM product_master WHERE product_id = ";
                cmdText += objBOPurchaseBill.product_id;
                SqlCommand cmd = new SqlCommand(cmdText, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return Convert.ToString(dt.Rows[0]["packing"]);

            }
            catch(Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00011" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return null;
            }

            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public string funcSaveInvoiceDetails(BOPurchaseBill objBOPurchaseBill,DataTable dtSupplierInvoiceDetails)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("sp_saveSupInvoiceDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Code to Insert Supplier Details Data into Database using stored procedure
                cmd.Parameters.AddWithValue("@invoice_no", objBOPurchaseBill.invoice_number);
                cmd.Parameters.AddWithValue("@supp_id", objBOPurchaseBill.supplier_id);
                cmd.Parameters.AddWithValue("@total_mrp", objBOPurchaseBill.totalMRP);
                cmd.Parameters.AddWithValue("@discount", objBOPurchaseBill.discount);
                cmd.Parameters.AddWithValue("@amount_ad", objBOPurchaseBill.totalCost);
                cmd.Parameters.AddWithValue("@amount_paid", objBOPurchaseBill.amount_paid);
                cmd.Parameters.AddWithValue("@payment_method", objBOPurchaseBill.payment_method);
                cmd.Parameters.AddWithValue("@invoice_date", objBOPurchaseBill.invoice_date);
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@dt_supplier_invoice", dtSupplierInvoiceDetails);
                //tvparam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();
                return "success";

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00013" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
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
