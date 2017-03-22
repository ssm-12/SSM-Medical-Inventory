using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BORetailBillProductDetails
    {
        public string invoiceNumber { get; set; }
        public string patientName { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string prescribedBy { get; set; }
        public string totalMRP { get; set; }
        public string discount { get; set; }
        public string invoiceAmount { get; set; }
    }
}
