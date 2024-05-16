using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetails;
using HR.LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestListDto>>> GetLeaveRequests()
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestListQuery());

        return Ok(leaveRequests);
    }

    [HttpPost]
    public async Task<ActionResult<LeaveRequestDto>> CreateLeaveRequest(CreateLeaveRequestDto dto)
    {
        var leaveRequest = await _mediator.Send(new CreateLeaveRequestCommand(dto.StartDate, dto.EndDate, dto.LeaveTypeId, dto.DateRequested, dto.RequestComments));

        return CreatedAtAction(nameof(GetLeaveRequest), new { id = leaveRequest.Id }, leaveRequest);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto?>> GetLeaveRequest(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsQuery(id));

        return leaveRequest is null ? NotFound() : Ok(leaveRequest);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeaveType(int id, [FromBody] UpdateLeaveRequestDto dto)
    {
        await _mediator.Send(new UpdateLeaveRequestCommand(id, dto.StartDate, dto.EndDate, dto.LeaveTypeId, dto.RequestComments, null));

        return NoContent();
    }
}
