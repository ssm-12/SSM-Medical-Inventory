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
         
    }
}
