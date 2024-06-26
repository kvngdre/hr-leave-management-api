﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestList;

public record class GetLeaveRequestListQuery() : IRequest<List<LeaveRequestListDto>>;
