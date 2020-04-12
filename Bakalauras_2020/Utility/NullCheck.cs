using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakalauras_2020.Utility
{
    static class NullCheck
    {
        public static string IsNullString(object value, string returnValue = "")
        {
            if (value == null)
                return null;
            if (string.IsNullOrEmpty(value.ToString()))
                return returnValue;
            return value.ToString();
        }

        public static int IsNullInt(object value, int defaultvalue = 0)
        {
            var result = defaultvalue;
            if (value != null && value.ToString() != "")
            {
                string strValue = value.ToString().Trim();
                int num;
                if (int.TryParse(strValue, out num) || int.TryParse(strValue, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out num))
                {
                    result = num;
                }
            }
            return result;
        }

        public static DateTime IsNullDate(object Value)
        {
            DateTime result = DateTime.Now;
            if (Value != null)
            {
                string sValue = Value.ToString();
                if (sValue != "")
                {
                    string StrValue = sValue.Trim();
                    DateTime dateTimeCH;
                    bool IsDateTime = DateTime.TryParse(StrValue, out dateTimeCH);
                    if (IsDateTime)
                    {
                        result = Convert.ToDateTime(Value);
                    }
                }
            }
            return result;
        }

        public static double IsNullDouble(object Value)
        {
            double result = 0.0;
            if (Value != null)
            {
                string StrValue = Value.ToString().Trim();
                double Num;
                if (double.TryParse(StrValue, out Num))
                {
                    return Num;
                }
            }
            return result;
        }

        public static bool IsNullBoolean(object Value)
        {
            const bool result = false;
            if (Value != null)
            {
                var strValue = Value.ToString().Trim();
                return strValue == "1" || strValue.ToLower() == "true";
            }
            return result;
        }

        public static decimal IsNullDecimal(object value)
        {
            if (value != null)
            {
                string strValue = value.ToString().Trim();
                decimal num;
                if (decimal.TryParse(strValue, out num) || decimal.TryParse(strValue, NumberStyles.Number, CultureInfo.InvariantCulture, out num) || decimal.TryParse(strValue, NumberStyles.Number, new CultureInfo("en-US"), out num))
                {
                    return num;
                }
            }
            return 0.0m;
        }
    }
}
