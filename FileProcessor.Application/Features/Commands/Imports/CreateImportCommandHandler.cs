using AutoMapper;
using FileProcessor.Application.Contracts.Persistence;
using FileProcessor.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileProcessor.Application.Features.Commands.Imports
{
    public class CreateImportCommandHandler : IRequestHandler<CreateImportCommand, CreateImportCommandResponse>
    {
        private readonly IAsyncRepository<Import> _importRepository;
        private readonly IMapper _mapper;

        public CreateImportCommandHandler(IMapper mapper, IAsyncRepository<Import> importRepository)
        {
            _mapper = mapper;
            _importRepository = importRepository;
        }
        public async Task<CreateImportCommandResponse> Handle(CreateImportCommand request, CancellationToken cancellationToken)
        {
            var createImportCommandResponse = new CreateImportCommandResponse();
            var importToAdd = new Import();
            var validator = new CreateImportCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createImportCommandResponse.Success = false;
                createImportCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createImportCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            importToAdd.Success = true ? createImportCommandResponse.Success is true : false;

            if (createImportCommandResponse.Success)
            {
                var import = new Import()
                {
                    ExecutionTimeWithMilliseconds = request.ExecutionTimeWithMilliseconds,
                    ExecutedBy = request.ExecutedBy,
                    FileSize = request.FileSize
                };

                import = await _importRepository.AddAsync(import);
                createImportCommandResponse.Import = _mapper.Map<CreateImportDto>(import);
            }

            return createImportCommandResponse;
        }
    }
}
