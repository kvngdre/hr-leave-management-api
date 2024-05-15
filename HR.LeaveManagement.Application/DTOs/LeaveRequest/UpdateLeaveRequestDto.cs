namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public record class UpdateLeaveRequestDto
(
    int Id,
    DateTime StartDate,
    DateTime EndDate,
    int LeaveTypeId,
    string RequestComments);