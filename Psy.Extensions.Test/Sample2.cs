using System;
using System.Data; //<<-- This NameSpace Activate Dataset proceess by Psy.Extensions

namespace Psy.Extensions.Test
{
    static class Sample2
    {
        internal static void Run()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            DataColumn dc1 = new DataColumn("StringCol"     , typeof(string)    );
            DataColumn dc2 = new DataColumn("IntCol"        , typeof(int)       );
            DataColumn dc3 = new DataColumn("DateTimeCol"   , typeof(DateTime)  );
            DataColumn dc4 = new DataColumn("Double1Col"    , typeof(double)    );
            DataColumn dc5 = new DataColumn("Double2Col"    , typeof(string)    ); //I Will User DOT Character with String Cast. You think multilanguage code writing
            DataColumn dc6 = new DataColumn("Double3Col"    , typeof(string)    ); //I Will User COMMA Character with String Cast. You think multilanguage code writing
            dt.Columns.AddRange(new DataColumn[] { dc1, dc2, dc3, dc4, dc5, dc6 });

            DataRow dr = dt.NewRow();
            dr["StringCol"]     = "test1";
            dr["IntCol"]        = null; //<<-- This is nothing value
            dr["DateTimeCol"]   = DateTime.Now;
            dr["Double1Col"]    = 3.17; //Original Double
            dr["Double2Col"]    = "3.17"; //String Double But it has Dot Character in your culture
            dr["Double3Col"]    = "3,17"; //String Double But it has Comma Character in your culture
            dt.Rows.Add(dr);

            string Col1; int Col2; DateTime Col3; 
            double Col4; double Col5; double Col6;

            //Standart Convert
            Col1 = Convert.ToString(    dr["StringCol"  ]);  //OK
            Col2 = Convert.ToInt32(     dr["IntCol"     ]);  //System.InvalidCastException
            Col3 = Convert.ToDateTime(  dr["DateTimeCol"]);  //OK
            Col4 = Convert.ToDouble(    dr["Double1Col" ]);  //OK
            Col5 = Convert.ToDouble(    dr["Double2Col" ]);  //System.InvalidCastException (Your culture is DOT)
            Col6 = Convert.ToDouble(    dr["Double3Col" ]);  //System.InvalidCastException (Your culture is COMMA)

            //<<-- Psy.Extensions Convert
            Col1 = dr.GetValueOrEmpty("StringCol"   ).ToStringAbs();                //OK
            Col2 = dr.GetValueOrZero("IntCol"       ).ToInt32();                    //OK
            Col3 = dr.GetValueOrDate("DateTimeCol"  ).ToDateTime();                 //OK
            Col4 = dr.GetValueOrZero("Double1Col"   ).ToDoubleDecimalCharacter();   //OK
            Col5 = dr.GetValueOrZero("Double2Col"   ).ToDoubleDecimalCharacter();   //OK
            Col6 = dr.GetValueOrZero("Double3Col"   ).ToDoubleDecimalCharacter();   //OK
                                                   
        }                                          
    }                                              
}
