using LargeXlsx;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Peiton.Contracts.Excel;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Drawing;
using System.Reflection;

namespace Peiton.Infrastructure.Services
{
    [Injectable(typeof(IExcelService))]
    public class ExcelService : IExcelService
    {
        public byte[] Export<T>(IEnumerable<T> data, IEnumerable<ColumnaExcel> columns) where T:class
        {
            
            var type = typeof(T);
            var propertyInfos = new List<PropertyInfo>();
            foreach (var column in columns)
            {
                var propertyInfo = type.GetProperty(column.Propiedad);
                if(propertyInfo == null) throw new ArgumentException($"No existe la propiedad { column.Propiedad } en {type.Name}");
                propertyInfos.Add(propertyInfo);
            }

            using var stream = new MemoryStream();
            using var xlsxWriter = new XlsxWriter(stream);

            xlsxWriter.BeginWorksheet("Sheet1", 1, 1);
            xlsxWriter.BeginRow();
            
            foreach (var column in columns)
            {
                xlsxWriter.Write(column.Descripcion);
            }

            var dateStyle = XlsxStyle.Default.With(XlsxNumberFormat.ShortDateTime);

            var typeMap = new Dictionary<Type, Action<XlsxWriter, object>>()
            {
                { typeof(string), (writer, value) => {
                    writer.Write((string)value); }
                },
                
                { typeof(DateTime), (writer, value) => writer.Write((DateTime)value, dateStyle) },
                { typeof(DateTime?), (writer, value) => writer.Write((DateTime)value, dateStyle) },
                { typeof(decimal), (writer, value) => writer.Write((decimal)value) },
                { typeof(decimal?), (writer, value) => writer.Write((decimal)value) },
                { typeof(int), (writer, value) => writer.Write((int)value) },
                { typeof(int?), (writer, value) => writer.Write((int)value) },
                { typeof(double), (writer, value) => writer.Write((double)value) },
                { typeof(double?), (writer, value) => writer.Write((double)value) },
                { typeof(bool), (writer, value) => writer.Write((bool)value) },
                { typeof(bool?), (writer, value) => writer.Write((bool)value) },
            };

            foreach (var item in data)
            {
                xlsxWriter.BeginRow();

                foreach(var propertyInfo in propertyInfos) {
                    var value = propertyInfo.GetValue(item);
                    if (value == null) {
                        xlsxWriter.Write();
                        continue;
                    }
                    
                    typeMap[propertyInfo.PropertyType](xlsxWriter, value);
                    
                }
                
            }

            xlsxWriter.Dispose();
            return stream.ToArray();

        }

        public byte[] Export<T>(IEnumerable<T> data, IEnumerable<string> properties) where T : class
        {
            return this.Export(data, properties.Select(p => new ColumnaExcel(p, p)));
        }
    }
}
