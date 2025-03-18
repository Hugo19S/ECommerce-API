using AutoMapper;
using Ecommerce.Application.Makers.Commands.CreateMaker;
using Ecommerce.Application.Makers.Commands.DeleteMaker;
using Ecommerce.Application.Makers.Commands.UpdateMaker;
using Ecommerce.Application.Makers.Queries.GetMaker;
using Ecommerce.Application.Makers.Queries.GetMakers;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers
{
    [Route("/api/[controller]")]
    public class MakerController(ISender sender, IMapper mapper) : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> GetMakers(CancellationToken cancellationToken)
        {
            var makersOr = await sender.Send(new GetMakersQuery(), cancellationToken);

            return makersOr.Match(v => Ok(mapper.Map<List<GetMakerResponse>>(v)), Problem);
        }

        [HttpGet("{makerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetMakers(Guid makerId, CancellationToken cancellationToken)
        {
            var makersOr = await sender.Send(new GetMakerQuery(makerId), cancellationToken);

            return makersOr.Match(v => Ok(mapper.Map<GetMakerResponse>(v)), Problem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateMaker([FromBody] CreateMakerRequest makerRequest, CancellationToken cancellationToken)
        {
            var makerCreatedOr = await sender.Send(new CreateMakerCommand(makerRequest.Name),
                                                   cancellationToken);

            return makerCreatedOr.Match(v => Created("", v), Problem);
        }

        [HttpDelete("{makerId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMaker(Guid makerId, CancellationToken cancellationToken)
        {
            var makerDeletedOr = await sender.Send(new DeleteMakerCommand(makerId), cancellationToken);
            return makerDeletedOr.Match(v => NoContent(), Problem);
        }

        [HttpPut("{makerId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateMaker(Guid makerId,
                                                    [FromBody] UpdateMakerRequest makerRequest,
                                                    CancellationToken cancellationToken)
        {
            var makerDeletedOr = await sender.Send(new UpdateMakerCommand(makerId, 
                                                                          makerRequest.Name),
                                                                          cancellationToken);

            return makerDeletedOr.Match(v => NoContent(), Problem);
        }
    }
}
