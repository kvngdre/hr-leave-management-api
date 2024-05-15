using HR.LeaveManagement.Domain.Primitives;

namespace HR.LeaveManagement.Domain.Entities;

public class LeaveAllocation : DomainEntity
{
    public int NumberOfDays { get; set; }

    public LeaveType LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public int Period { get; set; }

    public string EmployeeId { get; set; }
}
