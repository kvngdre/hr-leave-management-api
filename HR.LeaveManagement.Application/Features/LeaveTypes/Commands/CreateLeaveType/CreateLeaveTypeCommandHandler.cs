using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain.Entities;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveTypeCommandValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Failed to create leave type.";
            response.Errors = new ValidationException(validationResult).Errors;

            return response;
        }

        LeaveType leaveType = _mapper.Map<LeaveType>(command);

        leaveType = await _leaveTypeRepository.InsertAsync(leaveType);

        response.Message = "Created leave type.";
        response.Id = leaveType.Id;

        return response;
    }
}
