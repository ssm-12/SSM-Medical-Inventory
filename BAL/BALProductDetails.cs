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
    public class BALProductDetails
    {
        DALProductDetails objDALProductDetails = new DALProductDetails();
        
        public DataTable funcPopulateBrand()
        {
            DataTable dt = new DataTable();
            dt = objDALProductDetails.funcPopulateBrand();
            return dt;
        }

        public DataTable funcPopulateGeneric()
        {
            DataTable dt = new DataTable();
            dt = objDALProductDetails.funcPopulateGeneric();
            return dt;
        }

        public bool funcInsertProductMaster(BOProductDetails objBOProdDetails)
        {
            bool retVal = objDALProductDetails.funcInsertProdDetails(objBOProdDetails);
            return retVal;
        }

        public DataTable funcPopulateProductGrid(BOProductDetails objBOProductDetails)
        {
            string condition;
            string strSearchBy="";
            if(objBOProductDetails.searchBy == "Product ID")
                strSearchBy = "product_id";
            else if(objBOProductDetails.searchBy == "Product Name")
                strSearchBy = "product_name";
            else if (objBOProductDetails.searchBy == "Brand")
                strSearchBy = "company";
            else if(objBOProductDetails.searchBy == "Generic Name")
                strSearchBy = "generic";

            if (objBOProductDetails.searchTerm != "" && objBOProductDetails.searchBy != "")
            {
                condition = "WHERE ";
                condition += strSearchBy;
                condition += " like '";
                condition += objBOProductDetails.searchTerm;
                condition += "%'";
            }
            else
            {
                condition = "";
            }

            DataTable dt = new DataTable();
            dt = objDALProductDetails.funcPopulateProductGrid(condition);
            return dt;
        }

        public bool funcUpdateProductMaster()
        {
            bool retVal = objDALProductDetails.funcUpdateProductMaster();
            return retVal;
        }
         
    }
}
