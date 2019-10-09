using System.Collections.Generic;

namespace Casino.AdminPortal.Shared
{
    public interface IUserBdc : IBusinessDomainComponent
    {
        OperationResult<IUserDto> CreateUser(IUserDto userDto);
        OperationResult<IList<IUserDto>> GetAllUsers();
        OperationResult<IUserDto> GetUserByEmail(string email);
        OperationResult<IUserDto> GetUserByContactNumber(string contactNumber);
        OperationResult<IUserDto> RechargeAccount(string emailId, decimal amount);
        OperationResult<IUserDto> BlockAmount(string emailId, int amount);
        OperationResult<IUserDto> AddWinningAmount(string emailId, int betAmount, decimal multiply);
        OperationResult<IList<IUserDto>> SearchUser(string name, string contact, string email);
    }
}
