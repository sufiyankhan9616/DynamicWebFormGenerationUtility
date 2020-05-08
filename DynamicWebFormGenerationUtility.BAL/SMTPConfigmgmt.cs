using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class SMTPConfigmgmt
    {
        public static DataTable GetSMTPSetting()
        {
            return new DAL.SMTPConfigSQL().GetSMTPSetting();
        }
    }
}
