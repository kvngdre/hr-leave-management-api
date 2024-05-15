using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationList;

public record class GetLeaveAllocationListQuery() : IRequest<List<LeaveAllocationListDto>>;
