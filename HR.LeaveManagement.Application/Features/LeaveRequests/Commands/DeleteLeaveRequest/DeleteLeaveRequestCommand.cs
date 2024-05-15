using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;

public record class DeleteLeaveRequestCommand(int Id) : IRequest;