using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeById;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeList;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> GetLeaveTypes()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeListQuery());

        return Ok(leaveTypes);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> CreateLeaveType(CreateLeaveTypeDto dto)
    {
        var response = await _mediator.Send(new CreateLeaveTypeCommand(dto.Name, dto.DefaultDays));

        return CreatedAtAction(nameof(GetLeaveType), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto?>> GetLeaveType([FromRoute] int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeByIdQuery(id));

        return leaveType is null ? NotFound() : Ok(leaveType);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseCommandResponse>> UpdateLeaveType(int id, [FromBody] UpdateLeaveTypeDto dto)
    {
        var response = await _mediator.Send(new UpdateLeaveTypeCommand(id, new LeaveTypeDto(id, dto.Name, dto.DefaultDays)));

        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseCommandResponse>> DeleteLeaveType(int id)
    {
        var response = await _mediator.Send(new DeleteLeaveTypeCommand(id));

        return response.Success ? Ok(response) : NotFound(response);
    }
}
