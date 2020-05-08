using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicWebFormGenerationUtility.Common
{
    public static class DatatypeExtenders
    {
        public static Int16 ToInt16(this String Value)
        {
            Int16 ReturnValue = 0;
            bool canConvert = Int16.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = Int16.Parse(Value);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

        public static Int32 ToInt32(this String Value)
        {
            Int32 ReturnValue = 0;
            bool canConvert = Int32.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = Int32.Parse(Value);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

        public static Int64 ToInt64(this String Value)
        {
            Int64 ReturnValue = 0;
            bool canConvert = Int64.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = Int64.Parse(Value);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

        public static int ToInt(this String Value)
        {
            int ReturnValue = 0;
            bool canConvert = int.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = int.Parse(Value);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

        public static decimal ToDecimal(this String Value)
        {
            decimal ReturnValue = 0;
            bool canConvert = decimal.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = decimal.Parse(Value);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

        public static double ToDouble(this String Value)
        {
            double ReturnValue = 0;
            bool canConvert = double.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = double.Parse(Value);
            else
                ReturnValue = 0;

            return ReturnValue;
        }

        public static DateTime ToDateTime(this String Value)
        {
            //DateTime ReturnValue = DateTime.Now;
            //bool canConvert = DateTime.TryParse(Value, out ReturnValue);
            //if (canConvert)
            //    ReturnValue = DateTime.Parse(Value);
            //else
            //    ReturnValue = DateTime.Now;

            //return ReturnValue;
            DateTime ReturnValue = DateTime.Now;
            IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);

            bool canConvert = DateTime.TryParse(Value, provider, DateTimeStyles.None, out ReturnValue); // DateTime.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = DateTime.Parse(Value, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            else
                ReturnValue = DateTime.Now;

            return ReturnValue;
        }

        public static bool ToBoolean(this String Value)
        {
            bool ReturnValue = true;
            bool canConvert = bool.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = bool.Parse(Value);
            else
                ReturnValue = false;

            return ReturnValue;
        }

        public static string ToDate(this String Value)
        {
            DateTime ReturnValue;
            bool canConvert = DateTime.TryParse(Value, out ReturnValue);
            if (canConvert)
                ReturnValue = DateTime.Parse(Value);

            return ReturnValue.ToString();
        }

        #region DateStringConverstion


        public static DateTime StringToDate(this String lStrDate)
        {
            DateTime lTempDate = new DateTime();
            try
            {
                if (lStrDate.Contains('/'))
                    lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('/')[2]), Convert.ToInt32(lStrDate.Split('/')[1]), Convert.ToInt32(lStrDate.Split('/')[0]));
                else if (lStrDate.Contains('-'))
                    lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('-')[2]), Convert.ToInt32(lStrDate.Split('-')[1]), Convert.ToInt32(lStrDate.Split('-')[0]));
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Exception while Converting to Datetime StringToDate : " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
            return lTempDate;
        }
        #endregion

        public static string MinutesToHoursInString(this int Value)
        {
            int hours = (Value - Value % 60) / 60;
            return "" + hours + ":" + (Value - hours * 60);
        }

        public static double MinutesToHoursInDouble(this int Value)
        {
            TimeSpan t = TimeSpan.FromMinutes(Value);
            double hours = t.TotalHours;
            return hours;
        }
        public static DateTime StringToDate(this String lStrDate, string format = "dd/MM/yyyy")
        {
            DateTime lTempDate = new DateTime();
            try
            {
                if (format == "dd/MM/yyyy")
                {
                    if (lStrDate.Contains('/'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('/')[2]), Convert.ToInt32(lStrDate.Split('/')[1]), Convert.ToInt32(lStrDate.Split('/')[0]));
                    else if (lStrDate.Contains('-'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('-')[2]), Convert.ToInt32(lStrDate.Split('-')[1]), Convert.ToInt32(lStrDate.Split('-')[0]));
                }
                else if (format == "MM/dd/yyyy")
                {
                    if (lStrDate.Contains('/'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('/')[2]), Convert.ToInt32(lStrDate.Split('/')[0]), Convert.ToInt32(lStrDate.Split('/')[1]));
                    else if (lStrDate.Contains('-'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('-')[2]), Convert.ToInt32(lStrDate.Split('-')[0]), Convert.ToInt32(lStrDate.Split('-')[1]));

                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Exception while Converting to Datetime StringToDate : " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
            return lTempDate;
        }
        public static DateTime StringToDateSQL(this String lStrDate, string format = "dd/MM/yyyy")
        {
            DateTime lTempDate = new DateTime();
            try
            {
                if (format == "dd/MM/yyyy")
                {
                    if (lStrDate.Contains('/'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('/')[2]), Convert.ToInt32(lStrDate.Split('/')[1]), Convert.ToInt32(lStrDate.Split('/')[0]));
                    else if (lStrDate.Contains('-'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('-')[2]), Convert.ToInt32(lStrDate.Split('-')[1]), Convert.ToInt32(lStrDate.Split('-')[0]));
                }
                else if (format == "MM/dd/yyyy")
                {
                    if (lStrDate.Contains('/'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('/')[2]), Convert.ToInt32(lStrDate.Split('/')[0]), Convert.ToInt32(lStrDate.Split('/')[1]));
                    else if (lStrDate.Contains('-'))
                        lTempDate = new DateTime(Convert.ToInt32(lStrDate.Split('-')[2]), Convert.ToInt32(lStrDate.Split('-')[0]), Convert.ToInt32(lStrDate.Split('-')[1]));

                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Exception while Converting to Datetime StringToDate : " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
            return lTempDate;
        }
    }
}
