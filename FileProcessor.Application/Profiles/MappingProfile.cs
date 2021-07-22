using AutoMapper;
using FileProcessor.Application.Features.Commands.Imports;
using FileProcessor.Application.Features.Queries.GetUserImportList;
using FileProcessor.Domain.Entities;

namespace FileProcessor.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Import, CreateImportDto>().ReverseMap();


            CreateMap<User, UserImportListVm>().ReverseMap();
        }
    }
}
