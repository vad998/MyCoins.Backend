using AutoMapper;
using MyCoins.Application.Entities.Transactions.Queries.GetTransationDetails;
using MyCoins.Domain.Entities;

namespace MyCoins.Application.MappingProfiles
{
    public class TransationToTransationDetailsVmMappingProfile : Profile
    {
        public TransationToTransationDetailsVmMappingProfile()
        {
            CreateMap<Transaction, TransationDetailsVm>()
                .ForMember(tdv => tdv.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(tdv => tdv.Amount, opt => opt.MapFrom(t => t.Amount))
                .ForMember(tdv => tdv.CreationDate, opt => opt.MapFrom(t => t.CreationDate))
                .ForMember(tdv => tdv.Description, opt => opt.MapFrom(t => t.Description))
                .ForMember(tdv => tdv.FromId, opt => opt.MapFrom(t => t.FromId))
                .ForMember(tdv => tdv.ToId, opt => opt.MapFrom(t => t.ToId));
        }
    }
}
