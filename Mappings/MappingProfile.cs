using AutoMapper;
using GasStationApi.Models;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Customer
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<AddUpdateCustomerDTO, Customer>();

        // Cylinder
        CreateMap<Cylinder, CylinderDTO>().ReverseMap();
        CreateMap<AddUpdateCylinderDTO, Cylinder>();

        // Inventory
        CreateMap<Inventory, InventoryDTO>()
            .ForMember(dest => dest.CylinderType, opt => opt.MapFrom(src => src.Cylinder.Type)) // <-- maps Cylinder.Type
            .ReverseMap();
        CreateMap<AddUpdateInventory, Inventory>().ReverseMap();

        // Transaction
        CreateMap<Transaction, TransactionDTO>().ReverseMap();
        CreateMap<AddTransactionDTO, Transaction>();
    }
}
