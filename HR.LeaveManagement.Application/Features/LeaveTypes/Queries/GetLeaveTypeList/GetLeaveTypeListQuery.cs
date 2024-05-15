using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeList;

public record class GetLeaveTypeListQuery() : IRequest<List<LeaveTypeDto>>;