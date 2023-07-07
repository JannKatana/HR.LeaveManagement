﻿using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
}