using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DAL
{
    public static class DefaultValues
    {
        #region ----- Helper Methods -----
        public static Decimal ToDecimal(this object value)
        {
            try { return Math.Round(Convert.ToDecimal(value), 2); }
            catch { return 0M; }
        }
        public static Double ToDouble(this object value)
        {
            try { return Math.Round(Convert.ToDouble(value), 2); }
            catch { return 0.0; }
        }
        public static Int16 ToInt16(this object value)
        {
            try { return Convert.ToInt16(value); }
            catch { return 0; }
        }
        public static Int32 ToInt32(this object value)
        {
            try { return Convert.ToInt32(value); }
            catch { return 0; }
        }
        public static Int64 ToInt64(this object value)
        {
            try { return Convert.ToInt64(value); }
            catch { return 0; }
        }
        public static Boolean ToBoolean(this object value)
        {
            try { return Convert.ToBoolean(value); }
            catch { return false; }
        }
        public static DateTime ToDateTime(this object value)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            try { return Convert.ToDateTime(value); }
            //catch { return Convert.ToDateTime("1/1/1900 12:00:00:AM"); }
            catch
            {
                DateTime.TryParse("1/1/1900 12:00:00:AM", out dt);
                return dt;
            }
        }
        public static string GetExceptionString(this Exception value)
        {
            try { return value.InnerException == null ? value.Message : value.InnerException.Message; }
            catch { return "System is unable to understand this exception."; }
        }

        #endregion
    }
}
