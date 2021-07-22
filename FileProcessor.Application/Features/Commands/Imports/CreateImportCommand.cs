using MediatR;

namespace FileProcessor.Application.Features.Commands.Imports
{
    public class CreateImportCommand : IRequest<CreateImportCommandResponse>
    {
        public string ExecutedBy { get; set; }
        public long FileSize { get; set; }
        public long ExecutionTimeWithMilliseconds { get; set; }
    }
}
