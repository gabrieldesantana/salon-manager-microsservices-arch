﻿using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.CrossCutting.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto(Guid tenantId, Guid userCreatorId, Guid userId, Guid companyId, string? cpf, string? name, string? nickname, string? gender, DateTime birthDate, string? phoneNumber)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            UserId = userId;
            CompanyId = companyId;
            Cpf = cpf;
            Name = name;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Appointments = [];
        }

        public Guid UserId { get; private set; }
        public Guid CompanyId { get; private set; }

        public string? Cpf { get; private set; }
        public string? Name { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }
        public List<Appointment>? Appointments { get; set; }

        #region BaseEntity
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid TenantId { get; set; }
        public Guid UserCreatorId { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsActived { get; set; }

        #endregion  
    }
}
