using HR.LeaveManagement.Application.DTOs.LeaveTypes;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public record class LeaveAllocationDetailsDto
{
    public int Id { get; init; }
    public int NumberOfDays { get; init; }
    public LeaveTypeDto LeaveType { get; init; }
    public int LeaveTypeId { get; init; }
    public string EmployeeId { get; init; }
    public int Period { get; init; }
}
