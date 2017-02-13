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
    public class BALPurchaseBill
    {
        DALPurchaseBill objDALpurchaseBill = new DALPurchaseBill();

        public DataTable funcPopulateSupplierList()
        {
            return objDALpurchaseBill.funcPopulateSupplierList();
        }

        public DataTable funcPopulateProductList()
        {
            return objDALpurchaseBill.funcPopulateProductList();
        }

        public string funcCheckProductPacking(BOPurchaseBill objBOPurchaseBill)
        {
            string packing = objDALpurchaseBill.funcCheckProductPacking(objBOPurchaseBill);
            return packing;
        }

        public string funcSaveInvoiceDetails(BOPurchaseBill objBOPurchaseBill, DataTable dtSupInvoiveDetails)
        {
            return objDALpurchaseBill.funcSaveInvoiceDetails(objBOPurchaseBill, dtSupInvoiveDetails);
        }
    }
}
