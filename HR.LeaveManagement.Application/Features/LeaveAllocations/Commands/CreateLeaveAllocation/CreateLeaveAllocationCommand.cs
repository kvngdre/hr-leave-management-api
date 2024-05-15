using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.CreateLeaveAllocation;

public record class CreateLeaveAllocationCommand(
    int NumberOfDays,
    int LeaveTypeId,
    int Period) : IRequest<LeaveAllocationDetailsDto>;
