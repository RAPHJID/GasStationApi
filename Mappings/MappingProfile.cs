using AutoMapper;
using GasStationApi.Models;
using GasStationApi.Models.DTOs;

namespace GasStationApi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Customer
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();

        // Cylinder
        CreateMap<Cylinder, CylinderDto>().ReverseMap();
        CreateMap<CreateCylinderDto, Cylinder>();
        CreateMap<UpdateCylinderDto, Cylinder>();

        // Inventory
        CreateMap<Inventory, InventoryDto>().ReverseMap();

        // Transaction
        CreateMap<Transaction, TransactionDto>().ReverseMap();
        CreateMap<CreateTransactionDto, Transaction>();
    }
}
