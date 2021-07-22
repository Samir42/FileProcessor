using FileProcessor.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileProcessor.Identity
{
    public class FileProcessorIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public FileProcessorIdentityDbContext(DbContextOptions<FileProcessorIdentityDbContext> options) : base(options)
        {
        }
    }
}
