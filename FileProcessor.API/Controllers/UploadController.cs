using FileProcessor.Application.Contracts;
using FileProcessor.Application.Features.Commands.Imports;
using FileProcessor.Application.Features.Queries.GetUserImportList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FileProcessor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IUploadService _uploadService;
        private readonly IImportService _importService;

        public UploadController(IMediator mediator, ILoggedInUserService loggedInUserService, IUploadService uploadService, IImportService importService)
        {
            _mediator = mediator;
            _loggedInUserService = loggedInUserService;
            _uploadService = uploadService;
            _importService = importService;
        }


        [HttpPost("import")]
        public async Task<IActionResult> Upload(IFormFile textFile)
        {
            if (textFile is null)
            {
                return BadRequest("textFile");
            }


            var ms = new System.IO.MemoryStream();
            await textFile.CopyToAsync(ms);
            var textFileContent = ms.ToArray();

            (var processedTextToReturn, var elapsedMilliSeconds) = _uploadService.Upload(textFileContent);


            var createImportCommandResponseToReturn = await _mediator.Send(new CreateImportCommand()
            {
                ExecutedBy = _loggedInUserService.UserId,
                ExecutionTimeWithMilliseconds = elapsedMilliSeconds,
                FileSize = textFileContent.Length
            });

            if (!createImportCommandResponseToReturn.Success)
            {
                return BadRequest(createImportCommandResponseToReturn);
            }

            return Ok(processedTextToReturn);
        }

        [HttpGet("/details/{userId}")]
        public async Task<IActionResult> GetImportDetailsByUserId(Guid userId)
        {
            var getUserImportListQuery = new GetUserImportListQuery() { UserId = userId };

            var getUserImportListQueryHandlerResult = await _mediator.Send(getUserImportListQuery);

            var importResult = _importService.GetImportDetails(getUserImportListQueryHandlerResult);

            return Ok(importResult);
        }
    }
}
