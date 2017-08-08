using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;

namespace System
{
    /// <summary>
    /// Convert Kütüphanesinin Hata vermeden Geri Dönüt Veren Halidir.
    /// </summary>
    public static class ConvertionClass
    {
        #region Constants
        public static DateTime TryValueDateTime = new DateTime(1900, 1, 1);
        #endregion

        #region Enum
        public enum BoolToString
        {
            OneZero,
            TrueFalse,
            YesNo,
            DogruYanlis,
            DoğruYanlış,
            EvetHayir,
            TF,
            YN,
            DY,
            EH,
        }
        #endregion

        #region Class
        public class CL_Enum
        {
            public CL_Enum():this(false)
            {
            }
            public CL_Enum(bool toStringMethodIsDescription)
            {
                _toStringMethodIsDescription = toStringMethodIsDescription;
            }

            private int _value = 0;
            public int Value  { get { return _value; } set { _value = value; } }

            private string _text = "";
            public string Text { get { return _text; } set { _text = value; } }

            private string _description = "";
            public string Description { get { return GetDescriptionText; } set { _description = value; } }

            private object _tag = null;
            public object Tag { get { return _tag; } set { _tag = value; } }


            private string GetDescriptionText 
            { 
                get
                {
                    if (string.IsNullOrEmpty(_description) == false)
                    {
                        return _description.ToStringAbs();
                    }
                    else
                    {
                        return _text.ToStringAbs();
                    }
                } 
            }

            private bool _toStringMethodIsDescription = false;
            public override string ToString()
            {
                if (_toStringMethodIsDescription)
                {
                    return GetDescriptionText;
                }
                else
                {
                    return _text.ToStringAbs();
                }
            }
        }
        #endregion

        #region ToBoolean
        public static bool ToBoolean(this bool value)
        {
            return value;
        }
        public static bool ToBoolean(this byte value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this char value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this DateTime value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this decimal value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this double value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this float value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this int value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this long value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this sbyte value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this short value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this uint value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this ulong value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this ushort value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this object value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this object value, IFormatProvider provider)
        {
            return ToBoolean(value, provider, false);
        }
        public static bool ToBoolean(this string value)
        {
            return ToBoolean(value, false);
        }
        public static bool ToBoolean(this string value, IFormatProvider provider)
        {
            return ToBoolean(value, provider, false);
        }
        public static bool ToBoolean(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return false;
            }

            return ToBoolean(value[ColumnName], false);
        }
        #endregion

        #region ToBooleanTry
        public static bool ToBoolean(this bool value, bool tryReturnValue)
        {
            return value;
        }
        public static bool ToBoolean(this byte value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this char value, bool tryReturnValue)
        {
            switch (value)
            {
                case ('1'): return true;
                case ('0'): return false;
                case ('t'): return true;
                case ('f'): return false;
                case ('T'): return true;
                case ('F'): return false;
                case ('d'): return true;
                case ('y'): return false;
                case ('D'): return true;
                case ('Y'): return false;
                default: break;
            }

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this DateTime value, bool tryReturnValue)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this decimal value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this double value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this float value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this int value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this long value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this sbyte value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this short value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this uint value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this ulong value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this ushort value, bool tryReturnValue)
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this string value, bool tryReturnValue)
        {
            if (value == null) return tryReturnValue;

            string valStr = value.ToString().Trim().ToUpperInvariant();

            if (string.IsNullOrEmpty(valStr)) return false;

            switch (valStr)
            {
                case "1": return true;
                case "0": return false;
                case "T": return true;
                case "F": return false;
                case "Y": return true;
                case "N": return false;
                case "E": return true;
                case "H": return false;
                case "EVET": return true;
                case "HAYIR": return false;
                case "HAYİR": return false;
                case "TRUE": return true;
                case "FALSE": return false;
                case "YES": return true;
                case "NO": return false;
                case "DOGRU": return true;
                case "DOĞRU": return true;
                case "YANLIS": return false;
                case "YANLIŞ": return false;
                case "YANLİS": return false;
                case "YANLİŞ": return false;

                default: break;
            }

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this string value, IFormatProvider provider, bool tryReturnValue)
        {
            try
            {
                return Convert.ToBoolean(value, provider);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this object value, bool tryReturnValue)
        {
            if (value == null) return tryReturnValue;

            string valStr = value.ToString().Trim().ToUpperInvariant();

            if (string.IsNullOrEmpty(valStr)) return false;

            switch (valStr)
            {
                case "1": return true;
                case "0": return false;
                case "T": return true;
                case "F": return false;
                case "D": return true;
                case "Y": return false;
                case "TRUE": return true;
                case "FALSE": return false;
                case "DOGRU": return true;
                case "DOĞRU": return true;
                case "YANLIS": return false;
                case "YANLIŞ": return false;
                case "YANLİS": return false;
                case "YANLİŞ": return false;
                default: break;
            }

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this object value, IFormatProvider provider, bool tryReturnValue)
        {
            try
            {
                return Convert.ToBoolean(value, provider);
            }
            catch
            {
                return tryReturnValue;
            }
        }
        public static bool ToBoolean(this DataRow value, string ColumnName, bool tryReturnValue)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return tryReturnValue;
            }

            return ToBoolean(value[ColumnName], tryReturnValue);
        }
        #endregion

        #region ToByte
        public static byte ToByte(this byte value)
        {
            return value;
        }
        public static byte ToByte(this bool value)
        {
            return Convert.ToByte(value);
        }
        public static byte ToByte(this char value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this DateTime value)
        {
            if (value == null) { return 0; }

            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this decimal value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this double value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this float value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this int value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this long value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this uint value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this ulong value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this ushort value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this sbyte value)
        {
            return Convert.ToByte(value);
        }
        public static byte ToByte(this short value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this object value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToByte(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return 0; }

            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this string value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToByte(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this string value, int fromBase)
        {
            try
            {
                return Convert.ToByte(value, fromBase);
            }
            catch
            {
                return 0;
            }
        }
        public static byte ToByte(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToByte(value[ColumnName]);
        }
        #endregion

        #region ToByteArray
        public static byte[] ToByteArray(this Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
                catch
                {
                    return new byte[0];
                }
            }
        }
        public static byte[] ToByteArray(this object value)
        {
            if (value == null) return new byte[] { };
            if (DBNull.Value.Equals(value)) return new byte[] { };
            if (string.IsNullOrEmpty(value.ToString())) return new byte[] { };

            try
            {
                return (byte[])value;
            }
            catch
            {
                return new byte[] { };
            }
        }
        public static byte[] ToByteArray(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return new byte[] { };
            }

            return ToByteArray(value[ColumnName]);
        }
        #endregion

        #region ToChar
        public static char ToChar(this bool value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this byte value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this char value)
        {
            if (DBNull.Value.Equals(value)) return char.MinValue;
            if (string.IsNullOrEmpty(value.ToString())) return char.MinValue;

            return value;
        }
        public static char ToChar(this DateTime value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this decimal value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this double value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this float value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this int value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this long value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this sbyte value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this short value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this uint value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this ulong value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this ushort value)
        {
            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return char.MinValue;

            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return char.MinValue;

            try
            {
                return Convert.ToChar(value, provider);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this object value)
        {
            if (value == null) return char.MinValue;
            if (DBNull.Value.Equals(value)) return char.MinValue;
            if (string.IsNullOrEmpty(value.ToString())) return char.MinValue;

            try
            {
                return Convert.ToChar(value);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this object value, IFormatProvider provider)
        {
            if (value == null) return char.MinValue;
            if (DBNull.Value.Equals(value)) return char.MinValue;
            if (string.IsNullOrEmpty(value.ToString())) return char.MinValue;

            try
            {
                return Convert.ToChar(value, provider);
            }
            catch
            {
                return char.MinValue;
            }
        }
        public static char ToChar(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return char.MinValue;
            }

            return ToChar(value[ColumnName]);
        }
        #endregion

        #region ToDateTime
        public static DateTime ToDateTime(this bool value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this byte value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this char value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this DateTime value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this decimal value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this double value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this float value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this int value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this long value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this sbyte value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this short value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this uint value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this ulong value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this ushort value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this string value)
        {
            if (value == null) return TryValueDateTime;
            if (DBNull.Value.Equals(value)) return TryValueDateTime;
            if (string.IsNullOrEmpty(value.ToString())) return TryValueDateTime;

            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this string value, IFormatProvider provider)
        {
            if (value == null) return TryValueDateTime;
            if (DBNull.Value.Equals(value)) return TryValueDateTime;
            if (string.IsNullOrEmpty(value.ToString())) return TryValueDateTime;

            try
            {
                return Convert.ToDateTime(value, provider);
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this object value)
        {
            if (value == null) return TryValueDateTime;
            if (DBNull.Value.Equals(value)) return TryValueDateTime;
            if (string.IsNullOrEmpty(value.ToString())) return TryValueDateTime;

            try
            {
                if (value is System.DateTimeOffset)
                {
                    return ((System.DateTimeOffset)value).DateTime;
                }
                else
                {
                    return Convert.ToDateTime(value);
                }
            }
            catch
            {
                return TryValueDateTime;
            }
        }
        public static DateTime ToDateTime(this object value, IFormatProvider provider)
        {
            if (value == null) return TryValueDateTime;
            if (DBNull.Value.Equals(value)) return TryValueDateTime;
            if (string.IsNullOrEmpty(value.ToString())) return TryValueDateTime;

            try
            {
                if (value is System.DateTimeOffset)
                {
                    return Convert.ToDateTime(((System.DateTimeOffset)value).DateTime, provider);
                }
                else
                {
                    return Convert.ToDateTime(value, provider);
                }
            }
            catch
            {
                return TryValueDateTime;
            }
        }

        public static DateTime ToDateTimeOA(this object value)
        {
            double val = value.ToDouble();

            if ((val >= 0.0) && (val < 60.0))
            {
                val++;
            }

            try
            {
                return DateTime.FromOADate(val);
            }
            catch
            {
                return TryValueDateTime;
            }
        }

        public static DateTime SubDays(this DateTime dt, double value)
        {
            return dt.AddDays(-1 * value);
        }
        public static DateTime SubHours(this DateTime dt, double value)
        {
            return dt.AddHours(-1 * value);
        }
        public static DateTime SubMilliseconds(this DateTime dt, double value)
        {
            return dt.AddMilliseconds(-1 * value);
        }
        public static DateTime SubMinutes(this DateTime dt, double value)
        {
            return dt.AddMinutes(-1 * value);
        }
        public static DateTime SubMonths(this DateTime dt, int value)
        {
            return dt.AddMonths(-1 * value);
        }
        public static DateTime SubSeconds(this DateTime dt, double value)
        {
            return dt.AddSeconds(-1 * value);
        }
        public static DateTime SubTicks(this DateTime dt, long value)
        {
            return dt.AddTicks(-1 * value);
        }
        public static DateTime SubYears(this DateTime dt, int value)
        {
            return dt.AddYears(-1 * value);
        }
        public static DateTime ToDateTime(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return TryValueDateTime;
            }

            return ToDateTime(value[ColumnName]);
        }
        public static DateTime ToParseExact(this string date, string dateFormat = "dd/MM/yyyy")
        {
            date = date.ToStringAbs();
            return string.IsNullOrWhiteSpace(date) ? default(DateTime) : DateTime.ParseExact(date, dateFormat, System.Globalization.CultureInfo.InvariantCulture);
        }
        #endregion

        #region ToDecimal
        public static decimal ToDecimal(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToDecimal(value[ColumnName]);
        }
        public static decimal ToDecimal(this decimal value)
        {
            return value;
        }
        public static decimal ToDecimal(this bool value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this byte value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this char value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this DateTime value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this double value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this float value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this int value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this long value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this sbyte value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this short value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this uint value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this ulong value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this ushort value)
        {
            return (decimal)value;
        }
        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDecimal(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDecimal(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToDouble
        public static double ToDouble(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToDouble(value[ColumnName]);
        }
        public static double ToDouble(this double value)
        {
            return value;
        }
        public static double ToDouble(this bool value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this byte value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this char value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this DateTime value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this decimal value)
        {
            return (double)value;
        }
        public static double ToDouble(this float value)
        {
            return (double)value;
        }
        public static double ToDouble(this int value)
        {
            return (double)value;
        }
        public static double ToDouble(this long value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this sbyte value)
        {
            return (double)value;
        }
        public static double ToDouble(this short value)
        {
            return (double)value;
        }
        public static double ToDouble(this uint value)
        {
            return (double)value;
        }
        public static double ToDouble(this ulong value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this ushort value)
        {
            return (double)value;
        }
        public static double ToDouble(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDouble(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToDouble(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDoubleDecimalCharacter(this object value)
        {
            string val = value.ToStringAbs();
            if (string.IsNullOrEmpty(val)) return 0;

            double d = 0.5;
            char c =Convert.ToChar(d.ToString().Substring(1,1));
            try
            {
                return Convert.ToDouble(val.Replace('.', c).Replace(',', c));
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToInt16
        public static short ToInt16(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToInt16(value[ColumnName]);
        }
        public static short ToInt16(this short value)
        {
            return value;
        }
        public static short ToInt16(this bool value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this byte value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this char value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this DateTime value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this decimal value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this float value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this double value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this int value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this long value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this sbyte value)
        {
            return (short)value;
        }
        public static short ToInt16(this uint value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this ulong value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this ushort value)
        {
            return (short)value;
        }
        public static short ToInt16(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt16(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt16(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static short ToInt16(this string value, int fromBase)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt16(value, fromBase);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToInt32
        public static int ToInt32(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToInt32(value[ColumnName]);
        }
        public static int ToInt32(this int value)
        {
            return value;
        }
        public static int ToInt32(this bool value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this byte value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this char value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this DateTime value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this decimal value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this float value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this double value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this long value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this sbyte value)
        {
            return (int)value;
        }
        public static int ToInt32(this short value)
        {
            return (int)value;
        }
        public static int ToInt32(this uint value)
        {
            return (int)value;
        }
        public static int ToInt32(this ulong value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this ushort value)
        {
            return (int)value;
        }
        public static int ToInt32(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt32(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt32(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static int ToInt32(this string value, int fromBase)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt32(value, fromBase);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToIntArray
        public static int[] ToIntArray(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return new int[] { };
            }

            return ToIntArray(value[ColumnName]);
        }
        public static int[] ToIntArray(this object value)
        {
            if (value == null) return new int[] { };
            if (DBNull.Value.Equals(value)) return new int[] { };
            if (string.IsNullOrEmpty(value.ToString())) return new int[] { };

            try
            {
                return (int[])value;
            }
            catch
            {
                return new int[] { };
            }
        }
        #endregion

        #region ToInt64
        public static long ToInt64(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToInt64(value[ColumnName]);
        }
        public static long ToInt64(this sbyte value)
        {
            return (long)value;
        }
        public static long ToInt64(this uint value)
        {
            return (long)value;
        }
        public static long ToInt64(this ushort value)
        {
            return (long)value;
        }
        public static long ToInt64(this ulong value)
        {
            return (long)value;
        }
        public static long ToInt64(this byte value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this short value)
        {
            return (long)value;
        }
        public static long ToInt64(this int value)
        {
            return (long)value;
        }
        public static long ToInt64(this long value)
        {
            return value;
        }
        public static long ToInt64(this bool value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this char value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this DateTime value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this decimal value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this float value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this double value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt64(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this string value, int fromBase)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt64(value, fromBase);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToInt64(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToInt64(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToSByte
        public static sbyte ToSByte(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToSByte(value[ColumnName]);
        }
        public static sbyte ToSByte(this sbyte value)
        {
            return value;
        }
        public static sbyte ToSByte(this ushort value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this uint value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this ulong value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this byte value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this short value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this int value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this long value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this bool value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this char value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this DateTime value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this decimal value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this float value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this double value)
        {
            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSByte(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this string value, int fromBase)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSByte(value, fromBase);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSByte(value);
            }
            catch
            {
                return 0;
            }
        }
        public static sbyte ToSByte(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSByte(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToSingle
        public static float ToSingle(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToSingle(value[ColumnName]);
        }
        public static float ToSingle(this sbyte value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this ushort value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this uint value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this ulong value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this byte value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this short value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this int value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this long value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this bool value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this char value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this DateTime value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this decimal value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this float value)
        {
            return value;
        }
        public static float ToSingle(this double value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this string value)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this string value, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSingle(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this object value)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return 0;
            }
        }
        public static float ToSingle(this object value, IFormatProvider provider)
        {
            if (value == null) return 0;
            if (DBNull.Value.Equals(value)) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;

            try
            {
                return Convert.ToSingle(value, provider);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region ToString
        public static string ToStringAbs(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return "";
            }

            return ToStringAbs(value[ColumnName]);
        }
        public static string ToStringAbs(this bool value)
        {
            return Convert.ToString(value);
        }
        public static string ToStringAbs(this bool value, BoolToString returnType)
        {
            switch (returnType)
            {
                case BoolToString.OneZero: return value ? "1" : "0";
                case BoolToString.TrueFalse: return value ? "TRUE" : "FALSE";
                case BoolToString.YesNo: return value ? "YES" : "NO";
                case BoolToString.DogruYanlis: return value ? "DOGRU" : "YANLIS";
                case BoolToString.DoğruYanlış: return value ? "DOĞRU" : "YANLIŞ";
                case BoolToString.EvetHayir: return value ? "EVET" : "HAYIR";
                case BoolToString.TF: return value ? "T" : "F";
                case BoolToString.YN: return value ? "Y" : "N";
                case BoolToString.DY: return value ? "D" : "Y";
                case BoolToString.EH: return value ? "E" : "H";
            }

            return Convert.ToString(value);
        }
        public static string ToStringAbs(this bool value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this byte value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this byte value, IFormatProvider provider)
        {
            try
            {
                return value.ToString(provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this char value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this DateTime value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this decimal value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this decimal value, bool DotCommaChange)
        {
            return value.ToString().Replace('.', ';').Replace(',', '.').Replace(';', ',');
        }
        public static string ToStringAbs(this decimal value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this decimal value, IFormatProvider provider, bool DotCommaChange)
        {
            try
            {
                return Convert.ToString(value, provider).Replace('.', ';').Replace(',', '.').Replace(';', ',');
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this double value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this float value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this int value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this long value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this sbyte value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this short value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this uint value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this ulong value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this ushort value)
        {
            return value.ToString();
        }
        public static string ToStringAbs(this byte value, int toBase)
        {
            try
            {
                return Convert.ToString(value, toBase);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this char value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this DateTime value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this double value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this float value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this int value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this int value, int toBase)
        {
            try
            {
                return Convert.ToString(value, toBase);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this long value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this long value, int toBase)
        {
            try
            {
                return Convert.ToString(value, toBase);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this sbyte value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this short value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this short value, int toBase)
        {
            try
            {
                return Convert.ToString(value, toBase);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this uint value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this ulong value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this ushort value, IFormatProvider provider)
        {
            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this object value)
        {
            if (value == null) { return ""; }

            try
            {
                return Convert.ToString(value);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this object value, IFormatProvider provider)
        {
            if (value == null) { return ""; }

            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this string value)
        {
            if (value == null) { return ""; }

            return value;
        }
        public static string ToStringAbs(this string value, IFormatProvider provider)
        {
            if (value == null) { return ""; }

            try
            {
                return Convert.ToString(value, provider);
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringAbs(this Exception value, bool innerException = true)
        {
            string str = "";

            if (string.IsNullOrEmpty(value.Message) == false)
            {
                str += value.Message;
            }

            if (string.IsNullOrEmpty(value.Source) == false)
            {
                if (string.IsNullOrEmpty(str) == false)
                {
                    str += Environment.NewLine;
                }
                str += value.Source;
            }

            if (string.IsNullOrEmpty(value.StackTrace) == false)
            {
                if (string.IsNullOrEmpty(str) == false)
                {
                    str += Environment.NewLine;
                }
                str += value.StackTrace;
            }

            if (value.InnerException != null)
            {
                str += Environment.NewLine + Environment.NewLine + "InnerException" + Environment.NewLine;

                str += value.InnerException.ToStringAbs(false);    
            }

            return str ?? "";
        }
        #endregion

        #region ToUInt16
        public static ushort ToUInt16(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToUInt16(value[ColumnName]);
        }
        public static ushort ToUInt16(this bool value)
        {
            try { return Convert.ToUInt16(value); }
            catch { return 0; }
        }
        public static ushort ToUInt16(this byte value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this char value)
        {
            try { return Convert.ToUInt16(value); }
            catch { return 0; }
        }
        public static ushort ToUInt16(this DateTime value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this decimal value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this double value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this float value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this int value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this long value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this object value)
        {
            if (value == null) { return 0; }
            try { return Convert.ToUInt16(value); }
            catch { return 0; }
        }
        public static ushort ToUInt16(this sbyte value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this short value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this string value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this uint value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this ulong value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this ushort value) { try { return Convert.ToUInt16(value); } catch { return 0; } }
        public static ushort ToUInt16(this object value, IFormatProvider provider)
        {
            if (value == null) { return 0; }
            try { return Convert.ToUInt16(value, provider); }
            catch { return 0; }
        }
        public static ushort ToUInt16(this string value, IFormatProvider provider)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt16(value, provider); }
            catch { return 0; }
        }
        public static ushort ToUInt16(this string value, int fromBase)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt16(value, fromBase); }
            catch { return 0; }
        }
        #endregion

        #region ToUInt32
        public static uint ToUInt32(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToUInt32(value[ColumnName]);
        }
        public static uint ToUInt32(this bool value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this byte value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this char value)
        {
            try { return Convert.ToUInt32(value); }
            catch { return 0; }
        }
        public static uint ToUInt32(this DateTime value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this decimal value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this double value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this float value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this int value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this long value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this object value)
        {
            if (value == null) { return 0; }

            try { return Convert.ToUInt32(value); }
            catch { return 0; }
        }
        public static uint ToUInt32(this sbyte value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this short value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this string value)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt32(value); }
            catch { return 0; }
        }
        public static uint ToUInt32(this uint value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this ulong value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this ushort value) { try { return Convert.ToUInt32(value); } catch { return 0; } }
        public static uint ToUInt32(this object value, IFormatProvider provider)
        {
            if (value == null) { return 0; }

            try { return Convert.ToUInt32(value, provider); }
            catch { return 0; }
        }
        public static uint ToUInt32(this string value, IFormatProvider provider)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt32(value, provider); }
            catch { return 0; }
        }
        public static uint ToUInt32(this string value, int fromBase)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt32(value, fromBase); }
            catch { return 0; }
        }
        #endregion

        #region ToUInt64
        public static ulong ToUInt64(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                return 0;
            }

            return ToUInt64(value[ColumnName]);
        }
        public static ulong ToUInt64(this bool value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this byte value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this char value)
        {
            try { return Convert.ToUInt64(value); }
            catch { return 0; }
        }
        public static ulong ToUInt64(this DateTime value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this decimal value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this double value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this float value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this int value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this long value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this object value)
        {
            if (value == null) { return 0; }

            try { return Convert.ToUInt64(value); }
            catch { return 0; }
        }
        public static ulong ToUInt64(this sbyte value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this short value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this string value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this uint value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this ulong value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this ushort value) { try { return Convert.ToUInt64(value); } catch { return 0; } }
        public static ulong ToUInt64(this object value, IFormatProvider provider)
        {
            if (value == null) { return 0; }

            try { return Convert.ToUInt64(value, provider); }
            catch { return 0; }
        }
        public static ulong ToUInt64(this string value, IFormatProvider provider)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt64(value, provider); }
            catch { return 0; }
        }
        public static ulong ToUInt64(this string value, int fromBase)
        {
            if (value == null) { return 0; }
            if (string.IsNullOrEmpty(value)) { return 0; }

            try { return Convert.ToUInt64(value, fromBase); }
            catch { return 0; }
        }
        #endregion

        #region ToImage
        public static Image ToImage(this DataRow value, string ColumnName)
        {
            if (value.HasRowValue(ColumnName) == false)
            {
                Bitmap b = new Bitmap(1, 1);
                return b;
            }

            return ToImage(value[ColumnName]);
        }
        public static Image ToImage(Stream stream)
        {
            try
            {
                Image returnImage = Image.FromStream(stream);

                return returnImage;
            }
            catch
            {
                Bitmap b = new Bitmap(1, 1);
                return b;
            }
        }
        public static Image ToImage(this byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                try
                {
                    Image returnImage = Image.FromStream(ms);

                    return returnImage;
                }
                catch
                {
                    Bitmap b = new Bitmap(1, 1);
                    return b;
                }
            }
        }
        public static Image ToImage(this object value)
        {
            Image retImg = null;

            if (value == null) { return retImg; }

            Image img = new System.Drawing.Bitmap(1, 1);
            byte[] byt = new byte[1];

            if (byt.GetType() == value.GetType())
            {
                retImg = value.ToByteArray().ToImage();
            }
            else if (img.GetType() == value.GetType())
            {
                if (!DBNull.Value.Equals(value))
                    retImg = new System.Drawing.Bitmap((Image)value);
            }

            return retImg;
        }
        #endregion

        #region EnumToList
        public static List<string> EnumToListString<T>(this T value)
        {
            Type enumType = typeof(T);
            List<string> retVAL = new List<string>();

            if (enumType.BaseType != typeof(Enum) && enumType != typeof(Enum))
                throw new ArgumentException("System.Enum tipinde bir değer olmalıdır.");

            List<T> Val = value.EnumToListOrjinal();

            if (Val.Count <= 0) { return retVAL; }

            foreach (var item in Val)
            {
                retVAL.Add(item.ToString());
            }

            return retVAL;
        }
        public static List<T> EnumToListOrjinal<T>(this T value)
        {
            if (value == null )
            {
                return new List<T>();
            }

            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum) && enumType != typeof(Enum))
                throw new ArgumentException("System.Enum tipinde bir değer olmalıdır.");

            List<T> Val = new List<T>();

            if (enumType == typeof(Enum))
            {
                Type et = value.GetType();

                System.Reflection.FieldInfo[] fi = et.GetFields(BindingFlags.Static | BindingFlags.Public);

                for (int i = 0; i < fi.Length; i++)
                {
                    Val.Add((T)fi[i].GetValue(value));
                }
            }
            else
            {
                Val.AddRange(Enum.GetValues(enumType) as IEnumerable<T>);
            }

            return Val;
        }
        public static List<CL_Enum> EnumToList<T>(this T value, bool toStringMethodIsDescription = false)
        {
            Type enumType = typeof(T);
            List<CL_Enum> retVAL = new List<CL_Enum>();

            if (enumType.BaseType != typeof(Enum) && enumType != typeof(Enum))
                throw new ArgumentException("System.Enum tipinde bir değer olmalıdır.");

            List<T> Val = value.EnumToListOrjinal();
            if (Val.Count <= 0) { return retVAL; }

            foreach (var item in Val)
            {
                retVAL.Add(new CL_Enum(toStringMethodIsDescription)
                {
                    Text = item.ToString(),
                    Value = item.ToInt32(),
                    Description = item.ToDescription(),
                    Tag = null 
                });
            }

            return retVAL;
        }

        public static T EnumToFind<T>(this T value, string FindValue)
        {
            Type enumType = typeof(T);
            T retVAL;

            if (string.IsNullOrEmpty(FindValue)) { return value; }
            if (enumType.BaseType != typeof(Enum) && enumType != typeof(Enum))
                throw new ArgumentException("System.Enum tipinde bir değer olmalıdır.");

            List<T> Val = value.EnumToListOrjinal();

            if (Val.Count <= 0) { return value; }

            retVAL = value;

            foreach (var item in Val)
            {
                if (item.ToString().ToUpper() == FindValue.ToUpper())
                {
                    retVAL = item;

                    break;
                }
                else if (item.ToString().ToUpper(System.Globalization.CultureInfo.GetCultureInfo("tr-TR")) == FindValue.ToUpper(System.Globalization.CultureInfo.GetCultureInfo("tr-TR")))
                {
                    retVAL = item;

                    break;
                }
                else if (item.ToString().ToLower(System.Globalization.CultureInfo.GetCultureInfo("en-US")) == FindValue.ToLower(System.Globalization.CultureInfo.GetCultureInfo("en-US")))
                {
                    retVAL = item;

                    break;
                }
#if !WindowsCE
                else if (item.ToString().ToLowerInvariant() == FindValue.ToLowerInvariant())
                {
                    retVAL = item;

                    break;
                }
#endif
                else if (item.ToString().ToUpper() == "UNKNOWN" || item.ToString().ToUpper() == "NONE")
                {
                    retVAL = item;
                }
            }

            return retVAL;
        }

        public static T GetAttribute<T, E>(this E value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static string ToDescription<T>(this T value)
        {
            var attribute = value.GetAttribute<System.ComponentModel.DescriptionAttribute, T>();
            return attribute == null ? value.ToString() : attribute.Description;
        }


        public static List<CL_Enum> ToConvertEnumClassList(this Type enumType)
        {
            FieldInfo[] fields = enumType.GetFields();

            List<System.ConvertionClass.CL_Enum> lst = new List<ConvertionClass.CL_Enum>();
            foreach (var field in fields)
            {
                if (field.Name.Equals("value__")) continue;

                var customAttribute = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                string desc = customAttribute.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)customAttribute[0]).Description : field.Name;
                lst.Add(
                        new System.ConvertionClass.CL_Enum(true)
                            {
                                Description = desc,
                                Text = field.Name,
                                Value = field.GetRawConstantValue().ToInt32(),
                            }
                        );
            }


            return lst;
        }

        public static string ToEnumDescription(this Enum en) //ext method
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }


        #endregion

        #region ToObject
        public static object ToObject(this object value)
        {
            if (value == null) return "";
            return value;
        }
        #endregion

        #region ToGuid
        public static Guid ToGuid(this object value)
        {
            Guid getValue;
            try
            {
                if (value != null)
                {
                    if (!DBNull.Value.Equals(value))
                        getValue = new Guid(value.ToString());
                    else
                        return new Guid();
                }
                else
                {
                    getValue = new Guid();
                }
            }
            catch
            {
                getValue = new Guid();
                return getValue;
            }
            return getValue;
        }
        #endregion

        #region ToGuidString
        public static string ToGuidString(this object value)
        {
            if (value == null) return Guid.NewGuid().ToString("D");
            return (value.ToString() == "") ? Guid.NewGuid().ToString("D") : Convert.ToString(value);
        }
        #endregion

        #region ToMoney
        public static string ToMoney(this object value)
        {
            if (value == null) return "";
            return (value.ToString() == "") ? "" : string.Format("{0:c}", value.ToString());
        }
        #endregion

        #region ToPhone
        public static string ToPhone(this object value)
        {
            string _val = "";

            if (value == null) return "";
            if (value.ToString().Length > 10)
            {
                try
                {
                    _val = value.ToString().Substring(value.ToString().Length - 10);
                }
                catch
                {
                    _val = "";
                }
            }

            return (_val.ToString() == "") ? "" : string.Format("{0:c}", _val.ToString());
        }
        #endregion

        #region ToXmlString
        public static string ToXmlString(this DataSet value)
        {
            if (value == null ) { return ""; }

            for (int i = 0; i < value.Tables.Count  ; i++)
            {
                if (string.IsNullOrEmpty(value.Tables[i].TableName))
                {
                    value.Tables[i].TableName = "Table" + i.ToString();
                }
            }

            using (var writer = new StringWriter())
            {
                value.WriteXml(writer);
                return writer.ToString();
            }
        }
        public static string ToXmlString(this DataTable value)
        {
            if (value == null) { return ""; }

            if (string.IsNullOrEmpty(value.TableName)) { value.TableName = "Table1"; }

            using (var writer = new StringWriter())
            {
                value.WriteXml(writer);
                return writer.ToString();
            }
        }
        public static string ToXmlString(this DataTable value, Func<DataRow, bool> predicate)
        {
            if (value == null) { return ""; }
            DataTable dt = value.ToDataTableWhere(predicate);
            dt.TableName = "Table1";

            using (var writer = new StringWriter())
            {
                dt.WriteXml(writer);
                return writer.ToString();
            }
        }
        
        public static string ToXmlString(this List<DataRow> value)
        {
            if (value == null) { return ""; }
            DataTable dt = null;
            if (value.Count > 0)
            {
                dt = value[0].Table.Clone();
            }
            else
            {
                dt = new DataTable();
            }

            dt.TableName = "Table1";
            foreach (var item in value)
            {
                dt.ImportRow(item);
            }

            using (var writer = new StringWriter())
            {
                dt.WriteXml(writer);
                return writer.ToString();
            }
        }
        #endregion

        #region To
        /// <summary>
        /// Belirtilen tipe göre convert edilir
        /// Example:
        /// var age = "28";
        /// var intAge = age.To<int>();
        /// var doubleAge = intAge.To<double>();
        /// var decimalAge = doubleAge.To<decimal>();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(this IConvertible value)
        {
            try
            {
                Type t = typeof(T);
                Type u = Nullable.GetUnderlyingType(t);

                if (u != null)
                {
                    if (value == null || value.Equals(""))
                        return default(T);

                    return (T)Convert.ChangeType(value, u);
                }
                else
                {
                    if (value == null || value.Equals(""))
                        return default(T);

                    return (T)Convert.ChangeType(value, t);
                }
            }

            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Belirtilen tipe göre convert edilir
        /// Example:
        /// var age = "28";
        /// var intAge = age.To<int>();
        /// var doubleAge = intAge.To<double>();
        /// var decimalAge = doubleAge.To<decimal>();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ifError"></param>
        /// <returns></returns>
        public static T To<T>(this IConvertible value, IConvertible ifError)
        {
            try
            {
                Type t = typeof(T);
                Type u = Nullable.GetUnderlyingType(t);

                if (u != null)
                {
                    if (value == null || value.Equals(""))
                        return (T)ifError;

                    return (T)Convert.ChangeType(value, u);
                }
                else
                {
                    if (value == null || value.Equals(""))
                        return (T)(ifError.To<T>());

                    return (T)Convert.ChangeType(value, t);
                }
            }
            catch
            {
                return (T)ifError;
            }

        }
        #endregion

        #region ToDictionary
        /// <summary>
        /// Converts an enumeration of groupings into a Dictionary of those groupings.
        /// </summary>
        /// <typeparam name="TKey">Key type of the grouping and dictionary.</typeparam>
        /// <typeparam name="TValue">Element type of the grouping and dictionary list.</typeparam>
        /// <param name="groupings">The enumeration of groupings from a GroupBy() clause.</param>
        /// <returns>A dictionary of groupings such that the key of the dictionary is TKey type and the value is List of TValue type.</returns>
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
        {
            return groupings.ToDictionary(group => group.Key, group => group.ToList());
        }
        #endregion
    }
}