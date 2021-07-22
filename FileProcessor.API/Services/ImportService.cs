using FileProcessor.Application.Contracts;
using FileProcessor.Application.Features.Queries.GetUserImportList;
using FileProcessor.Application.Models.Import;
using System.Linq;

namespace FileProcessor.API.Services
{
    public class ImportService : IImportService
    {
        public ImportDetail GetImportDetails(UserImportListVm userImportList)
        {
            var averageFileSize = userImportList.Imports.Select(x => x.FileSize).DefaultIfEmpty(0).Average();
            var averageExecutionTime = userImportList.Imports.Select(x => x.ExecutionTimeWithMilliseconds).DefaultIfEmpty(0).Average();
            var failCount = userImportList.Imports.Where(x => x.Success is false).ToList().Count;

            var importDetailToReturn = new ImportDetail()
            {
                AverageExecutionTime = averageExecutionTime,
                AverageFileSize = averageFileSize,
                FailCount = failCount
            };

            return importDetailToReturn;
        }
    }
}
