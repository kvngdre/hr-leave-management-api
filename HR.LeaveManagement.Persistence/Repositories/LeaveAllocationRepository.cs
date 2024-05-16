using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using HR.LeaveManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository(ApplicationDbContext dbContext)
    : GenericRepository<LeaveAllocation>(dbContext), ILeaveAllocationRepository
{
    private readonly ApplicationDbContext _context = dbContext;

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations.Include(l => l.LeaveType).FirstOrDefaultAsync(q => q.Id == id);
    }
}
