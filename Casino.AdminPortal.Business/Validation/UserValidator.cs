using Casino.AdminPortal.Shared;
using FluentValidation;
using System;

namespace Casino.AdminPortal.Business.Validation
{
    public class UserValidator : AbstractValidator<IUserDTO>
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
            IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
            IUserDTO userDTO = userDAC.GetUserByEmail(arg);
            return userDTO == null;
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
