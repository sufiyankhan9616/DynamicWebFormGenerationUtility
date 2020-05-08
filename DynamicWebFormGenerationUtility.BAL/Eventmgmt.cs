using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicWebFormGenerationUtility.DAL;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class Eventmgmt
    {
        public static List<Entity.Event> GetEventByFormName(string FormName)
        {
            return new DAL.EventSQL().GetEventByFormName(FormName);
        }
    }
}
