using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;
using System.Data;

namespace BAL
{
    public class BALSuppDetails
    {
        private DALSuppDetails objDALSuppDetails = new DALSuppDetails();
        public bool funcInsertSupDetails(BOSuppDetails objBOSuppDetails)
        {
            bool retVal = objDALSuppDetails.funcInsertSupDetails(objBOSuppDetails);
            return retVal;
        }

        public DataTable funcPopulateSupplierGrid(BOSuppDetails objSupDetails)
        {
            string condition;
            string strSearchBy = "";
            if (objSupDetails.searchBy == "Supplier ID")
                strSearchBy = "supp_id";
            else if (objSupDetails.searchBy == "Supplier Name")
                strSearchBy = "supp_name";
            else if (objSupDetails.searchBy == "Contact Number")
                strSearchBy = "contact_no";
            else if (objSupDetails.searchBy == "DL Number")
                strSearchBy = "DL_no";
            else if (objSupDetails.searchBy == "TIN Number")
                strSearchBy = "TIN_no";

            if (objSupDetails.searchTerm != "" && objSupDetails.searchBy != "")
            {
                condition = "WHERE ";
                condition += strSearchBy;
                condition += " like '";
                condition += objSupDetails.searchTerm;
                condition += "%'";
            }
            else
            {
                condition = "";
            }

            DataTable dt = new DataTable();
            dt = objDALSuppDetails.funcPopulateSupplierGrid(condition);
            return dt;
        }

        public bool funcUpdateSupplierMaster()
        {
            bool retVal = objDALSuppDetails.funcUpdateSupplierMaster();
            return retVal;
        }

        public int funcCheckDuplicateSup(BOSuppDetails objBOSupDetails)
        {
            int retVal = objDALSuppDetails.funcCheckDuplicateSup(objBOSupDetails);
            return retVal;
        }
    }


}
