using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

public record class UpdateLeaveRequestCommand(
    int Id,
    DateTime StartDate,
    DateTime EndDate,
    int LeaveTypeId,
    string RequestComments,
    ChangeLeaveRequestApprovalDto ChangeLeaveRequestApproval) : IRequest<Unit>;