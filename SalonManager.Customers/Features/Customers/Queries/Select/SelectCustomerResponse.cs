using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.CrossCutting.Dtos;

namespace SalonManager.Customers.Features.Customers.Queries.Select
{
    public class SelectCustomerResponse
    {
        public SelectCustomerResponse(Guid id, Guid tenantId, Guid userId,
            string? cpf, string? name, string? nickname,
            string? gender, DateTime birthDate, string? phoneNumber,
            string? lastServiceName, DateTime lastServiceDate, int timesVisited,
            List<AppointmentDto>? appointments)
        {
            Id = id;
            TenantId = tenantId;
            UserId = userId;
            Cpf = cpf;
            Name = name;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            LastServiceName = lastServiceName;
            LastServiceDate = lastServiceDate;
            TimesVisited = timesVisited;
            Appointments = appointments;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid UserId { get; private set; }

        public string? Cpf { get; private set; }
        public string? Name { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public string? LastServiceName { get; private set; }
        public DateTime LastServiceDate { get; private set; }
        public int TimesVisited { get; private set; }
        public List<AppointmentDto>? Appointments { get; private set; }

        public const bool INCLUDEOBJECTS = true;

        public static SelectCustomerResponse FromCustomer(Customer customer, bool includeObjects)
            => new(
                customer.Id,
                customer.TenantId,
                customer.UserId,
                customer.Cpf,
                customer.FullName,
                customer.Nickname,
                customer.Gender,
                customer.BirthDate,
                customer.PhoneNumber,
                customer.LastServiceName,
                customer.LastServiceDate,
                customer.TimesVisited,
                (includeObjects) ? customer.Appointments : null
                );

        public static implicit operator SelectCustomerResponse(Customer customer)
        => new(
            customer.Id,
            customer.TenantId,
            customer.UserId,
            customer.Cpf,
            customer.FullName,
            customer.Nickname,
            customer.Gender,
            customer.BirthDate,
            customer.PhoneNumber,
            customer.LastServiceName,
            customer.LastServiceDate,
            customer.TimesVisited,
            (INCLUDEOBJECTS) ? customer.Appointments : null
        );
    }
}
