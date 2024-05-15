using HR.LeaveManagement.Application.DTOs.LeaveTypes;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public record class LeaveAllocationListDto
{
    public int NumberOfDays { get; init; }
    public LeaveTypeDto LeaveType { get; init; }
};
