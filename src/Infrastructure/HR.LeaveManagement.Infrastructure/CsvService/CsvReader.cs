using System.Globalization;
using HR.LeaveManagement.Application.Contracts.Csv;
using HR.LeaveManagement.Application.Models.Csv;

namespace HR.LeaveManagement.Infrastructure.CsvService;

public class CsvReader : ICsvReader
{
    public IEnumerable<T> ReadCsv<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<T>();
        return records;
    }
}