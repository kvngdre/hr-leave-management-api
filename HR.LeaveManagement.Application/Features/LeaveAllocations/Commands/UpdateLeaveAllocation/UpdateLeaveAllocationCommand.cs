using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.UpdateLeaveAllocation;

public record class UpdateLeaveAllocationCommand(
    int Id,
    int NumberOfDays,
    int LeaveTypeId,
    int Period) : IRequest<Unit>;
