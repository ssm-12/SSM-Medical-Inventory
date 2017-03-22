using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALRetailBillProductDetails
    {
        DALRetailBillProductDetails objDALRetailProductDetails = new DALRetailBillProductDetails();
        public System.Data.DataTable getInvoiceProductDetails(string invoiceNumber)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objDALRetailProductDetails.getInvoiceProductDetails(invoiceNumber);
            return dt;
        }
    }
}
