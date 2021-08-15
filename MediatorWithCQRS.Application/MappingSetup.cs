using AutoMapper;
using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.Results;
using MediatorWithCQRS.Domain.Entities;
using System.Collections.Generic;

namespace MediatorWithCQRS.Application
{
    public class MappingSetup : Profile
    {
        public MappingSetup()
        {
            CreateMap<Product, FindProductQueryResult>();
            CreateMap<Product[], IEnumerable<FindProductQueryResult>>();

            CreateMap<CreateProductCommand, Product>();
        }
    }
}
