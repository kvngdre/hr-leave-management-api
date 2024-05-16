using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> DoesExistsAsync(int id);
}
