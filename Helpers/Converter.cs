using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace AdayaTestWeb.Helpers
{
    public static class Converter
    {

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<TRequest>(this IList<TRequest> requests)
        {
            var properties = TypeDescriptor.GetProperties(typeof(TRequest));

            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            if (!requests.Any()) return table;
            foreach (var item in requests)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo info in typeof(TRequest).GetProperties())
                {
                    row[info.Name] = info.GetValue(item, null) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public static IEnumerable<TResponse> ToIEnumerable<TResponse>(this DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(TResponse).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<TResponse>();
                foreach (var property in properties)
                {
                    if (columnNames.Contains(property.Name.ToLower()))
                    {
                        try
                        {
                            property.SetValue(objT, row[property.Name]);
                        }
                        catch (Exception ex) 
                        {
                            throw new KeyNotFoundException(ex.ToString());
                        }
                    }
                }
                return objT;
            });
        }
    }
}
