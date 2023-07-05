using MediatR;

namespace HR.LeaveManagement.Application.Features.Csv.Users.Queries;

public record ValidateUserCsvQuery(Stream file) : IRequest<List<string>>;