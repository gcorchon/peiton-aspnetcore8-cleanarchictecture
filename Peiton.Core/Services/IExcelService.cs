using Peiton.Contracts.Excel;

namespace Peiton.Core.Services
{
    public interface IExcelService
    {
        byte[] Export<T>(IEnumerable<T> data, IEnumerable<ColumnaExcel> columns) where T : class;
        byte[] Export<T>(IEnumerable<T> data, IEnumerable<string> properties) where T : class;
    }
}
