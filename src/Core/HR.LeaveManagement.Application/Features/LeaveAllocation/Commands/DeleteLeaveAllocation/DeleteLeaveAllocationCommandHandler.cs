﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        if (leaveAllocation is null)
        {
            throw new NotFoundException(nameof(leaveAllocation), request.Id);
        }

        // remove from database
        await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

        // Return record id
        return Unit.Value;
    }
}