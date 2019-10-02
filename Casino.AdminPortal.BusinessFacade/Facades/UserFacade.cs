using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;

namespace Casino.AdminPortal.BusinessFacades
{
    public class UserFacade : FacadeBase, IUserFacade
    {
        public UserFacade() : base(FacadeType.UserFacade)
        {

        }

        public OperationResult<IUserDto> CreateUser(IUserDto userDto)
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.CreateUser(userDto);
        }
        public OperationResult<IList<IUserDto>> GetAllUsers()
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.GetAllUsers();
        }


        public OperationResult<IUserDto> GetUserByEmail(string email)
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.GetUserByEmail(email);
        }

        public OperationResult<IUserDto> GetUserByContactNumber(string contactNumber)
        {
            throw new NotImplementedException();
        }

        public OperationResult<IUserDto> RechargeAccount(string emailId, decimal amount)
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.RechargeAccount(emailId, amount);
        }

        public OperationResult<IUserDto> BlockAmount(string emailId, int amount)
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.BlockAmount(emailId, amount);
        }

        public OperationResult<IUserDto> AddWinningAmount(string emailId, int betAmount, decimal multiply)
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.AddWinningAmount(emailId, betAmount, multiply);
        }

        public OperationResult<IList<IUserDto>> SearchUser(string name, string contact, string email)
        {
            IUserBdc userBdc = (IUserBdc)BdcFactory.Instance.Create(BdcType.UserBdc);
            return userBdc.SearchUser(name,contact, email);
        }
    }
}
