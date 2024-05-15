using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeById;

public class GetLeaveTypeByIdQueryHandler(ILeaveTypeRepository leaveRequestRepository, IMapper mapper)
    : IRequestHandler<GetLeaveTypeByIdQuery, LeaveTypeDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveRequestRepository;

    public async Task<LeaveTypeDto> Handle(GetLeaveTypeByIdQuery query, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.FindByIdAsync(query.Id);

        return _mapper.Map<LeaveTypeDto>(leaveType);
    }
}
