using AutoMapper;
using Ecommerce.Application.Users.Commands.AddUser;
using Ecommerce.Application.Users.Commands.DeleteUser;
using Ecommerce.Application.Users.Commands.UpdateUser;
using Ecommerce.Application.Users.Queries.GetUser;
using Ecommerce.Application.Users.Queries.GetUsers;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class UserController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUser,
                                            CancellationToken cancellationToken) 
    {
        var userOr = await sender.Send(new AddUserCommand(createUser.FirstName,
                                                        createUser.LastName,
                                                        createUser.Email,
                                                        createUser.Password,
                                                        createUser.PhoneNumber,
                                                        createUser.Address,
                                                        createUser.Role), cancellationToken);

        return userOr.Match(
            v => Created("", v), 
            Problem);
    }
    
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult> GetUser(Guid userId, CancellationToken cancellationToken) 
    {
        var userOr = await sender.Send(new GetUserQuery(userId), cancellationToken);

        return userOr.Match(
            v => Ok(mapper.Map<UserResponse>(v)), 
            Problem);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetUsers(CancellationToken cancellationToken) 
    {
        var users = await sender.Send(new GetUsersQuery(), cancellationToken);
        return users.Match(
            Ok,
            Problem);

    }

    [HttpPut("{userId}")]
    public async Task<ActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserRequest updateUser,
                                               CancellationToken cancellationToken)
    {
        var userUpdatedOr = await sender.Send(new UpdateUserCommand(userId,
                                                                    updateUser.Email,
                                                                    updateUser.PhoneNumber,
                                                                    updateUser.Address), cancellationToken);

        return userUpdatedOr.Match(
                v => Ok(v),
                Problem);
    }
    
    [HttpDelete("{userId:guid}")]
    public async Task<ActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        var deletedUserOr = await sender.Send(new DeleteUserCommand(userId), cancellationToken);

        return deletedUserOr.Match(
            v => Ok(v),
            Problem);
    }
}
