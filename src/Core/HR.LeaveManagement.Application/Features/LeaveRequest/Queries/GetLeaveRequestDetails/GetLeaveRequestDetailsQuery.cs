using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public record GetLeaveRequestDetailsQuery(int id) : IRequest<LeaveRequestDetailsDto>;