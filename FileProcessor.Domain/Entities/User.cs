using FileProcessor.Domain.Common;
using System;
using System.Collections.Generic;

namespace FileProcessor.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Import> Imports { get; set; }
    }
}
