using FileProcessor.Application.Contracts.Persistence;
using FileProcessor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileProcessor.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FileProcessorDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserWithImports(Guid userId)
        {
            var userAndImports = await _dbContext.Users.Include(x => x.Imports).Where(x => x.Id == userId).FirstOrDefaultAsync();

            return userAndImports;
        }
    }
}
