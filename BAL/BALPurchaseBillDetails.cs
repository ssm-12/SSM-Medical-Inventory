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
    public class BALPurchaseBillDetails
    {
        DALPurchaseBillDetails objDALPurchaseBillDetails = new DALPurchaseBillDetails();
        public System.Data.DataTable getInvoiceDetails(BOPurchaseBillDetails objBOPurchaseBillDetails)
        {
            DataTable dt = new DataTable();
            dt = objDALPurchaseBillDetails.getInvoiceDetails(objBOPurchaseBillDetails);
            return dt;
        }
        
    }
}
