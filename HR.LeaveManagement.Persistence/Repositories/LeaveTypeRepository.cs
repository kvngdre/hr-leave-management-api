using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using HR.LeaveManagement.Persistence.Data;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository(ApplicationDbContext dbContext) : GenericRepository<LeaveType>(dbContext), ILeaveTypeRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<bool> DoesExistsAsync(int id)
    {
        var leaveType = await FindByIdAsync(id);

        return leaveType != null;
    }
}
