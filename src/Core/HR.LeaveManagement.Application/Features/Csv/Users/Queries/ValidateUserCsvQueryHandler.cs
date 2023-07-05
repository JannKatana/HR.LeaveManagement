using System.Security;
using HR.LeaveManagement.Application.Contracts.Csv;
using HR.LeaveManagement.Application.Features.Csv.ReadUsers.Queries;
using HR.LeaveManagement.Application.Models.Csv;
using MediatR;

namespace HR.LeaveManagement.Application.Features.Csv.Users.Queries;

public class ValidateUserCsvQueryHandler : IRequestHandler<ValidateUserCsvQuery, List<string>>
{
    private readonly ICsvReader _csvReader;

    public ValidateUserCsvQueryHandler(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public async Task<List<string>> Handle(ValidateUserCsvQuery request, CancellationToken cancellationToken)
    {
        var users = _csvReader.ReadCsv<UserCsv>(request.file).ToList();
        var validator = new UsersCsvValidator();

        List<string> validationErrorMessages = new List<string>();
        foreach (var user in users)
        {
            var validationResult = await validator.ValidateAsync(user);

            var validationMessages = string.Join(",", validationResult.Errors.Select(s => $"{s.ErrorMessage}"));
            validationErrorMessages.Add($"{user.ToString()},{validationMessages}");
        }

        return validationErrorMessages;
    }
}