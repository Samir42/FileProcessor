using FileProcessor.Domain.Common;
using System;

namespace FileProcessor.Domain.Entities
{
    public class Import : AuditableEntity
    {
        public Guid Id { get; set; }

        public string ExecutedBy { get; set; }

        public long FileSize { get; set; }

        public DateTime ExecutedAt { get; set; }

        public long ExecutionTimeWithMilliseconds { get; set; }

        public bool Success { get; set; }
    }
}
