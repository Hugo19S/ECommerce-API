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

        public async Task<ActionResult> GetMakers(CancellationToken cancellationToken)
        {
            var makersOr = await sender.Send(new GetMakersQuery(), cancellationToken);

            return makersOr.Match(v => Ok(mapper.Map<List<GetMakerResponse>>(v)), Problem);
        }

        [HttpGet("{makerId:guid}")]
        public async Task<ActionResult> GetMakers(Guid makerId, CancellationToken cancellationToken)
        {
            var makersOr = await sender.Send(new GetMakerQuery(makerId), cancellationToken);

            return makersOr.Match(v => Ok(mapper.Map<GetMakerResponse>(v)), Problem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaker([FromBody] CreateMakerRequest makerRequest, CancellationToken cancellationToken)
        {
            var makerCreatedOr = await sender.Send(new CreateMakerCommand(makerRequest.Name),
                                                   cancellationToken);

            return makerCreatedOr.Match(v => Ok(v), Problem);
        }

        [HttpDelete("{makerId:guid}")]
        public async Task<ActionResult> DeleteMaker(Guid makerId, CancellationToken cancellationToken)
        {
            var makerDeletedOr = await sender.Send(new DeleteMakerCommand(makerId), cancellationToken);

            return makerDeletedOr.Match(v => Ok(v), Problem);
        }

        [HttpPut("{makerId:guid}")]
        public async Task<ActionResult> UpdateMaker(Guid makerId,
                                                    [FromBody] UpdateMakerRequest makerRequest,
                                                    CancellationToken cancellationToken)
        {
            var makerDeletedOr = await sender.Send(new UpdateMakerCommand(makerId, makerRequest.Name), cancellationToken);

            return makerDeletedOr.Match(v => Ok(v), Problem);
        }
    }
}
