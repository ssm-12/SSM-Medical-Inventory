using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALChallanDetails
    {
        DALChallanDetails objDALChallanDetails = new DALChallanDetails();
        public System.Data.DataTable getChallanDetails(BOChallanDetails objBOChallanDetails)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objDALChallanDetails.getChallanDetails(objBOChallanDetails);
            return dt;
        }
    }
}
