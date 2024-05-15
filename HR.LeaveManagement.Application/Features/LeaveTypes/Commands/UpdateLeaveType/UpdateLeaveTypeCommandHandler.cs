using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IMapper _mapper = mapper;


    public async Task<Unit> Handle(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        LeaveType leaveType = await _leaveTypeRepository.FindByIdAsync(command.Id);

        _mapper.Map(command.LeaveType, leaveType);

        await _leaveTypeRepository.UpdateAsync(leaveType);

        return Unit.Value;
    }
}
