using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(l => l.StartDate)
            .NotEmpty()
            .LessThan(d => d.EndDate).WithMessage("{propertyName} must be before {comparisonValue}.");

        RuleFor(l => l.EndDate)
        .NotEmpty()
        .GreaterThan(d => d.StartDate).WithMessage("{propertyName} must be after {comparisonValue}.");

        RuleFor(l => l.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.DoesExistsAsync(id);

                return leaveTypeExists;
            }).WithMessage("{propertyName} does not exist.");
    }
}
