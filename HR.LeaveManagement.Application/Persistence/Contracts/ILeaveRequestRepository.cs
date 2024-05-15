using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<List<LeaveRequestDto>> GetLeaveRequestsWithDetails();

    Task ChangeLeaveRequestApproval(LeaveRequest leaveRequest, bool? approval);
}
