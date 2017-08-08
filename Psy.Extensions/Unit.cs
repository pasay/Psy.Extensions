using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System
{
    public static class ConvertUnit
    {
        #region Members
        private static DataSet DsUnit = new DataSet();
        private static DataTable DtUnit = new DataTable();
        private static DataTable DtConversion = new DataTable();
        #endregion

        #region Functions
        #region LoadUnit
        private static bool LoadUnit()
        {
            if (DsUnit.Tables.Count == 0)
            {
                try
                {
                    FileInfo f = new FileInfo(Assembly.GetExecutingAssembly().Location);
                    DsUnit.ReadXml(Path.Combine(f.Directory.FullName , "UnitSet.xml"));
                    DtUnit = DsUnit.Tables["Unit"];
                    DtConversion = DsUnit.Tables["Conversion"];
                }
                catch
                {
                }
            }

            return DtUnit.Rows.Count > 0;
        }
        #endregion

        #region AnotherUnit
        public static decimal AnotherUnit(this decimal Val, string FromUnit, string ToUnit)
        {
            decimal MultiplierFrom = 1;
            decimal MultiplierTo = 1;
            decimal MultiplierAnotherUnit = 1;

            if (FindMultiplier(FromUnit, ToUnit, ref MultiplierFrom, ref MultiplierTo, ref MultiplierAnotherUnit) == false)
            {
                return decimal.MinValue;
            }

            return Val * (MultiplierTo / MultiplierFrom) * MultiplierAnotherUnit;
        }
        #endregion

        #region FindMultiplier
        private static bool FindMultiplier(string FromUnit, string ToUnit, ref decimal MultiplierFrom, ref decimal MultiplierTo, ref decimal MultiplierAnotherUnit)
        {
            if (LoadUnit() == false) return false;
            List<DataRow> drFromList;
            List<DataRow> drToList;

            drFromList = DtUnit.Rows.Cast<DataRow>().Where(p => p["Symbol"].ToString() == FromUnit).ToList();
            if (drFromList.Count == 0)
            {
                drFromList = DtUnit.Select("Symbol = '" + FromUnit + "'").ToList();
                if (drFromList.Count == 0)
                {
                    drFromList = DtUnit.Select("Symbol LIKE '%" + FromUnit + "%'").ToList();
                }
            }

            if (drFromList.Count == 0) return false;

            drToList = DtUnit.Rows.Cast<DataRow>().Where(p => p["Symbol"].ToString() == ToUnit).ToList();
            if (drToList.Count == 0)
            {
                drToList = DtUnit.Select("Symbol = '" + ToUnit + "'").ToList();
                if (drToList.Count == 0)
                {
                    drToList = DtUnit.Select("Symbol LIKE '%" + ToUnit + "%'").ToList();
                }
            }

            if (drToList.Count == 0) return false;

            return FindMultiplier(drFromList, drToList, ref MultiplierFrom, ref  MultiplierTo, ref MultiplierAnotherUnit);
        }

        private static bool FindMultiplier(List<DataRow> FromUnit, List<DataRow> ToUnit, ref decimal MultiplierFrom, ref decimal MultiplierTo, ref decimal MultiplierAnotherUnit)
        {
            MultiplierAnotherUnit = 1;
            MultiplierFrom = 1;
            MultiplierTo = 1;

            if (ToUnit.Count == 0) return false;
            if (FromUnit.Count == 0) return false;

            foreach (DataRow itemFrom in FromUnit)
            {
                //İlk bulduğu değeri dönüştürmede kullanmaktadır.
                DataRow itemTo = ToUnit.FirstOrDefault(p => p["Code"].ToString() == itemFrom["Code"].ToString());
                if (itemTo == null)
                {
                    foreach (DataRow itemTo2 in ToUnit)
                    {
                        if (FindAnotherUnitMultiplier(itemFrom, itemTo2, ref MultiplierAnotherUnit))
                        {
                            MultiplierFrom = Convert.ToDecimal(itemFrom["Multiplier"]);
                            MultiplierTo = Convert.ToDecimal(itemTo2["Multiplier"]);
                            return true;
                        }
                    }
                }
                else
                {
                    MultiplierFrom = Convert.ToDecimal(itemFrom["Multiplier"]);
                    MultiplierTo = Convert.ToDecimal(itemTo["Multiplier"]);
                    MultiplierAnotherUnit = 1;
                    return true;
                }
            }

            return false;
        }

        private static bool FindAnotherUnitMultiplier(DataRow itemFrom, DataRow itemTo, ref decimal MultiplierAnotherUnit)
        {
            if (itemFrom["Code"].ToStringAbs() == itemTo["Code"].ToStringAbs())
            {
                MultiplierAnotherUnit = 1;
                return true;
            }
            bool invert = false;

            DataRow drAnotherUnit = DtConversion.Rows.Cast<DataRow>().FirstOrDefault(p => p["FromCode"].ToString() == itemFrom["Code"].ToStringAbs() && p["ToCode"].ToString() == itemTo["Code"].ToStringAbs());
            if (drAnotherUnit == null)
            {
                drAnotherUnit = DtConversion.Select("FromCode = '" + itemFrom["Code"].ToStringAbs() + "' AND ToCode = '" + itemTo["Code"].ToStringAbs() + "'").FirstOrDefault();
                if (drAnotherUnit == null)
                {
                    drAnotherUnit = DtConversion.Select("FromCode LIKE '%" + itemFrom["Code"].ToStringAbs() + "%' AND ToCode = '%" + itemTo["Code"].ToStringAbs() + "%'").FirstOrDefault();
                }
            }

            if (drAnotherUnit == null)
            {
                invert = true;

                drAnotherUnit = DtConversion.Rows.Cast<DataRow>().FirstOrDefault(p => p["FromCode"].ToString() == itemTo["Code"].ToStringAbs() && p["ToCode"].ToString() == itemFrom["Code"].ToStringAbs());
                if (drAnotherUnit == null)
                {
                    drAnotherUnit = DtConversion.Select("FromCode = '" + itemTo["Code"].ToStringAbs() + "' AND ToCode = '" + itemFrom["Code"].ToStringAbs() + "'").FirstOrDefault();
                    if (drAnotherUnit == null)
                    {
                        drAnotherUnit = DtConversion.Select("FromCode LIKE '%" + itemTo["Code"].ToStringAbs() + "%' AND ToCode = '%" + itemFrom["Code"].ToStringAbs() + "%'").FirstOrDefault();
                    }
                }

                if (drAnotherUnit == null) return false;
            }
            
            if (invert)
            {
                MultiplierAnotherUnit = 1 / drAnotherUnit["Multiplier"].ToDecimal();
            }
            else
            {
                MultiplierAnotherUnit = drAnotherUnit["Multiplier"].ToDecimal();
            }

            return true;
        }
        #endregion
        #endregion
    }
}
