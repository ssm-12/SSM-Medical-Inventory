using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALPurchaseBillProductDetails
    {
        DALPurchaseBillProductDetails objDALPurchaseProductDetails = new DALPurchaseBillProductDetails();
        public System.Data.DataTable getInvoiceProductDetails(string invoiceNumber)
        { 
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objDALPurchaseProductDetails.getInvoiceProductDetails(invoiceNumber);
            return dt;
        }
    }
}
