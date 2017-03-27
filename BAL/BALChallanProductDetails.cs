using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALChallanProductDetails
    {
        DALChallanProductDetails objDALChallanProdDetails = new DALChallanProductDetails();
        public System.Data.DataTable getChallanProductDetails(string challanNo)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objDALChallanProdDetails.getChallanProductDetails(challanNo);
            return dt;
        }
    }
}
