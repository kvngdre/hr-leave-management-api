using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public sealed record CreateLeaveRequestCommand(
    DateTime StartDate,
    DateTime EndDate,
    int LeaveTypeId,
    DateTime DateRequested,
    string RequestComments) : IRequest<LeaveRequestDto>;
