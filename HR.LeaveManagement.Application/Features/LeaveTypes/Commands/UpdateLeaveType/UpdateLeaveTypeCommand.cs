using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

public record class UpdateLeaveTypeCommand(int Id, LeaveTypeDto LeaveType) : IRequest<Unit>;
