﻿using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Employees.Commands.Update
{
    public class UpdateEmployeeRequest : IRequest<Result<UpdateEmployeeResponse>>
    {
        public UpdateEmployeeRequest(
           Guid id,
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
    }
}
