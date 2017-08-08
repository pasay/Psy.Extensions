using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace System
{
    public static class DateClass
    {
        #region EN_DateRange
        /// <summary>
        /// Tarih Aralığını belirtir
        /// </summary>
        public enum EN_DateRange
        {
            [Description("YOK")]                                                
            YOK,                                                                
            [Description("Hepsi")]                                                   
            HEPSI,                                                              
                                                                            
            [Description("Özel Aralık")]                                    
            OZEL_ARALIK,                                                    
                                                                            
            [Description("Bugün")]                                          
            BUGUN,                                                          
            [Description("Bu Hafta")]                                       
            BU_HAFTA,                                                       
            [Description("Bu Ay")]                                          
            BU_AY,                                                          
            [Description("Bu Yıl")]                                         
            BU_YIL,                                                         
                                                                            
            [Description("Yarın")]                                          
            YARIN,                                                          
            [Description("Gelecek Hafta")]                                  
            GELECEK_HAFTA,                                                  
            [Description("Gelecek Ay")]                                     
            GELECEK_AY,                                                     
            [Description("Geçen Yıl")]                                      
            GELECEK_YIL,                                                    
            [Description("Bugünden Hafta Sonuna Kadar")]                    
            BUGUNDEN_HAFTA_SONUNA_KADAR,                                    
            [Description("Bugünden Ay Sonuna Kadar")]                       
            BUGUNDEN_AY_SONUNA_KADAR,                                       
            [Description("Bugünden Yıl Sonuna Kadar")]                      
            BUGUNDEN_YIL_SONUNA_KADAR,                                      
            [Description("Bugünden Sonsuza Kadar")]                         
            BUGUNDEN_SONSUZA_KADAR,                                         
                                                                            
            [Description("Dün")]                                            
            DUN,                                                            
            [Description("Geçen Hafta")]                                    
            GECEN_HAFTA,                                                    
            [Description("Geçen Ay")]                                       
            GECEN_AY,                                                       
            [Description("Geçen Yıl")]                                      
            GECEN_YIL,                                                      
            [Description("Hafta Başından Bugüne Kadar")]                    
            HAFTA_BASINDAN_BUGUNE_KADAR,                                    
            [Description("Ay Başından Bugüne Kadar")]
            AY_BASINDAN_BUGUNE_KADAR,
            [Description("Yıl Başından Bugüne Kadar")]
            YIL_BASINDAN_BUGUNE_KADAR,
            [Description("Başlangıçtan Bugüne Kadar")]
            BASLANGIC_BUGUNE_KADAR,
        }
        public static string ConvertToString(this EN_DateRange dateRange)
        {
            switch (dateRange)
            {
                case EN_DateRange.YOK:
                    return "YOK";
                case EN_DateRange.BUGUN:
                    return "Bugün";
                case EN_DateRange.YARIN:
                    return "Yarın";
                case EN_DateRange.BU_HAFTA:
                    return "Bu Hafta";
                case EN_DateRange.BU_AY:
                    return "Bu Ay";
                case EN_DateRange.BU_YIL:
                    return "Bu Yıl";
                case EN_DateRange.DUN:
                    return "Dün";
                case EN_DateRange.GECEN_HAFTA:
                    return "Geçen Hafta";
                case EN_DateRange.GECEN_AY:
                    return "Geçen Ay";
                case EN_DateRange.GECEN_YIL:
                    return "Geçen Yıl";
                case EN_DateRange.GELECEK_HAFTA:
                    return "Gelecek Hafta";
                case EN_DateRange.GELECEK_AY:
                    return "Gelecek Ay";
                case EN_DateRange.GELECEK_YIL:
                    return "Gelecek Yıl";
                case EN_DateRange.BUGUNDEN_HAFTA_SONUNA_KADAR:
                    return "Bugünden Hafta Sonuna Kadar";
                case EN_DateRange.HAFTA_BASINDAN_BUGUNE_KADAR:
                    return "Hafta Başından Bugüne Kadar";
                case EN_DateRange.BUGUNDEN_AY_SONUNA_KADAR:
                    return "Bugünden Ay Sonuna Kadar";
                case EN_DateRange.AY_BASINDAN_BUGUNE_KADAR:
                    return "Ay Başından Bugüne Kadar";
                case EN_DateRange.BUGUNDEN_YIL_SONUNA_KADAR:
                    return "Bugünden Yıl Sonuna Kadar";
                case EN_DateRange.YIL_BASINDAN_BUGUNE_KADAR:
                    return "Yıl Başından Bugüne Kadar";
                case EN_DateRange.BASLANGIC_BUGUNE_KADAR:
                    return "Başlangıçtan Bugüne Kadar";
                case EN_DateRange.BUGUNDEN_SONSUZA_KADAR:
                    return "Bugünden Sonsuza Kadar";
                case EN_DateRange.OZEL_ARALIK:
                    return "Özel Aralık";
                case EN_DateRange.HEPSI:
                default:
                    return "Hepsi";
            }
        }
        #endregion

        #region Tarih Aralığı
        public static DateTime YilBasi(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = new DateTime(Bugun(dt).Year, 1, 1);

            return _newDT;
        }
        public static DateTime YilSonu(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = new DateTime(Bugun(dt).Year, 12, 31);

            return _newDT;
        }

        public static DateTime AyBasi(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = new DateTime(Bugun(dt).Year, Bugun(dt).Month, 1);

            return _newDT;
        }
        public static DateTime AySonu(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = AyBasi(dt).AddMonths(1).AddDays(-1).Date;

            return _newDT;
        }

        public static DateTime HaftaBasi(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = Bugun(dt).AddDays((((Bugun(dt).DayOfWeek.ToInt32() + 6) % 7) * -1)).Date;

            return _newDT;
        }
        public static DateTime HaftaSonu(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = HaftaBasi(dt).AddDays(6).Date;

            return _newDT;
        }

        public static DateTime Bugun(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = dt.Date;

            return _newDT;
        }
        public static DateTime Dun(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = Bugun(dt).AddDays(-1);

            return _newDT;
        }
        public static DateTime Yarin(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = Bugun(dt).AddDays(1);

            return _newDT;
        }
        public static DateTime SonrakiGun(this DateTime dt)
        {
            DateTime _newDT;

            _newDT = Bugun(dt).AddDays(2);

            return _newDT;
        }

        public static List<DateTime> GecenHafta(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(HaftaBasi(dt).AddDays(-7).Date);
            _newDT.Add(HaftaSonu(dt).AddDays(-7).Date);

            return _newDT;
        }
        public static List<DateTime> GecenAy(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(AyBasi(dt).AddMonths(-1).Date);
            _newDT.Add(dt.AddMonths(-1).AySonu().Date);

            return _newDT;
        }
        public static List<DateTime> GecenYil(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(YilBasi(dt).AddYears(-1).Date);
            _newDT.Add(YilSonu(dt).AddYears(-1).Date);

            return _newDT;
        }

        public static List<DateTime> BuHafta(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(HaftaBasi(dt).Date);
            _newDT.Add(HaftaSonu(dt).Date);

            return _newDT;
        }
        public static List<DateTime> BuAy(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(AyBasi(dt).Date);
            _newDT.Add(AySonu(dt).Date);

            return _newDT;
        }
        public static List<DateTime> BuYil(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(YilBasi(dt).Date);
            _newDT.Add(YilSonu(dt).Date);

            return _newDT;
        }

        public static List<DateTime> GelecekHafta(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(HaftaBasi(dt).AddDays(7).Date);
            _newDT.Add(HaftaSonu(dt).AddDays(7).Date);

            return _newDT;
        }
        public static List<DateTime> GelecekAy(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(AyBasi(dt).AddMonths(1).Date);
            _newDT.Add(AySonu(dt).AddMonths(1).Date);

            return _newDT;
        }
        public static List<DateTime> GelecekYil(this DateTime dt)
        {
            List<DateTime> _newDT = new List<DateTime>();

            _newDT.Add(YilBasi(dt).AddYears(1).Date);
            _newDT.Add(YilSonu(dt).AddYears(1).Date);

            return _newDT;
        }

        public static List<DateTime> GetDateRange(this EN_DateRange val, bool addStartDays = true)
        {
            List<DateTime> _newDT = new List<DateTime>();
            DateTime dt = DateTime.Now;

            switch (val)
            {
                case EN_DateRange.YOK:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(dt.Yarin());
                    break;
                case EN_DateRange.HEPSI:
                    _newDT.Add(new DateTime(2000,1,1));
                    _newDT.Add(new DateTime(2029,1,1));
                    break;
                case EN_DateRange.OZEL_ARALIK:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(dt.Yarin());
                    break;
                case EN_DateRange.BUGUN:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(dt.Yarin());
                    break;
                case EN_DateRange.BU_HAFTA:
                    _newDT.AddRange(dt.BuHafta());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.BU_AY:
                    _newDT.AddRange(dt.BuAy());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.BU_YIL:
                    _newDT.AddRange(dt.BuYil());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.YARIN:
                    _newDT.Add(dt.Yarin());
                    _newDT.Add(dt.SonrakiGun());
                    break;
                case EN_DateRange.GELECEK_HAFTA:
                    _newDT.AddRange(dt.GelecekHafta());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.GELECEK_AY:
                    _newDT.AddRange(dt.GelecekAy());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.GELECEK_YIL:
                    _newDT.AddRange(dt.GelecekYil());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.BUGUNDEN_HAFTA_SONUNA_KADAR:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(dt.HaftaSonu());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.BUGUNDEN_AY_SONUNA_KADAR:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(dt.AySonu());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.BUGUNDEN_YIL_SONUNA_KADAR:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(dt.YilSonu());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.BUGUNDEN_SONSUZA_KADAR:
                    _newDT.Add(dt.Bugun());
                    _newDT.Add(new DateTime(2029,1,1));
                    break;
                case EN_DateRange.DUN:
                    _newDT.Add(dt.Dun());
                    _newDT.Add(dt.Bugun());
                    break;
                case EN_DateRange.GECEN_HAFTA:
                    _newDT.AddRange(dt.GecenHafta());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.GECEN_AY:
                    _newDT.AddRange(dt.GecenAy());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.GECEN_YIL:
                    _newDT.AddRange(dt.GecenYil());
                    if (addStartDays)
                    {
                        _newDT[1] = _newDT[1].AddDays(1);
                    }
                    break;
                case EN_DateRange.HAFTA_BASINDAN_BUGUNE_KADAR:
                    _newDT.Add(dt.HaftaBasi());
                    _newDT.Add(dt.Bugun());
                    break;
                case EN_DateRange.AY_BASINDAN_BUGUNE_KADAR:
                    _newDT.Add(dt.AyBasi());
                    _newDT.Add(dt.Bugun());
                    break;
                case EN_DateRange.YIL_BASINDAN_BUGUNE_KADAR:
                    _newDT.Add(dt.YilBasi());
                    _newDT.Add(dt.Bugun());
                    break;
                case EN_DateRange.BASLANGIC_BUGUNE_KADAR:
                    _newDT.Add(new DateTime(2000, 1, 1));
                    _newDT.Add(dt.Bugun());
                    break;
                default:
                    break;
            }

            return _newDT;
        }
        #endregion

        #region Çevrimler
        public static int SECOND = 1000;
        public static int MINUTE = SECOND * 60;
        public static int HOUR = MINUTE * 60;

        public static int ToSecond(this int value)
        {
            return value * SECOND;
        }
        public static int ToMinute(this int value)
        {
            return value * MINUTE;
        }
        public static int ToHour(this int value)
        {
            return value * HOUR;
        }
        #endregion
    }
}
