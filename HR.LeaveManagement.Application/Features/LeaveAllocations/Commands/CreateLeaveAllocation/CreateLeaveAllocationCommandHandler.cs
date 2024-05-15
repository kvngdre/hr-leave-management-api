using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    : IRequestHandler<CreateLeaveAllocationCommand, LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository = leaveAllocationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LeaveAllocationDetailsDto> Handle(CreateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        LeaveAllocation leaveAllocation = _mapper.Map<LeaveAllocation>(command);

        leaveAllocation = await _leaveAllocationRepository.InsertAsync(leaveAllocation);

        return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
    }
}
