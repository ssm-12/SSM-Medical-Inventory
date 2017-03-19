using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BORetailNewBill
    {
        public string invoiceNumber { get; set; }
        public DateTime invoiceDate { get; set; }
        public string patientName { get; set; }
        public string address { get; set; }
        public string contactNumber { get; set; }
        public string doctorName { get; set; }
        public string totalMRP { get; set; }
        public string discount { get; set; }
        public string amountPayable { get; set; }
    }
}
