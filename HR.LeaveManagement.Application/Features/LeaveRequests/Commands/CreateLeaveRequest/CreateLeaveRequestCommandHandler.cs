using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    : IRequestHandler<CreateLeaveRequestCommand, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository = leaveRequestRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LeaveRequestDto> Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(command);

        leaveRequest = await _leaveRequestRepository.InsertAsync(leaveRequest);

        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}
