using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BO;
using System.Data;


namespace BAL
{
    public class BALChallan
    {
        DALChallan objDALChallan = new DALChallan();

        public string getInvoiceID()
        {
            return objDALChallan.getInvoiceID();
        }

        public DataTable funcPopulateCustomerList()
        {
            return objDALChallan.funcPopulateCustomerList();
        }

        public DataTable funcPopulateProductList()
        {
            return objDALChallan.funcPopulateProductList();
        }

        public DataTable funcGetBatchDetails(string batchNo, string productID)
        {
            return objDALChallan.funcGetBatchDetails(batchNo, productID);
        }

        public string saveChallanDetails(BOChallan objChallan, DataTable productTable)
        {
            string retMsg;
            retMsg = objDALChallan.saveChallanDetails(objChallan, productTable);
            return retMsg;
        }
    }
}
