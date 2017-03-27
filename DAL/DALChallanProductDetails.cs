using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALChallanProductDetails
    {
        DB_Utility objDB_Utility;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataTable getChallanProductDetails(string challanNo)
        {
            string strCmd = "";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                strCmd = "SELECT ins.batch_no, pm.product_name, ins.packing, cd.whole_quant, cd.loose_quant, cd.mrp_per_strip, cd.total_amount ";
                strCmd += "FROM challan_details cd, product_master pm, InStock ins ";
                strCmd += "WHERE cd.challan_no='" + challanNo + "' AND cd.batch_no=ins.batch_no ";
                strCmd += "AND pm.product_id = ins.product_id ";
                strCmd += "AND pm.product_id = (SELECT product_id FROM InStock WHERE batch_no=cd.batch_no) ";
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Challan_Product_Details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00031" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine(strCmd);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00031");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
