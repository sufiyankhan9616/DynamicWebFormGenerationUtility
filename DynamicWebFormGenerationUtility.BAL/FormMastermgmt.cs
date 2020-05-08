using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DynamicWebFormGenerationUtility.BAL
{
  public  class FormMastermgmt
    {
        
          public static int AddUpdateRegexMaster(Entity.RegexMasterEntitycs  Entity)
        {
            return new DAL.FormMasterSQL().AddUpdateRegexMaster( Entity);
        }
        public static List<Entity.RegexMasterEntitycs > GEtRegexMasterData(Int32 id)
        {
            return new DAL.FormMasterSQL().GetRegexMasterData(id);
        }

        public static int AddUpdateFormMaster(Entity.FormMaster Entity)
        {
            return new DAL.FormMasterSQL().AddUpdateFormMaster(Entity);
        }
        public static int AddSessionLog(Entity.FormMaster Entity)
        {
            return new DAL.FormMasterSQL().AddSessionLog(Entity);
        }
        public static DataSet FreezFormMaster(Entity.FormMaster Entity)
        {
            return new DAL.FormMasterSQL().FreezFormMaster(Entity);
        }
        public static List<Entity.FormMaster> GetFormMasterData(int Id, int IsActive)
        {
            return new DAL.FormMasterSQL().GetFormMasterData(Id, IsActive);
        }

        public static DataTable  GetFormComponentData(int Id, int IsActive)
        {
            return new DAL.FormMasterSQL().GetFormComponentData(Id, IsActive);
        }
        public static int DeleteFormMaster(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            return new DAL.FormMasterSQL().DeleteFormMaster(Ids, UserId, HostName, IpAddr, EventId, TransactionId);
        }
        public static int DeleteFormRegex(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            return new DAL.FormMasterSQL().DeleteRegexMaster(Ids, UserId, HostName, IpAddr, EventId, TransactionId);
        }

        public static int add_Login_SessionDeatils(string Ids, int UserId, string HostName, string IpAddr, Int64 EventId, string TransactionId)
        {
            return new DAL.FormMasterSQL().DeleteRegexMaster(Ids, UserId, HostName, IpAddr, EventId, TransactionId);
        }

    }
}
