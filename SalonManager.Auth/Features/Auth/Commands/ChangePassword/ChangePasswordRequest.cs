using FluentResults;
using MediatR;

namespace SalonManager.Auth.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordRequest : IRequest<Result<ChangePasswordResponse>>
    {
        public ChangePasswordRequest(Guid id, string oldPassword, string newPasswordOne, string newPasswordTwo)
        {
            Id = id;
            OldPassword = oldPassword;
            NewPasswordOne = newPasswordOne;
            NewPasswordTwo = newPasswordTwo;
        }

        public Guid Id { get; private set; }
        public string OldPassword { get; private set; }
        public string NewPasswordOne { get; private set; }
        public string NewPasswordTwo { get; private set; }
    }
}
