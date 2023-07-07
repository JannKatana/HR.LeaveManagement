using HR.LeaveManagement.Application.Contracts.Logging;
using MediatR;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<DeleteLeaveTypeCommandHandler> _logger;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<DeleteLeaveTypeCommandHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Retrieve domain entity object
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
        
        if (leaveTypeToDelete is null)
            throw new NotFoundException(nameof(leaveTypeToDelete), request.Id);
        
        // Validate that record exists
        var validator = new DeleteLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in delete request for {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid Leave Type", validationResult);
        }

        // remove from database
        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        // Return record id
        return Unit.Value;
    }
}