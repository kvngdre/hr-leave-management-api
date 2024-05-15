namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public record class CreateLeaveRequestDto(
    DateTime StartDate,
    DateTime EndDate,
    int LeaveTypeId,
    string RequestComments
);