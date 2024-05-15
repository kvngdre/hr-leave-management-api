using HR.LeaveManagement.Application.DTOs.LeaveTypes;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public record class LeaveRequestDto(
    string Id,
    DateTime StartDate,
    DateTime EndDate,
    LeaveTypeDto LeaveType,
    int LeaveTypeId,
    string RequestingEmployeeId,
    DateTime DateRequested,
    string RequestComments,
    DateTime? DateActioned,
    bool? Approved,
    bool Cancelled);
