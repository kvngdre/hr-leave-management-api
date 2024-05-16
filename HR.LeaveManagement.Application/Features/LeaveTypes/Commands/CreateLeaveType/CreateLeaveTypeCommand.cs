using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public record class CreateLeaveTypeCommand(string Name, int DefaultDays) : IRequest<BaseCommandResponse>;
