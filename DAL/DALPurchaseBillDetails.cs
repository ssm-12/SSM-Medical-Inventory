using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public class DALPurchaseBillDetails
    {
        DB_Utility objDB_Utility;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public DataTable getInvoiceDetails(BOPurchaseBillDetails objBOPurchaseBillDetails)
        {
            string strCmd = "";
            try
            {
                //Initialization
                objDB_Utility = new DB_Utility();
                SqlConnection con = objDB_Utility.funcOpenConnection();
                if (objBOPurchaseBillDetails.searchBy == "Invoice Number" && objBOPurchaseBillDetails.searchText != "")
                {
                    strCmd = "SELECT sir.invoice_no, sm.supp_name, sir.total_mrp, sir.amount_ad, tr.debit_amount, sir.invoice_date  FROM supplier_invoice_record sir, supplier_master sm, supplier_transaction_record tr ";
                    strCmd += "WHERE (sir.supp_id=sm.supp_id AND sir.transaction_id=tr.transaction_id) ";
                    strCmd += "AND sir.invoice_no LIKE '"+objBOPurchaseBillDetails.searchText+"%' ";
                    strCmd += "AND (sir.invoice_date BETWEEN '"+objBOPurchaseBillDetails.fromDate+"' AND '"+objBOPurchaseBillDetails.toDate+"')";
                }
                else if (objBOPurchaseBillDetails.searchBy == "Supplier Name" && objBOPurchaseBillDetails.searchText != "")
                {
                    strCmd = "SELECT sir.invoice_no, sm.supp_name, sir.total_mrp, sir.amount_ad, tr.debit_amount, sir.invoice_date ";
                    strCmd += "FROM supplier_invoice_record sir, supplier_transaction_record tr, supplier_master sm ";
                    strCmd += "WHERE sir.supp_id = sm.supp_id AND sm.supp_id IN (SELECT supp_id FROM supplier_master WHERE supp_name LIKE '"+objBOPurchaseBillDetails.searchText+"%') ";
                    strCmd += "AND sir.transaction_id=tr.transaction_id AND (sir.invoice_date between '" + objBOPurchaseBillDetails.fromDate + "' AND '" + objBOPurchaseBillDetails.toDate + "')";
                }
                else if (objBOPurchaseBillDetails.searchText == "")
                {
                    strCmd = "SELECT sir.invoice_no, sm.supp_name, sir.total_mrp, sir.amount_ad, tr.debit_amount, sir.invoice_date ";
                    strCmd += "FROM supplier_invoice_record sir, supplier_transaction_record tr, supplier_master sm ";
                    strCmd += "WHERE sir.supp_id=sm.supp_id AND sir.transaction_id=tr.transaction_id ";
                    strCmd += "AND (sir.invoice_date BETWEEN '" + objBOPurchaseBillDetails.fromDate + "' AND '" + objBOPurchaseBillDetails.toDate + "') ";
                }
                cmd = new SqlCommand(strCmd, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Purchase_Invoice_Details");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                string filePath = @"..\ErrorLog.log";

                using (System.IO.StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error Code : 00014" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    writer.WriteLine(strCmd);
                }

                //Send datatable with error code
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("error");
                dt.Columns.Add(dc1);
                dt.Rows.Add("00014");
                return dt;

            }
            finally
            {
                objDB_Utility.funcCloseConnection();
            }
        }
    }
}
