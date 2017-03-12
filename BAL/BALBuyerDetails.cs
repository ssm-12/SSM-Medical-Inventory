using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALBuyerDetails
    {
        DALBuyerDetails objDAbuyerDL = new DALBuyerDetails();

        public bool funcInsertCustDetails(BOBuyerDetails objBOCustDetails)
        {
            bool retVal = objDAbuyerDL.funcInsertCustDetails(objBOCustDetails);
            return retVal;
        }

        public int funcCheckDuplicateCust(BOBuyerDetails objBOCustDetails)
        {
            int retVal = objDAbuyerDL.funcCheckDuplicateCust(objBOCustDetails);
            return retVal;
        }

        public System.Data.DataTable funcPopulateCustGrid(BOBuyerDetails objBOBuyerDL)
        {
            string condition;
            string strSearchBy = "";
            if (objBOBuyerDL.searchBy == "Customer ID")
                strSearchBy = "cust_id";
            else if (objBOBuyerDL.searchBy == "Customer Name")
                strSearchBy = "cust_name";
            else if (objBOBuyerDL.searchBy == "Contact Number")
                strSearchBy = "contact_no";
            else if (objBOBuyerDL.searchBy == "DL Number")
                strSearchBy = "DL_no";
            else if (objBOBuyerDL.searchBy == "TIN Number")
                strSearchBy = "TIN_no";

            if (objBOBuyerDL.searchTerm != "" && objBOBuyerDL.searchBy != "")
            {
                condition = "WHERE ";
                condition += strSearchBy;
                condition += " like '";
                condition += objBOBuyerDL.searchTerm;
                condition += "%'";
            }
            else
            {
                condition = "";
            }

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objDAbuyerDL.funcPopulateCustGrid(condition);
            return dt;
        }

        public bool funcUpdateCustomerMaster()
        {
            bool retVal = objDAbuyerDL.funcUpdateCustomerMaster();
            return retVal;
        }

        public bool funcDeleteCustomerMaster(string custID)
        {
            bool retVal = objDAbuyerDL.funcDeleteCustomerRecord(custID);
            return retVal;
        }
    }
}
