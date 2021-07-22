using FileProcessor.Application.Responses;

namespace FileProcessor.Application.Features.Commands.Imports
{
    public class CreateImportCommandResponse : BaseResponse
    {
        public CreateImportCommandResponse() : base()
        {

        }

        public CreateImportDto Import { get; set; }
    }
}