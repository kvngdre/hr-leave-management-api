﻿using FluentValidation;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<LeaveType>
{
    public CreateLeaveTypeCommandValidator()
    {
        RuleFor(l => l.Name)
            .NotEmpty().WithMessage("(propertyName) is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("(propertyName) cannot exceed 50 characters.");

        RuleFor(l => l.DefaultDays)
        .NotEmpty().WithMessage("(propertyName) is required.")
        .GreaterThan(0).WithMessage("(propertyName) must be greater than 0.")
        .LessThanOrEqualTo(100).WithMessage("(propertyName) cannot exceed 100 days.");
    }
}
