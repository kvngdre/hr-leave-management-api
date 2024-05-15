namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public sealed record class CreateLeaveAllocationDto(
    int NumberOfDays,
    int LeaveTypeId,
    int Period
);