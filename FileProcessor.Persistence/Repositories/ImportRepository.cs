using FileProcessor.Application.Contracts.Persistence;
using FileProcessor.Domain.Entities;

namespace FileProcessor.Persistence.Repositories
{
    public class ImportRepository : BaseRepository<Import>, IImportRepository
    {
        public ImportRepository(FileProcessorDbContext dbContext) : base(dbContext)
        {
        }
    }
}
