using HR.LeaveManagement.Domain.Primitives;

namespace HR.LeaveManagement.Domain.Entities;

public class LeaveType : DomainEntity
{
    public required string Name { get; set; }

    public int DefaultDays { get; set; }
}
