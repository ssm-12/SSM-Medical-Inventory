using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class BALProductSelection_PopUp
    {
        DALProductSelection_PopUp objDALProductSelection_PopUp = new DALProductSelection_PopUp();
        public System.Data.DataTable populateProductDetails(string productID)
        {
            return objDALProductSelection_PopUp.populateProductDetails(productID);
        }
    }
}
