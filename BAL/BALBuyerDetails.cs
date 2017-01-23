using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALBuyerDetails
    {
        DALBuyerDetails objDAbuyerDL = new DALBuyerDetails();

        public int SaveBuyerDetails(BOBuyerDetails objBObuyerDL)
        {
            return objDAbuyerDL.SaveBuyerDetails(objBObuyerDL);
        }
    }
}
