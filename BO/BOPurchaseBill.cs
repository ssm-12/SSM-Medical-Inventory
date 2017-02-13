using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BOPurchaseBill
    {
        public string supplier_name { get; set; }
        public int supplier_id { get; set; }
        public string invoice_number { get; set; }
        public string transaction_id { get; set; }
        public DateTime invoice_date { get; set; }
        public decimal MyProperty { get; set; }
        public string product_name { get; set; }
        public int product_id { get; set; }
        public string batch_no { get; set; }
        public int stripQuantity { get; set; }
        public int tabQuantity { get; set; }
        public decimal mrp { get; set; }
        public decimal discount { get; set; }
        public decimal cost_per_unit { get; set; }
        public string mfgMonth { get; set; }
        public string mfgYear { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public string rackNo { get; set; }
        public decimal totalMRP { get; set; }
        public decimal totalCost { get; set; }
        public decimal dueAmount { get; set; }
        public decimal amount_paid { get; set; }
        public string payment_method { get; set; }
    }
}
