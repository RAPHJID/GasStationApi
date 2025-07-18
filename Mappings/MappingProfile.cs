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
        CreateMap<Transaction, TransactionDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
            .ForMember(dest => dest.CylinderType, opt => opt.MapFrom(src => src.Cylinder.Type))
            .ForMember(dest => dest.CylinderBrand, opt => opt.MapFrom(src => src.Cylinder.Brand));

        CreateMap<AddTransactionDTO, Transaction>();
    }
}
