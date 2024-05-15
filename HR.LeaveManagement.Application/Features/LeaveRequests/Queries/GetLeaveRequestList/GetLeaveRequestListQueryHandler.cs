using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestList;

public class GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
{
    private readonly ILeaveRequestRepository _leaveAllocationRepository = leaveRequestRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery query, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveAllocationRepository.GetLeaveRequestsWithDetails();

        return _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
    }
}
