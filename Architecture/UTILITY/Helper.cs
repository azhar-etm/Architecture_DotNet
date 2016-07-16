using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace Utility
{
  public class ConvertCls
    {
      public static IList<T> ConvertTo<T>(DataTable table)
      {
          if (table == null)
          {
              return null;
          }
          List<DataRow> dataRow = new List<DataRow>();
          foreach (DataRow dr in table.Rows)
          {
              dataRow.Add(dr);
          }
          return ConvertTo<T>(dataRow);

      }
      public static DataTable ConvertTo<T>(IList<T> list)
      {
          DataTable table = CreateTable<T>();
          Type entityType = typeof(T);
          PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

          foreach (T item in list)
          {
              DataRow row = table.NewRow();

              foreach (PropertyDescriptor prop in properties)
              {
                  row[prop.Name] = prop.GetValue(item);
              }

              table.Rows.Add(row);
          }

          return table;
      }
      public static IList<T> ConvertTo<T>(IList<DataRow> rows)
      {
          IList<T> list = null;
          if (rows != null)
          {
              list = new List<T>();
              foreach (DataRow dr in rows)
              {
                  T item = CreateItem<T>(dr);
                  list.Add(item);
              
              }
             
          }
          return list;
      }
      public static DataTable CreateTable<T>()
      {
          Type entityType = typeof(T);
          DataTable table = new DataTable(entityType.Name);
          PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

          foreach (PropertyDescriptor prop in properties)
          {
              table.Columns.Add(prop.Name, prop.PropertyType);
          }

          return table;
      }
      public static T CreateItem<T>(DataRow row)
      {
          T obj = default(T);
          if (row != null)
          {
              
                  obj = Activator.CreateInstance<T>();
                  foreach (DataColumn column in row.Table.Columns)
                  { 
                      PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                      try
                      {

                          object value = row[column.ColumnName] == DBNull.Value ? null : row[column.ColumnName];
                          prop.SetValue(obj, value, null);
                          
                      }
                      catch (Exception ex)
                      {
                          throw;
                      }
                  }
             
          }
          return obj;
      }

    }
}
