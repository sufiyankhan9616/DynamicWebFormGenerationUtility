using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class TemplateMastermgmt
    {
        public static int AddUpdateTemplateMaster(Entity.TemplateMaster Entity)
        {
            return new DAL.TemplateMasterSQL().AddUpdateTemplateMaster(Entity);
        }
        public static List<Entity.TemplateMaster> GetTemplateMasterData(int Id, int IsActive)
        {
            return new DAL.TemplateMasterSQL().GetTemplateMasterData(Id, IsActive);
        }
        public static int DeleteTemplateMaster(string TemplateDropDownId,int EventId,String  transactionId, string IpAddress, String MacAddress)
        {
            return new DAL.TemplateMasterSQL().DeleteTemplateMaster(TemplateDropDownId,  EventId,  transactionId, IpAddress, MacAddress);
        }
    }
}
