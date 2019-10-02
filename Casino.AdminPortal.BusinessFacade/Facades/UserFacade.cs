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

        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.CreateUser(userDTO);
        }
        public OperationResult<IList<IUserDTO>> GetAllUsers()
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetAllUsers();
        }


        public OperationResult<IUserDTO> GetUserByEmail(string email)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetUserByEmail(email);
        }

        public OperationResult<IUserDTO> GetUserByContactNumber(string contactNumber)
        {
            throw new NotImplementedException();
        }

        public OperationResult<IUserDTO> RechargeAccount(string emailId, decimal amount)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.RechargeAccount(emailId, amount);
        }

        public OperationResult<IUserDTO> BlockAmount(string emailId, int amount)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.BlockAmount(emailId, amount);
        }

        public OperationResult<IUserDTO> AddWinningAmount(string emailId, int betAmount, decimal multiply)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.AddWinningAmount(emailId, betAmount, multiply);
        }

        public OperationResult<IList<IUserDTO>> SearchUser(string name, string contact, string email)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.SearchUser(name,contact, email);
        }
    }
}
