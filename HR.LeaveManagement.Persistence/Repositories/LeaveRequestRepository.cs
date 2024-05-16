using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using HR.LeaveManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository(ApplicationDbContext dbContext)
    : GenericRepository<LeaveRequest>(dbContext), ILeaveRequestRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task ChangeLeaveRequestApproval(LeaveRequest leaveRequest, bool? approval)
    {
        leaveRequest.Approved = approval;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        return await _dbContext.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
    }

    public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
    {
        return await _dbContext.LeaveRequests
            .Include(l => l.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
