using AutoMapper;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository = leaveRequestRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(UpdateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        LeaveRequest leaveRequest = await _leaveRequestRepository.FindByIdAsync(command.Id);

        if (command.ChangeLeaveRequestApproval is null)
        {
            _mapper.Map(command, leaveRequest);

            await _leaveRequestRepository.UpdateAsync(leaveRequest);
        }
        else
        {
            await _leaveRequestRepository.ChangeLeaveRequestApproval(leaveRequest, command.ChangeLeaveRequestApproval.Approved);
        }

        return Unit.Value;
    }
}
