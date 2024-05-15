using HR.LeaveManagement.Application.DTOs.LeaveTypes;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public record class LeaveRequestListDto(DateTime DateRequested, bool? Approved, LeaveTypeDto LeaveType);
