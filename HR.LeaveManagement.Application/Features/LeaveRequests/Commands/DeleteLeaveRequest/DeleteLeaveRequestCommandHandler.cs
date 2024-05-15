using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository = leaveRequestRepository;

    public async Task<Unit> Handle(DeleteLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.FindByIdAsync(command.Id);

        await _leaveRequestRepository.DeleteAsync(leaveRequest);

        return Unit.Value;
    }
}
