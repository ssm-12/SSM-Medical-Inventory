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
        DALBuyerDetails DAbuyerDL=new DALBuyerDetails();

        public int SaveBuyerDetails(BOBuyerDetails BObuyerDL)
        {
          //  return DAbuyerDL.SaveBuyerDetails(BObuyerDL);
            return 0;
        }
    }
}
