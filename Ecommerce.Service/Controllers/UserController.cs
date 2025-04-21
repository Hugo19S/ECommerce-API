using AutoMapper;
using Ecommerce.Application.Users.Commands.CreateUser;
using Ecommerce.Application.Users.Commands.DeleteUser;
using Ecommerce.Application.Users.Commands.UpdateUser;
using Ecommerce.Application.Users.Queries.GetUser;
using Ecommerce.Application.Users.Queries.GetUsers;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class UserController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUser,
                                               CancellationToken cancellationToken) 
    {
        var userOr = await sender.Send(new CreateUserCommand(createUser.FirstName,
                                                        createUser.LastName,
                                                        createUser.Email,
                                                        createUser.Password,
                                                        createUser.PhoneNumber,
                                                        createUser.Address), 
                                                        cancellationToken);

        return userOr.Match(v => Created("", v), Problem);
    }
    
    [HttpGet("{userId:guid}")]
    [Authorize(Roles = "Costumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUser(Guid userId, CancellationToken cancellationToken) 
    {
        var userOr = await sender.Send(new GetUserQuery(userId), cancellationToken);

        return userOr.Match(
            v => Ok(mapper.Map<UserResponse>(v)), Problem);
    }
    
    [HttpGet]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetUsers(CancellationToken cancellationToken) 
    {
        var users = await sender.Send(new GetUsersQuery(), cancellationToken);
        return users.Match(
            v => Ok(mapper.Map<List<UserResponse>>(v)), Problem);

    }

    [HttpPut("{userId}")]
    [Authorize(Roles = "Costumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserRequest updateUser,
                                               CancellationToken cancellationToken)
    {
        var userUpdatedOr = await sender.Send(new UpdateUserCommand(userId,
                                                                    updateUser.FirstName,
                                                                    updateUser.LastName,
                                                                    updateUser.Email,
                                                                    updateUser.PhoneNumber,
                                                                    updateUser.Address), cancellationToken);


        return userUpdatedOr.Match(v => NoContent(), Problem);
    }
    
    [HttpDelete("{userId:guid}")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        var deletedUserOr = await sender.Send(new DeleteUserCommand(userId), cancellationToken);

        return deletedUserOr.Match(v => NoContent(), Problem);
    }
}
