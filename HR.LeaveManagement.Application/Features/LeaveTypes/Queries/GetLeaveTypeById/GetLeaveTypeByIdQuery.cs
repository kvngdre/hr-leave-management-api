using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeById;

public record class GetLeaveTypeByIdQuery(int Id) : IRequest<LeaveTypeDto>;
