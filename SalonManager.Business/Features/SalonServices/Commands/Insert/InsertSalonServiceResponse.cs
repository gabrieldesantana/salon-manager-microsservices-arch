﻿using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Features.SalonServices.Commands.Insert
{
    public class InsertSalonServiceResponse
    {
        public InsertSalonServiceResponse(Guid id, Guid tenantId, string name, string category, double price)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            Category = category;
            Price = price;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public double Price { get; private set; }

        public static implicit operator InsertSalonServiceResponse(SalonService salonService)
        => new(
            salonService.Id,
            salonService.TenantId,
            salonService.Name,
            salonService.Category,
            salonService.Price
            );
    }
}
