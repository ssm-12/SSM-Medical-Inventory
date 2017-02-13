using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class BALUpdateProductPacking
    {
        DALUpdateProductPacking objDALUpdateProdPacking = new DALUpdateProductPacking();

        public bool funcUpdateProdPacking(string id,string packing)
        {
            return objDALUpdateProdPacking.funcUpdateProdPacking(id, packing);
        }
    }
}
