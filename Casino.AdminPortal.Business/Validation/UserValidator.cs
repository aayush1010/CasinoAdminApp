using Casino.AdminPortal.Shared;
using FluentValidation;
using System;
using Casino.AdminPortal.Shared.Functional.DataAccessComponents;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Common.Constants;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.DAC;

namespace Casino.AdminPortal.Business.Validation
{
    public class UserValidator : AbstractValidator<IUserDto>
    {
        public UserValidator()
        {
            RuleSet("CreateUserEmail", () =>
            {
                RuleFor(user => user.EmailId).Must(IsUniqueEmail).WithMessage(Constants.UserMessage.EmailUnique);
                RuleFor(user => user.DateOfBirth).Must(CalculateAge).WithMessage(Constants.UserMessage.Age);
            });
        }
        private bool IsUniqueEmail(string arg)
        {
            IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
            IUserDto userDto = userDac.GetUserByEmail(arg);
            return userDto == null;
        }

        private bool CalculateAge(DateTime dob)
        {
            int age = ((DateTime.Now.Year - dob.Year) * 372 + (DateTime.Now.Month - dob.Month) * 31 + (DateTime.Now.Day - dob.Day)) / 372;
            if (age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
