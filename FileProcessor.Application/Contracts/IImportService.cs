using FileProcessor.Application.Features.Queries.GetUserImportList;
using FileProcessor.Application.Models.Import;

namespace FileProcessor.Application.Contracts
{
    public interface IImportService
    {
        ImportDetail GetImportDetails(UserImportListVm userImportList);
    }
}
