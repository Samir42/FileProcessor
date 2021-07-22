using FileProcessor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FileProcessor.Application.Features.Queries.GetUserImportList
{
    public class UserImportListVm
    {
        public Guid UserId { get; set; }

        public ICollection<Import> Imports { get; set; }
    }
}
