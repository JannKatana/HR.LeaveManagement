namespace HR.LeaveManagement.Application.Models.Csv;

public class UserCsv
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Username},{Email},{FirstName},{LastName}";
    }
}