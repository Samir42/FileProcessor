using System;

namespace FileProcessor.Application.Features.Commands.Imports
{
    public class CreateImportDto
    {
        public Guid Id { get; set; }

        public string ExecutedBy { get; set; }

        public long FileSize { get; set; }
    }
}