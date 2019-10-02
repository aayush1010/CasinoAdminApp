using System.Collections.Generic;

namespace Casino.AdminPortal.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        IUserDTO CreateUser(IUserDTO userDTO);
        IList<IUserDTO> GetAllUsers();
        IUserDTO GetUserByEmail(string email);
        IUserDTO GetUserByContactNumber(string contactNumber);
        IUserDTO RechargeAccount(string emailId, decimal amount);
        IUserDTO BlockAmount(string emailId, int amount);
        IUserDTO AddWinningAmount(string emailId, int betAmount, decimal multiply);
        IList<IUserDTO> SearchUser(string name, string contact, string email);
    }
}
