namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public record class UpdateLeaveAllocationDto(
    int Id,
    int NumberOfDays,
    int LeaveTypeId,
    int Period);
