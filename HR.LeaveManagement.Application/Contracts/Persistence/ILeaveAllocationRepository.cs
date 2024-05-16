using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails(int id);
    Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id);
}
