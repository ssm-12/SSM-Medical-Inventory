using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class BALlogin
    {
        DALlogin objDAlogin=new DALlogin();

        public int funcAuthenticate(BOlogin objBOlogin)
        {
            return objDAlogin.funcAuthenticate(objBOlogin);
            
        }
        
           
    }
}
