using AutoMapper;
using MyCoins.Application.Entities.Transactions.Queries.GetTransationList;
using MyCoins.Domain.Entities;

namespace MyCoins.Application.MappingProfiles
{
    public class TransationToTransationDtoMappingProfile : Profile
    {
        public TransationToTransationDtoMappingProfile()
        {
            CreateMap<Transaction, TransationDto>()
                .ForMember(tdto => tdto.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(tdto => tdto.Amount, opt => opt.MapFrom(t => t.Amount))
                .ForMember(tdto => tdto.CreationDate, opt => opt.MapFrom(t => t.CreationDate))
                .ForMember(tdto => tdto.Description, opt => opt.MapFrom(t => t.Description))
                .ForMember(tdto => tdto.FromId, opt => opt.MapFrom(t => t.FromId))
                .ForMember(tdto => tdto.ToId, opt => opt.MapFrom(t => t.ToId));
        }
    }
}
