using HR.LeaveManagement.Application.Models.Csv;

namespace HR.LeaveManagement.Application.Contracts.Csv;

public interface ICsvReader
{
    IEnumerable<T> ReadCsv<T>(Stream file);
}