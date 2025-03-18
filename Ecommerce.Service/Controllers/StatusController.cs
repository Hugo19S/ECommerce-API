using Ecommerce.Application.Statuses.Commands.CreateStatus;
using Ecommerce.Application.Statuses.Commands.DeleteStatus;
using Ecommerce.Application.Statuses.Commands.PatchStatus;
using Ecommerce.Application.Statuses.Commands.UpdateStatus;
using Ecommerce.Application.Statuses.Queries.GetStatus;
using Ecommerce.Application.Statuses.Queries.GetStatuses;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class StatusController(ISender sender ) : ApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetStatuses(CancellationToken cancellationToken)
    {
        var statusListOr = await sender.Send(new GetStatusesQuery(), cancellationToken);
        return statusListOr.Match(Ok, Problem);
    }
    
    [HttpGet("{statusId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetStatus(Guid statusId, CancellationToken cancellationToken)
    {
        var status = await sender.Send(new GetStatusQuery(statusId), cancellationToken);

        return status.Match(Ok, Problem);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateStatus([FromBody] CreateStatusRequest statusRequest,
                                           CancellationToken cancellationToken)
    {
        var createdStatusOr = await sender.Send(new CreateStatusCommand(statusRequest.Name,
                                                                        statusRequest.Type,
                                                                        statusRequest.Description), cancellationToken);
        return createdStatusOr.Match( v => Created("", v), Problem);
    }
    
    [HttpDelete("{statusId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteStatus(Guid statusId, CancellationToken cancellationToken)
    {
        var statusDeletedOr = await sender.Send( new DeleteStatusCommand(statusId), cancellationToken);
        return statusDeletedOr.Match( v => NoContent(), Problem);
    }

    [HttpPut("{statusId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateStatus(Guid statusId,
                                           [FromBody] UpdateStatusRequest statusRequest,
                                           CancellationToken cancellationToken)
    {
        var statusUpdatedOr = await sender.Send(new UpdateStatusCommand(statusId,
                                                                  statusRequest.Name,
                                                                  statusRequest.Type,
                                                                  statusRequest.Description), 
                                                                  cancellationToken);
        return statusUpdatedOr.Match( v => NoContent(), Problem);
    }

    [HttpPatch("{statusId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> PatchStatus(Guid statusId,
                                                [FromBody] JsonPatchDocument<Status> jsonPatch,
                                                CancellationToken cancellationToken)
    {
        var status = await sender.Send( new PatchStatusCommand(statusId, jsonPatch), cancellationToken);
        return status.Match(v => NoContent(), Problem);
    }
}
