using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
    Task<LeaveRequest?> GetLeaveRequestWithDetails(int id);

    Task ChangeLeaveRequestApproval(LeaveRequest leaveRequest, bool? approval);
}
