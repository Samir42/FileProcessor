using FileProcessor.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace FileProcessor.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserWithImports(Guid userId)
    }
}
