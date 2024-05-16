using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler(
    ILeaveRequestRepository leaveRequestRepository,
    IMapper mapper,
    IEmailSender emailSender) : IRequestHandler<CreateLeaveRequestCommand, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository = leaveRequestRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IEmailSender _emailSender = emailSender;

    public async Task<LeaveRequestDto> Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(command);

        leaveRequest = await _leaveRequestRepository.InsertAsync(leaveRequest);

        await _emailSender.SendEmailAsync(new Email(
            "ludson@gmail.com",
            "Leave Request Logged",
            // The colon D (:D) is string-date formatting the date. Normally, you would use .ToString method and then format there,
            // but since it is a string interpolation, we can do that.
            $"Your leave request for {command.StartDate:D} has been logged successfully."
        ));

        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}
