using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BO;

namespace DAL
{
    public class DALChallanDetails
    {
        DB_Utility objDB_Utility;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataTable getChallanDetails(BOChallanDetails objBOChallanDetails)
        {
            string strCmd = "";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                strCmd = "SELECT cr.challan_no, cm.cust_name, cr.challan_amount, cr.converted_to_bill_flag, cr.challan_date ";
                strCmd += "FROM challan_record cr, customer_master cm ";
                strCmd += "WHERE cr.challan_date BETWEEN '"+objBOChallanDetails.fromDate+"' AND '"+objBOChallanDetails.toDate+"' ";
                strCmd += "AND cr.cust_id = cm.cust_id ";
                if (objBOChallanDetails.searchBy == "Challan No." && objBOChallanDetails.searchText != "")
                {
                    strCmd += "AND cr.challan_no like '"+objBOChallanDetails.searchText+"%' ";
                }
                else if (objBOChallanDetails.searchBy == "Customer Name" && objBOChallanDetails.searchText != "")
                {
                    strCmd += "AND cr.cust_id IN (SELECT cust_id FROM customer_master WHERE cust_name like '"+objBOChallanDetails.searchText+"%') ";
                }
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "challan_details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00030" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine(strCmd);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00030");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
