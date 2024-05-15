using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeList;

public class GetLeaveTypeListQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<GetLeaveTypeListQuery, List<LeaveTypeDto>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListQuery query, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.FindAllAsync();

        return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
    }
}
