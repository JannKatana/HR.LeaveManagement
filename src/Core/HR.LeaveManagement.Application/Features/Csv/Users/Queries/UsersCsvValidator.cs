using FluentValidation;
using HR.LeaveManagement.Application.Models.Csv;

namespace HR.LeaveManagement.Application.Features.Csv.ReadUsers.Queries;

public class UsersCsvValidator : AbstractValidator<UserCsv>
{
    public UsersCsvValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer that 70 characters")
            .Matches("^[A-Za-z][A-Za-z0-9_]{7,29}$").WithMessage("{PropertyName} must be a valid username");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer that 70 characters")
            .EmailAddress().WithMessage("{PropertyName} must be a valid email");

        // RuleFor(p => p.DefaultDays)
        //     .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
        //     .GreaterThan(1).WithMessage("{PropertyName} Cannot be less than 1");

        // RuleFor(q => q)
        //     .MustAsync(LeaveTypeNameUnique)
        //     .WithMessage("Leave type must be unique");
    }
}