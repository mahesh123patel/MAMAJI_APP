using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MAMAJI_APP.Class
{
    public static class ListExtention
    {
        public static DataTable ToDataTable<T>(this List<T> items, params string[] propertyNames)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties of T
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Filter the properties to include only the specified property names
            var filteredProperties = properties.Where(prop => propertyNames.Contains(prop.Name)).ToArray();

            // Add columns to DataTable
            foreach (PropertyInfo prop in filteredProperties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add rows to DataTable
            foreach (T item in items)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo prop in filteredProperties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}