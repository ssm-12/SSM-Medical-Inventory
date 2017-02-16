using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BOPurchaseBillProductDetails
    {
        public string invoiceNumber { get; set; }
        public string supplierName { get; set; }
        public string totalMRP { get; set; }
        public string invoiceAmount { get; set; }
        public string amountPaid { get; set; }
        public string invoiceDate { get; set; }
    }
}
