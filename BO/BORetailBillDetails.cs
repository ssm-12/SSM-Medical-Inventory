﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BORetailBillDetails
    {
        public string searchBy { get; set; }
        public string searchText { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string invoiceNumber { get; set; }
    }
}
