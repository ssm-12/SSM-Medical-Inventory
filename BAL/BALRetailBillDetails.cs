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
    public class BALRetailBillDetails
    {
        DALRetailBillDetails objDALRetailBillDetails = new DALRetailBillDetails();
        public DataTable getInvoiceDetails(BORetailBillDetails objBORetailBillDetails)
        {
            DataTable dt = new DataTable();
            dt = objDALRetailBillDetails.getInvoiceDetails(objBORetailBillDetails);
            return dt;
        }
    }
}
