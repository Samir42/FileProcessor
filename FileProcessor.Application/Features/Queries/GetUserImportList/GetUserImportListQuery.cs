using MediatR;
using System;

namespace FileProcessor.Application.Features.Queries.GetUserImportList
{
    public class GetUserImportListQuery : IRequest<UserImportListVm>
    {
        public Guid UserId { get; set; }
    }
}
