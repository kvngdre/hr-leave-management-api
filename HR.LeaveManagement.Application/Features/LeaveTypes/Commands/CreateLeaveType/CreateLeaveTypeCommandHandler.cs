using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<CreateLeaveTypeCommand, LeaveTypeDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LeaveTypeDto> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        LeaveType leaveType = _mapper.Map<LeaveType>(command);

        leaveType = await _leaveTypeRepository.InsertAsync(leaveType);

        return _mapper.Map<LeaveTypeDto>(leaveType);
    }
}
