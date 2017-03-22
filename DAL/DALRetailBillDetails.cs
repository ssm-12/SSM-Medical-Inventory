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
    public class DALRetailBillDetails
    {
        DB_Utility objDB_Utility;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataTable getInvoiceDetails(BORetailBillDetails objBORetailBillDetails)
        {
            string strCmd = "";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                strCmd = "SELECT ric.invoice_no, ric.patient_name, ric.address, ric.contact_no, ric.doctor, ric.total_mrp, ric.discount,ric.net_amount ";
                strCmd += "FROM retail_invoice_record ric ";
                strCmd += "WHERE ric.invoice_date BETWEEN '"+objBORetailBillDetails.fromDate+"' AND '"+objBORetailBillDetails.toDate+"' ";
                if (objBORetailBillDetails.searchBy == "Invoice Number" && objBORetailBillDetails.searchText != "")
                {
                    strCmd +="AND ric.invoice_no like '"+objBORetailBillDetails.searchText+"%' "; 
                }
                else if (objBORetailBillDetails.searchBy == "Patient Name" && objBORetailBillDetails.searchText != "")
                {
                    strCmd +="AND ric.patient_name like '"+objBORetailBillDetails.searchText+"%' "; 
                }
                else if (objBORetailBillDetails.searchBy == "Contact Number" && objBORetailBillDetails.searchText != "")
                {
                    strCmd +="AND ric.contact_no like '"+objBORetailBillDetails.searchText+"%' "; 
                }
                else if (objBORetailBillDetails.searchBy == "Doctor" && objBORetailBillDetails.searchText != "")
                {
                    strCmd +="AND ric.doctor like '"+objBORetailBillDetails.searchText+"%' "; 
                }
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Retail_Invoice_Details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00024" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine(strCmd);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00024");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
