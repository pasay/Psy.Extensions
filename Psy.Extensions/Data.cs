using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;

namespace System
{

    /// <summary>
    /// DataSet vb. Data 'lardan veri alınırken hata vermesini engeller.
    /// </summary>
    public static class DataClass
    {
        public static DateTime TryValueDateTime = new DateTime(1900, 1, 1);
        public static double TryValueZero = 0;
        public static string TryValueEmpty = "";
        public static bool TryValueBool = false;

        #region GetTable
        public static DataTable GetTable(this System.Data.DataSet dataSet, string tableName)
        {
            if (dataSet == null)
            {
                return new DataTable(tableName);
            }

            if (dataSet.Tables.Contains(tableName) == false)
            {
                return new DataTable(tableName);
            }

            return dataSet.Tables[tableName];
        }
        public static DataTable GetTable(this System.Data.DataSet dataSet, int tableIndex)
        {
            if (dataSet == null)
            {
                return new DataTable();
            }

            if (dataSet.Tables.Count <= tableIndex)
            {
                return new DataTable();
            }

            return dataSet.Tables[tableIndex];
        }
        public static DataTable GetTable(this System.Data.DataSet dataSet)
        {
            if (dataSet == null)
            {
                return new DataTable();
            }

            return dataSet.GetTable(0);
        }
        #endregion

        #region GetRow
        public static DataRow GetRow(this System.Data.DataSet dataSet, string tableName)
        {
            DataTable dt = dataSet.GetTable(tableName);
            return dt.GetRow();
        }
        public static DataRow GetRow(this System.Data.DataSet dataSet, string tableName, int rowIndex)
        {
            DataTable dt = dataSet.GetTable(tableName);
            return dt.GetRow(rowIndex);
        }
        public static DataRow GetRow(this System.Data.DataSet dataSet, int tableIndex)
        {
            DataTable dt = dataSet.GetTable(tableIndex);
            return dt.GetRow();
        }
        public static DataRow GetRow(this System.Data.DataSet dataSet, int tableIndex, int rowIndex)
        {
            DataTable dt = dataSet.GetTable(tableIndex);
            return dt.GetRow(rowIndex);
        }
        public static DataRow GetRow(this System.Data.DataSet dataSet)
        {
            DataTable dt = dataSet.GetTable();
            return dt.GetRow();
        }

        public static DataRow GetRow(this System.Data.DataTable dataTable, int rowIndex)
        {
            if (dataTable == null)
            {
                return null;
            }
            if (dataTable.Rows.Count <= rowIndex)
            {
                return null;
            }

            return dataTable.Rows[rowIndex];
        }
        public static DataRow GetRow(this System.Data.DataTable dataTable)
        {
            return dataTable.GetRow(0);
        }
        #endregion

        #region GetValueOrEmpty
        public static object GetValueOrEmpty(this System.Data.DataSet dataSet, string column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueEmpty;
            }

            return dataSet.Tables[0].GetValueOrEmpty(column, rowIndex);
        }
        public static object GetValueOrEmpty(this System.Data.DataTable dataTable, string column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueEmpty;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return TryValueEmpty;
            }

            return dataTable.Rows[rowIndex].GetValueOrEmpty(column);
        }
        public static object GetValueOrEmpty(this DataRowCollection rows, string column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueEmpty;
            }
            DataRow row = rows[0];

            return row.GetValueOrEmpty(column);
        }
        public static object GetValueOrEmpty(this IEnumerable<DataRow> rows, string column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueEmpty;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrEmpty(column);
        }
        public static object GetValueOrEmpty(this DataRow row, string column)
        {
            if (row == null)
            {
                return TryValueEmpty;
            }

            if (row.Table.Columns.Contains(column) == false)
            {
                return TryValueEmpty;
            }
            return (row[column] is DBNull || row[column] == null) ? TryValueEmpty : row[column];
        }

        public static object GetValueOrEmpty(this System.Data.DataSet dataSet, int column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueEmpty;
            }

            return dataSet.Tables[0].GetValueOrEmpty(column, rowIndex);
        }
        public static object GetValueOrEmpty(this System.Data.DataTable dataTable, int column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueEmpty;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return TryValueEmpty;
            }

            return dataTable.Rows[rowIndex].GetValueOrEmpty(column);
        }
        public static object GetValueOrEmpty(this DataRowCollection rows, int column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueEmpty;
            }
            DataRow row = rows[0];

            return row.GetValueOrEmpty(column);
        }
        public static object GetValueOrEmpty(this IEnumerable<DataRow> rows, int column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueEmpty;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrEmpty(column);
        }
        public static object GetValueOrEmpty(this DataRow row, int column)
        {
            if (row == null)
            {
                return TryValueEmpty;
            }

            if (row.Table.Columns.Count <= column)
            {
                return TryValueEmpty;
            }

            return (row[column] is DBNull || row[column] == null) ? TryValueEmpty : row[column];
        }
        #endregion

        #region GetFirstValueOrEmpty
        public static object GetFirstValueOrEmpty(this System.Data.DataSet dataSet)
        {
            if (dataSet == null)
            {
                return TryValueEmpty;
            }

            return dataSet.GetValueOrEmpty(0, 0);
        }
        #endregion

        #region GetValueOrZero
        public static object GetValueOrZero(this System.Data.DataSet dataSet, string column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueZero;
            }

            return dataSet.Tables[0].GetValueOrZero(column, rowIndex);
        }
        public static object GetValueOrZero(this System.Data.DataTable dataTable, string column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueZero;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return TryValueZero;
            }

            return dataTable.Rows[rowIndex].GetValueOrZero(column);
        }
        public static object GetValueOrZero(this DataRowCollection rows, string column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueZero;
            }
            DataRow row = rows[0];

            return row.GetValueOrZero(column);
        }
        public static object GetValueOrZero(this IEnumerable<DataRow> rows, string column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueZero;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrZero(column);
        }
        public static object GetValueOrZero(this DataRow row, string column)
        {
            if (row.HasRowValue(column) == false)
            {
                return TryValueZero;
            }

            return (row[column] is DBNull || row[column] == null) ? TryValueZero : row[column];
        }

        public static object GetValueOrZero(this System.Data.DataSet dataSet, int column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueZero;
            }

            return dataSet.Tables[0].GetValueOrZero(column, rowIndex);
        }
        public static object GetValueOrZero(this System.Data.DataTable dataTable, int column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueZero;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return TryValueZero;
            }

            return dataTable.Rows[rowIndex].GetValueOrZero(column);
        }
        public static object GetValueOrZero(this DataRowCollection rows, int column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueZero;
            }
            DataRow row = rows[0];

            return row.GetValueOrZero(column);
        }
        public static object GetValueOrZero(this IEnumerable<DataRow> rows, int column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueZero;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrZero(column);
        }
        public static object GetValueOrZero(this DataRow row, int column)
        {
            if (row.HasRowValue(column) == false)
            {
                return TryValueZero;
            }

            return (row[column] is DBNull || row[column] == null) ? TryValueZero : row[column];
        }
        #endregion

        #region GetFirstValueOrZero
        public static object GetFirstValueOrZero(this System.Data.DataSet dataSet)
        {
            if (dataSet == null)
            {
                return TryValueZero;
            }

            return dataSet.GetValueOrZero(0, 0);
        }
        #endregion

        #region GetValueOrDate
        public static object GetValueOrDate(this System.Data.DataSet dataSet, string column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueDateTime;
            }

            return dataSet.Tables[0].GetValueOrDate(column, rowIndex);
        }
        public static object GetValueOrDate(this System.Data.DataTable dataTable, string column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueDateTime;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return TryValueDateTime;
            }

            return dataTable.Rows[rowIndex].GetValueOrDate(column);
        }
        public static object GetValueOrDate(this DataRowCollection rows, string column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueDateTime;
            }
            DataRow row = rows[0];

            return row.GetValueOrDate(column);
        }
        public static object GetValueOrDate(this IEnumerable<DataRow> rows, string column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueDateTime;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrDate(column);
        }
        public static object GetValueOrDate(this DataRow row, string column)
        {
            return row.GetValueOrDate(column, TryValueDateTime);
        }
        public static object GetValueOrDate(this DataRow row, string column, DateTime retVal)
        {
            if (row.HasRowValue(column) == false)
            {
                return retVal;
            }

            return row[column] ?? retVal;
        }

        public static object GetValueOrDate(this System.Data.DataSet dataSet, int column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueDateTime;
            }

            return dataSet.Tables[0].GetValueOrDate(column, rowIndex);
        }
        public static object GetValueOrDate(this System.Data.DataTable dataTable, int column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueDateTime;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return TryValueDateTime;
            }

            return dataTable.Rows[rowIndex].GetValueOrDate(column);
        }
        public static object GetValueOrDate(this DataRowCollection rows, int column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueDateTime;
            }
            DataRow row = rows[0];

            return row.GetValueOrDate(column);
        }
        public static object GetValueOrDate(this IEnumerable<DataRow> rows, int column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueDateTime;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrDate(column);
        }
        public static object GetValueOrDate(this DataRow row, int column)
        {
            return row.GetValueOrDate(column, TryValueDateTime);
        }
        public static object GetValueOrDate(this DataRow row, int column, DateTime retVal)
        {
            if (row.HasRowValue(column) == false)
            {
                return retVal;
            }

            return row[column] ?? retVal;
        }
        #endregion

        #region GetFirstValueOrDate
        public static object GetFirstValueOrDate(this System.Data.DataSet dataSet)
        {
            if (dataSet == null)
            {
                return TryValueDateTime;
            }

            return dataSet.GetValueOrDate(0, 0);
        }
        #endregion

        #region GetValueOrBool
        public static object GetValueOrBool(this System.Data.DataSet dataSet, string column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueBool;
            }

            return dataSet.Tables[0].GetValueOrBool(column, rowIndex);
        }
        public static object GetValueOrBool(this System.Data.DataTable dataTable, string column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueBool;
            }

            if (dataTable.Rows.Count > rowIndex)
            {
                return TryValueBool;
            }

            return dataTable.Rows[rowIndex].GetValueOrBool(column);
        }
        public static object GetValueOrBool(this DataRowCollection rows, string column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueBool;
            }
            DataRow row = rows[0];

            return row.GetValueOrBool(column);
        }
        public static object GetValueOrBool(this IEnumerable<DataRow> rows, string column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueBool;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrBool(column);
        }
        public static object GetValueOrBool(this DataRow row, string column)
        {
            if (row.HasRowValue(column) == false)
            {
                return TryValueBool;
            }

            return (row[column] is DBNull || row[column] == null) ? TryValueBool : row[column];
        }

        public static object GetValueOrBool(this System.Data.DataSet dataSet, int column, int rowIndex)
        {
            if (dataSet.HasRowValue() == false)
            {
                return TryValueBool;
            }

            return dataSet.Tables[0].GetValueOrBool(column, rowIndex);
        }
        public static object GetValueOrBool(this System.Data.DataTable dataTable, int column, int rowIndex)
        {
            if (dataTable.HasRowValue() == false)
            {
                return TryValueBool;
            }

            if (dataTable.Rows.Count > rowIndex)
            {
                return TryValueBool;
            }

            return dataTable.Rows[rowIndex].GetValueOrBool(column);
        }
        public static object GetValueOrBool(this DataRowCollection rows, int column)
        {
            if (rows == null || rows.Count == 0)
            {
                return TryValueBool;
            }
            DataRow row = rows[0];

            return row.GetValueOrBool(column);
        }
        public static object GetValueOrBool(this IEnumerable<DataRow> rows, int column)
        {
            if (rows == null || rows.Count() == 0)
            {
                return TryValueBool;
            }
            DataRow row = rows.FirstOrDefault();

            return row.GetValueOrBool(column);
        }
        public static object GetValueOrBool(this DataRow row, int column)
        {
            if (row.HasRowValue(column) == false)
            {
                return TryValueBool;
            }

            return (row[column] is DBNull || row[column] == null) ? TryValueBool : row[column];
        }

        public static bool GetValueOrBool(this System.Data.DataSet dataSet, string column, int rowIndex, bool tryReturnValue)
        {
            if (dataSet.HasRowValue() == false)
            {
                return tryReturnValue;
            }

            return dataSet.Tables[0].GetValueOrBool(column, rowIndex).ToBoolean(tryReturnValue);
        }
        public static bool GetValueOrBool(this System.Data.DataTable dataTable, string column, int rowIndex, bool tryReturnValue)
        {
            if (dataTable.HasRowValue() == false)
            {
                return tryReturnValue;
            }

            if (dataTable.Rows.Count > rowIndex)
            {
                return tryReturnValue;
            }

            return dataTable.Rows[rowIndex].GetValueOrBool(column).ToBoolean(tryReturnValue);
        }
        public static bool GetValueOrBool(this DataRow row, string column, bool tryReturnValue)
        {
            if (row.HasRowValue(column) == false)
            {
                return tryReturnValue;
            }

            return row[column].ToBoolean(tryReturnValue);
        }

        public static bool GetValueOrBool(this System.Data.DataSet dataSet, int column, int rowIndex, bool tryReturnValue)
        {
            if (dataSet.HasRowValue() == false)
            {
                return tryReturnValue;
            }

            return dataSet.Tables[0].GetValueOrBool(column, rowIndex).ToBoolean(tryReturnValue);
        }
        public static bool GetValueOrBool(this System.Data.DataTable dataTable, int column, int rowIndex, bool tryReturnValue)
        {
            if (dataTable.HasRowValue() == false)
            {
                return tryReturnValue;
            }

            if (dataTable.Rows.Count > rowIndex)
            {
                return tryReturnValue;
            }

            return dataTable.Rows[rowIndex].GetValueOrBool(column).ToBoolean(tryReturnValue);
        }
        public static bool GetValueOrBool(this DataRow row, int column, bool tryReturnValue)
        {
            if (row.HasRowValue(column) == false)
            {
                return tryReturnValue;
            }

            return row[column].ToBoolean(tryReturnValue);
        }
        #endregion

        #region GetFirstValueOrBool
        public static object GetFirstValueOrBool(this System.Data.DataSet dataSet)
        {
            if (dataSet == null)
            {
                return TryValueBool;
            }

            return dataSet.GetValueOrBool(0, 0);
        }
        public static object GetFirstValueOrBool(this System.Data.DataSet dataSet, bool tryReturnValue)
        {
            if (dataSet == null)
            {
                return tryReturnValue;
            }

            return dataSet.GetValueOrBool(0, 0, tryReturnValue);
        }
        #endregion

        #region GetValueOrDefault
        public static object GetValueOrDefault(this System.Data.DataSet dataSet, string column, int rowIndex, object defaulRetValue)
        {
            if (dataSet.HasRowValue() == false)
            {
                return defaulRetValue;
            }

            return dataSet.Tables[0].GetValueOrDefault(column, rowIndex, defaulRetValue);
        }
        public static object GetValueOrDefault(this System.Data.DataTable dataTable, string column, int rowIndex, object defaulRetValue)
        {
            if (dataTable.HasRowValue() == false)
            {
                return defaulRetValue;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return defaulRetValue;
            }

            return dataTable.Rows[rowIndex].GetValueOrDefault(column, defaulRetValue);
        }
        public static object GetValueOrDefault(this DataRowCollection rows, string column, object defaulRetValue)
        {
            return rows.GetValueOrDefault(column, 0, defaulRetValue);
        }
        public static object GetValueOrDefault(this IEnumerable<DataRow> rows, string column, object defaulRetValue)
        {
            return rows.GetValueOrDefault(column, 0, defaulRetValue);
        }
        public static object GetValueOrDefault(this DataRowCollection rows, string column, int rowIndex, object defaulRetValue)
        {
            if (rows == null || rows.Count <= rowIndex)
            {
                return defaulRetValue;
            }
            DataRow row = rows[rowIndex];

            return row.GetValueOrDefault(column, defaulRetValue);
        }
        public static object GetValueOrDefault(this IEnumerable<DataRow> rows, string column, int rowIndex, object defaulRetValue)
        {
            if (rows == null || rows.Count() <= rowIndex)
            {
                return defaulRetValue;
            }
            DataRow row = rows.Skip(rowIndex).FirstOrDefault();

            return row.GetValueOrDefault(column, defaulRetValue);
        }
        public static object GetValueOrDefault(this DataRow row, string column, object defaulRetValue)
        {
            if (row == null)
            {
                return defaulRetValue;
            }

            if (row.Table.Columns.Contains(column) == false)
            {
                return defaulRetValue;
            }

            return (row[column] is DBNull || row[column] == null) ? defaulRetValue : row[column];
        }

        public static object GetValueOrDefault(this System.Data.DataSet dataSet, int column, int rowIndex, object defaulRetValue)
        {
            if (dataSet.HasRowValue() == false)
            {
                return defaulRetValue;
            }

            return dataSet.Tables[0].GetValueOrDefault(column, rowIndex, defaulRetValue);
        }
        public static object GetValueOrDefault(this System.Data.DataTable dataTable, int column, int rowIndex, object defaulRetValue)
        {
            if (dataTable.HasRowValue() == false)
            {
                return defaulRetValue;
            }

            if (dataTable.Rows.Count <= rowIndex)
            {
                return defaulRetValue;
            }

            return dataTable.Rows[rowIndex].GetValueOrDefault(column, defaulRetValue);
        }
        public static object GetValueOrDefault(this DataRowCollection rows, int column, object defaulRetValue)
        {
            return rows.GetValueOrDefault(column, 0, defaulRetValue);
        }
        public static object GetValueOrDefault(this IEnumerable<DataRow> rows, int column, object defaulRetValue)
        {
            return rows.GetValueOrDefault(column, 0, defaulRetValue);
        }
        public static object GetValueOrDefault(this DataRowCollection rows, int column, int rowIndex, object defaulRetValue)
        {
            if (rows == null || rows.Count <= rowIndex)
            {
                return defaulRetValue;
            }
            DataRow row = rows[rowIndex];

            return row.GetValueOrDefault(column, defaulRetValue);
        }
        public static object GetValueOrDefault(this IEnumerable<DataRow> rows, int column, int rowIndex, object defaulRetValue)
        {
            if (rows == null || rows.Count() <= rowIndex)
            {
                return defaulRetValue;
            }
            DataRow row = rows.Skip(rowIndex).FirstOrDefault();

            return row.GetValueOrDefault(column, defaulRetValue);
        }
        public static object GetValueOrDefault(this DataRow row, int column, object defaulRetValue)
        {
            if (row == null)
            {
                return defaulRetValue;
            }

            if (row.Table.Columns.Count <= column)
            {
                return defaulRetValue;
            }

            return (row[column] is DBNull || row[column] == null) ? defaulRetValue : row[column];
        }
        #endregion

        #region HasRowValue
        public static bool HasRowValue(this DataSet dataSet)
        {
            if (dataSet == null)
            {
                return false;
            }
            if (dataSet.Tables.Count == 0)
            {
                return false;
            }

            return dataSet.Tables[0].HasRowValue();
        }
        public static bool HasRowValue(this DataTable table)
        {
            if (table == null)
            {
                return false;
            }
            if (table.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }
        public static bool HasRowValue(this DataRow[] row)
        {
            if (row == null || row.Length == 0)
            {
                return false;
            }

            return true;
        }
        public static bool HasRowValue(this DataRowCollection row)
        {
            if (row == null || row.Count == 0)
            {
                return false;
            }

            return true;
        }
        public static bool HasRowValue(this DataRow row)
        {
            if (row == null)
            {
                return false;
            }

            return row.HasRowValue(0);
        }
        public static bool HasRowValue(this DataRow row, string column)
        {
            if (row == null)
            {
                return false;
            }

            if (row.Table.Columns.Contains(column) == false)
            {
                return false;
            }

            return true;
        }
        public static bool HasRowValue(this DataRow row, int column)
        {
            if (row == null)
            {
                return false;
            }

            if (row.Table.Columns.Count <= column)
            {
                return false;
            }

            return true;
        }

        public static bool HasRowValue(this IEnumerable<object> value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Count() <= 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region GetChangedColumns
        public static List<DataColumn> GetChangedColumns(this DataSet dataSet)
        {
            return GetChangedColumns(dataSet, StringComparison.InvariantCultureIgnoreCase, false);
        }
        public static List<DataColumn> GetChangedColumns(this DataTable table)
        {
            return GetChangedColumns(table, StringComparison.InvariantCultureIgnoreCase, false);
        }
        public static List<DataColumn> GetChangedColumns(this DataRow row)
        {
            return GetChangedColumns(row, StringComparison.InvariantCultureIgnoreCase, false);
        }

        public static List<DataColumn> GetChangedColumns(this DataSet dataSet, bool ignoreWhitespace)
        {
            return GetChangedColumns(dataSet, StringComparison.InvariantCultureIgnoreCase, ignoreWhitespace);
        }
        public static List<DataColumn> GetChangedColumns(this DataTable table, bool ignoreWhitespace)
        {
            return GetChangedColumns(table, StringComparison.InvariantCultureIgnoreCase, ignoreWhitespace);
        }
        public static List<DataColumn> GetChangedColumns(this DataRow row, bool ignoreWhitespace)
        {
            return GetChangedColumns(row, StringComparison.InvariantCultureIgnoreCase, ignoreWhitespace);
        }

        public static List<DataColumn> GetChangedColumns(this DataSet dataSet, StringComparison stringComparison, bool ignoreWhitespace)
        {
            if (dataSet.HasRowValue() == false)
            {
                return new List<DataColumn>();
            }

            return dataSet.Tables[0].GetChangedColumns(stringComparison, ignoreWhitespace);
        }
        public static List<DataColumn> GetChangedColumns(this DataTable table, StringComparison stringComparison, bool ignoreWhitespace)
        {
            List<DataColumn> columnsChanged = new List<DataColumn>();
            if (table.HasRowValue() == false )
            {
                return columnsChanged;
            }

            foreach (DataRow row in table.GetChanges().Rows)
            {
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (!columnsChanged.Contains(col) && HasColumnChanged(stringComparison, ignoreWhitespace, row, col))
                    {
                        columnsChanged.Add(col);
                    }
                }
            }
            return columnsChanged;
        }
        public static List<DataColumn> GetChangedColumns(this DataRow row, StringComparison stringComparison, bool ignoreWhitespace)
        {
            List<DataColumn> columnsChanged = new List<DataColumn>();
            if (row == null)
            {
                return columnsChanged;
            }

            foreach (DataColumn col in row.Table.Columns)
            {
                if (!columnsChanged.Contains(col) && HasColumnChanged(stringComparison, ignoreWhitespace, row, col))
                {
                    columnsChanged.Add(col);
                }
            }
            return columnsChanged;
        }

        private static bool HasColumnChanged(StringComparison stringComparison, bool ignoreWhitespace, DataRow row, DataColumn col)
        {
            bool isEqual = true;

            try
            {
                if (((row[col, DataRowVersion.Original] != null)) && ((row[col, DataRowVersion.Current] != null)))
                {
                    if (ignoreWhitespace)
                    {
                        isEqual = row[col, DataRowVersion.Original].ToString().Trim().Equals(row[col, DataRowVersion.Current].ToString().Trim(), stringComparison);
                    }
                    else
                    {
                        isEqual = row[col, DataRowVersion.Original].ToString().Equals(row[col, DataRowVersion.Current].ToString(), stringComparison);
                    }
                }
                else
                {
                    isEqual = row[col, DataRowVersion.Original].Equals(row[col, DataRowVersion.Current]);
                }

            }
            catch //(Exception ex)
            {
            }
            return !isEqual;
        }
        #endregion

        #region Convert
        #region ToHtml
        /// <summary>
        /// DataTable dt = new DataTable();
        /// Populate your Table here
        /// string htmlTable = dt.ConvertDataTableToHTML();
        /// </summary>
        public static string ToHtml(this DataTable dt)
        {
            string html = "<table>";

            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";

            return html;
        }
        #endregion

        #region ToList
        /// <summary>
        /// var myList = dt.ToList();
        /// </summary>
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region ToDataTable
        /// <summary>
        /// List<string> myList = New String[]{"a","b","c","d"}.ToList();
        /// DataTable dt = new DataTable();
        /// dt = myList.ToDataTable();
        /// </summary>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            
            DataTable table = new DataTable("Table1");
            if ((typeof(T) == typeof(string)) == false)
            {
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            if (table.Columns.Count == 0)
            {
                table.Columns.Add("Column1");
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                bool find = false;

                if ((typeof(T) == typeof(string)) == false)
                {
                    foreach (PropertyDescriptor prop in properties)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        find = true;
                    }
                }

                if (find == false && (table.Columns.Count == 1))
                {
                    row[0] = item.ToStringAbs();
                }

                table.Rows.Add(row);
            }

            return table;
        }
        #endregion

        #region ToDataTableWhere
        public static DataTable ToDataTableWhere(this DataTable value, Func<DataRow, bool> predicate)
        {
            if (value == null) { return new DataTable(); }
            DataTable dt = value.Clone();

            foreach (DataRow item in value.Rows.Cast<DataRow>().Where(predicate))
            {
                dt.ImportRow(item);
            }

            return dt;
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// SQL Server ile ilgili bilgileri verir.
    /// </summary>
    public static class SqlClass
    {
        public static List<string> EnumerateSQLInstances()
        {
            List<string> retVal = new List<string>();

            List<string> correctNamespaces = GetCorrectWmiNameSpace();
            foreach (string correctNamespace in correctNamespaces)
            {
                ManagementObjectSearcher getSqlEngine;
                try
                {
                    if (string.Equals(correctNamespace, string.Empty))
                    {
                        continue;
                    }
                    string query = string.Format("select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and PropertyName = 'instanceID'");
                    getSqlEngine = new ManagementObjectSearcher(correctNamespace, query);
                    if (getSqlEngine.Get().Count == 0)
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }

                //Console.WriteLine("SQL Server database instances discovered :");
                string instanceName = string.Empty;
                string serviceName = string.Empty;
                string version = string.Empty;
                string edition = string.Empty;
                //Console.WriteLine("Instance Name \t ServiceName \t Edition \t Version \t");
                foreach (ManagementObject sqlEngine in getSqlEngine.Get())
                {
                    serviceName = sqlEngine["ServiceName"].ToString();
                    instanceName = GetInstanceNameFromServiceName(serviceName);
                    //version = GetWmiPropertyValueForEngineService(serviceName, correctNamespace, "Version");
                    //edition = GetWmiPropertyValueForEngineService(serviceName, correctNamespace, "SKUNAME");
                    //Console.Write("{0} \t", instanceName);
                    //Console.Write("{0} \t", serviceName);
                    //Console.Write("{0} \t", edition);
                    ////Console.WriteLine("{0} \t", version);

                    retVal.Add(instanceName);
                }
            }
            return retVal;
        }

        public static List<string> GetCorrectWmiNameSpace()
        {
            string wmiNamespaceToUse = "root\\Microsoft\\sqlserver";
            string wmiNamespace = "root\\Microsoft\\sqlserver";
            List<string> lstWmiNamespaceToUse = new List<string>();
            List<string> namespaces = new List<string>();
            try
            {
                // Enumerate all WMI instances of
                // __namespace WMI class.
                ManagementClass nsClass =
                    new ManagementClass(
                    new ManagementScope(wmiNamespaceToUse),
                    new ManagementPath("__namespace"),
                    null);
                foreach (ManagementObject ns in
                    nsClass.GetInstances())
                {
                    namespaces.Add(ns["Name"].ToString());
                }
            }
            catch //(ManagementException mex)
            {
                //Console.WriteLine("Exception = " + e.Message);
            }
            foreach (string item in namespaces)
            {
                if (item.Contains("ComputerManagement"))
                {
                    //use katmai+ namespace
                    wmiNamespace = wmiNamespaceToUse + "\\" + item;
                }
                else
                {
                    continue;
                }

                if (string.IsNullOrEmpty(wmiNamespace) == false)
                {
                    lstWmiNamespaceToUse.Add(wmiNamespace);
                }
            }

            return lstWmiNamespaceToUse;
        }

        public static string GetInstanceNameFromServiceName(string serviceName)
        {
            if (!string.IsNullOrEmpty(serviceName))
            {
                if (string.Equals(serviceName, "MSSQLSERVER", StringComparison.OrdinalIgnoreCase))
                {
                    return serviceName;
                }
                else
                {
                    return serviceName.Substring(serviceName.IndexOf('$') + 1, serviceName.Length - serviceName.IndexOf('$') - 1);
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetWmiPropertyValueForEngineService(string serviceName, string wmiNamespace, string propertyName)
        {
            string propertyValue = string.Empty;
            string query = String.Format("select * from SqlServiceAdvancedProperty where SQLServiceType = 1 and PropertyName = '{0}' and ServiceName = '{1}'", propertyName, serviceName);
            ManagementObjectSearcher propertySearcher = new ManagementObjectSearcher(wmiNamespace, query);
            foreach (ManagementObject sqlEdition in propertySearcher.Get())
            {
                propertyValue = sqlEdition["PropertyStrValue"].ToString();
            }
            return propertyValue;
        }
    }
}
