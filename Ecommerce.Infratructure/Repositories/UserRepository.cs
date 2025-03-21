﻿using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class UserRepository(ECommerceDbContext dbContext) : IUserRepository
{
    public async Task AddUser(User user, CancellationToken cancellationToken)
    {
        await dbContext.User.AddAsync(user, cancellationToken);
    }
    public async Task<List<User>> GetAllUser(CancellationToken cancellationToken)
    {
        return await dbContext.User
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.User.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
    }
    
    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return await dbContext.User.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        await dbContext.User.Where(x=>x.Id == userId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task UpdateUser(Guid userId,string email,string phoneNumber,
                                 string address, CancellationToken cancellationToken)
    {
        await dbContext.User.Where(x => x.Id == userId)
            .ExecuteUpdateAsync(x => x
            .SetProperty(p => p.Email, email)
            .SetProperty(p => p.PhoneNumber, phoneNumber)
            .SetProperty(p => p.Address, address),
            cancellationToken);
    }

    public async Task<UserRole?> GetRole(string role, CancellationToken cancellationToken)
    {
        return await dbContext.UserRoles
                        .FirstOrDefaultAsync(x => x.Name == role, cancellationToken);
    }
}
