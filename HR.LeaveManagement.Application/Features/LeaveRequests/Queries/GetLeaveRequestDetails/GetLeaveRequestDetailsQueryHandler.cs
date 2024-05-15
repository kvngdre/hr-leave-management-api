using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository = leaveRequestRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailsQuery query, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.FindByIdAsync(query.Id);

        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}
