using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace DynamicWebFormGenerationUtility.BAL
{
  public   class ParameterMasterMGMT
    {
        public static  DataSet   InsertDropdownEntry(Entity.ParameterMaster obj)
        {
            DAL.InsertParameterMaster  VPM = new DAL.InsertParameterMaster();
           return    VPM.InsertFormFillingMaster(obj);
        }
        public static List<Entity.ParameterMaster > GetDropdownType(int parameterId)
        {
            DAL.InsertParameterMaster VPM = new DAL.InsertParameterMaster();
            return VPM.GetFormFillingMaster( parameterId);
        }
    }
}
