using SalonManager.Customers.Core.Entities;

namespace SalonManager.Customers.Features.Customers.Commands.Update
{
    public class UpdateCustomerResponse
    {
        public UpdateCustomerResponse
            (Guid id,
            Guid tenantId,
            string? cpf,
            string? name,
            string? nickname,
            string? gender,
            DateTime birthDate,
            string? phoneNumber)
        {
            Id = id;
            TenantId = tenantId;
            Cpf = cpf;
            Name = name;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string? Cpf { get; private set; }
        public string? Name { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public static implicit operator UpdateCustomerResponse(Customer customer)
            => new(
                customer.Id,
                customer.TenantId,
                customer.Cpf,
                customer.FullName,
                customer.Nickname,
                customer.Gender,
                customer.BirthDate,
                customer.PhoneNumber
                );
    }
}
