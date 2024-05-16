using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationListDto>>> GetLeaveAllocations()
    {
        var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListQuery());

        return Ok(leaveAllocations);
    }

    [HttpPost]
    public async Task<ActionResult<LeaveAllocationDetailsDto>> CreateLeaveAllocation(CreateLeaveAllocationDto dto)
    {
        var leaveAllocation = await _mediator.Send(new CreateLeaveAllocationCommand(dto.NumberOfDays, dto.LeaveTypeId, dto.Period));

        return CreatedAtAction(nameof(GetLeaveAllocation), new { id = leaveAllocation.Id }, leaveAllocation);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDetailsDto?>> GetLeaveAllocation(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery(id));

        return leaveAllocation is null ? NotFound() : Ok(leaveAllocation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeaveType(int id, [FromBody] UpdateLeaveAllocationDto dto)
    {
        await _mediator.Send(new UpdateLeaveAllocationCommand(id, dto.NumberOfDays, dto.LeaveTypeId, dto.Period));

        return NoContent();
    }
}
