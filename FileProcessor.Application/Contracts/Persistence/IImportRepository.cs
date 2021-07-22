using FileProcessor.Domain.Entities;

namespace FileProcessor.Application.Contracts.Persistence
{
    public interface IImportRepository : IAsyncRepository<Import>
    {
    }
}
