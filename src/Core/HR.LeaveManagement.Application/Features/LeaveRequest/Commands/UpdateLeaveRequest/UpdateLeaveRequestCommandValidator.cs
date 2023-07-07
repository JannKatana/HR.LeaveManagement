using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        Include(new BaseLeaveRequestValidator(leaveTypeRepository));

        RuleFor(p => p.Id).NotNull()
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("{PropertyName} mew be present");
    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
    {
        return await _leaveRequestRepository.GetByIdAsync(id) != null;
    }
}