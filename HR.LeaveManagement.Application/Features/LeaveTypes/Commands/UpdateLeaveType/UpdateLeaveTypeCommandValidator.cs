using FluentValidation;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

namespace HR.LeaveManagement.Application;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    public UpdateLeaveTypeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .NotNull();
    }
}
