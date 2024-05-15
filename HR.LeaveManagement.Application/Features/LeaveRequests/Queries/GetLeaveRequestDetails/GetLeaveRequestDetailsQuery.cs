using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetails;

public record class GetLeaveRequestDetailsQuery(int Id) : IRequest<LeaveRequestDto>;