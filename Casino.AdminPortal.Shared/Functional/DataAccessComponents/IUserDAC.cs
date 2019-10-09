using System.Collections.Generic;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.DAC;

namespace Casino.AdminPortal.Shared.Functional.DataAccessComponents
{
    public interface IUserDac : IDataAccessComponent
    {
        IUserDto CreateUser(IUserDto userDto);
        IList<IUserDto> GetAllUsers();
        IUserDto GetUserByEmail(string email);
        IUserDto GetUserByContactNumber(string contactNumber);
        IUserDto RechargeAccount(string emailId, decimal amount);
        IUserDto BlockAmount(string emailId, int amount);
        IUserDto AddWinningAmount(string emailId, int betAmount, decimal multiply);
        IList<IUserDto> SearchUser(string name, string contact, string email);
    }
}
