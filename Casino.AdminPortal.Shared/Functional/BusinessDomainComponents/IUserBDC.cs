using System.Collections.Generic;

namespace Casino.AdminPortal.Shared
{
    public interface IUserBDC : IBusinessDomainComponent
    {
        OperationResult<IUserDTO> CreateUser(IUserDTO userDTO);
        OperationResult<IList<IUserDTO>> GetAllUsers();
        OperationResult<IUserDTO> GetUserByEmail(string email);
        OperationResult<IUserDTO> GetUserByContactNumber(string contactNumber);
        OperationResult<IUserDTO> RechargeAccount(string emailId, decimal amount);
        OperationResult<IUserDTO> BlockAmount(string emailId, int amount);
        OperationResult<IUserDTO> AddWinningAmount(string emailId, int betAmount, decimal multiply);
        OperationResult<IList<IUserDTO>> SearchUser(string name, string contact, string email);
    }
}
