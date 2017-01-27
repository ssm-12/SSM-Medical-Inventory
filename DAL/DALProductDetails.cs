using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BO;
using System.IO;

namespace DAL
{
    public class DALProductDetails
    {
        DB_Utility objDB_Utility;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public DataTable funcPopulateBrand()
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                cmd = new SqlCommand("SELECT * FROM brand", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00002" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00002");
                return dt;
                
            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public DataTable funcPopulateGeneric()
        {
            DataTable dt = new DataTable();
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM generics", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00004" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00004");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public bool funcInsertProdDetails(BOProductDetails objBOProdDetails)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                SqlCommand cmd = new SqlCommand("sp_insertProductMaster", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Code to Insert Supplier Details Data into Database using stored procedure
                cmd.Parameters.AddWithValue("@product_id", 0);
                cmd.Parameters.AddWithValue("@product_name", objBOProdDetails.medName);
                cmd.Parameters.AddWithValue("@company", objBOProdDetails.company);
                cmd.Parameters.AddWithValue("@contents", objBOProdDetails.contents);
                cmd.Parameters.AddWithValue("@generic", objBOProdDetails.genericName);
                cmd.Parameters.AddWithValue("@packing", objBOProdDetails.packing);
                cmd.Parameters.AddWithValue("@unit", objBOProdDetails.unit);
                cmd.Parameters.AddWithValue("@schedule", objBOProdDetails.schedule);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00003" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
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


        public DataTable funcPopulateProductGrid(string condition)
        {
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                string strCmd = "SELECT product_id as \"Product ID\", product_name as \"Product Name\", company as \"Brand/Company\", ";
                strCmd += "contents as \"Contents\", Generic as \"Generic Name\", packing as \"Packing\", ";
                strCmd += "unit as \"Unit\", schedule as \"Schedule\", ";
                strCmd += "modified_date_time as \"Date\" ";
                strCmd += "FROM product_master " + condition;
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Product_Details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00005" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00005");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }

        public bool funcUpdateProductMaster()
        {
            try
            {
                SqlCommandBuilder cmb1 = new SqlCommandBuilder(da);
                da.Update(ds, "Product_Details");
                return true;
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00007" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return false;
            }
        }
    }
}
