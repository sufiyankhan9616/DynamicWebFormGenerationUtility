using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class Errormgmt
    {
        public static int AddUpdateError(Entity.Error Entity)
        {
            return new DAL.ErrorSQL().AddUpdateError(Entity);
        }
        public static List<Entity.Error> GetErrorData(int Id)
        {
            return new DAL.ErrorSQL().GetErrorData(Id);
        }
        public static int DeleteError(string Ids, int UserId)
        {
            return new DAL.ErrorSQL().DeleteError(Ids, UserId);
        }
    }
}
