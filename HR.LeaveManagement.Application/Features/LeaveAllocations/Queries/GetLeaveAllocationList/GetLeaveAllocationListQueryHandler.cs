using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationList;

public class GetLeaveAllocationListQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationListDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository = leaveAllocationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<LeaveAllocationListDto>> Handle(GetLeaveAllocationListQuery query, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.FindAllAsync();

        return _mapper.Map<List<LeaveAllocationListDto>>(leaveAllocations);
    }
}
