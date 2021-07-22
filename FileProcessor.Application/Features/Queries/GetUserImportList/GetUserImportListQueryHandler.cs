using AutoMapper;
using FileProcessor.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FileProcessor.Application.Features.Queries.GetUserImportList
{
    public class GetUserImportListQueryHandler : IRequestHandler<GetUserImportListQuery, UserImportListVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserImportListQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserImportListVm> Handle(GetUserImportListQuery request, CancellationToken cancellationToken)
        {
            var userToReturn = await _userRepository.GetUserWithImports(request.UserId);

            return _mapper.Map<UserImportListVm>(userToReturn);
        }
    }
}
