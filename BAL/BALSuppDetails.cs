using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALSuppDetails
    {
        private DALSuppDetails objDALSuppDetails = new DALSuppDetails();
        public bool funcInsertSupDetails(BOSuppDetails objBOSuppDetails)
        {
            bool retVal = objDALSuppDetails.funcInsertSupDetails(objBOSuppDetails);
            return retVal;
        }
    }
}
