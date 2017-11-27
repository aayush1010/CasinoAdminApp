using Casino.AdminPortal.Shared;
using Casino.AdminPortal.Web.Shared;
using System.Web.Script.Serialization;
using Casino.AdminPortal.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Casino.AdminPortal.WebApi.Controllers
{
    public class UserApiController : ApiController
    {
        IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
        public UserList GetAllUsers()
        {
           
            OperationResult<IList<IUserDTO>> resultAllUsers = userFacade.GetAllUsers();
            UserList result = new UserList();
            result.userList = new List<User>();
            if (resultAllUsers.IsValid())
            {
                foreach (var item in resultAllUsers.Data)
                {
                    User temp = new User();
                    temp.Name = item.Name;
                    temp.EmailId = item.EmailId;
                    temp.AccountBalance = item.AccountBalance;
                    temp.BlockedAmount = item.BlockedAmount;
                    result.userList.Add(temp);
                }
            }
            else
            {
            }
            return result;
        }

        public User GetUserByMail(string email)
        {

            OperationResult<IUserDTO> resultUser = userFacade.GetUserByEmail(email);
            User result = new User();
            if (resultUser.IsValid())
            {
                result.Name = resultUser.Data.Name;
                result.EmailId = resultUser.Data.EmailId;
                result.AccountBalance = resultUser.Data.AccountBalance;
                result.BlockedAmount = resultUser.Data.BlockedAmount;
            }
            else
            { }
            return result;
        }

        [HttpPatch]
        public User BlockedAmount(string emailid, int amount) {
            OperationResult<IUserDTO> resultUser = userFacade.BlockAmount(emailid, amount);
            User result = new User();
            if (resultUser.IsValid())
            {
                result.Name = resultUser.Data.Name;
                result.EmailId = resultUser.Data.EmailId;
                result.AccountBalance = resultUser.Data.AccountBalance;
                result.BlockedAmount = resultUser.Data.BlockedAmount;
            }
            else
            { }
            return result;
        }

        [HttpPatch]
        public User AddWinningAmount(string emailid, int amount, decimal multiply)
        {
            OperationResult<IUserDTO> resultUser = userFacade.AddWinningAmount(emailid, amount, multiply);
            User result = new User();
            if (resultUser.IsValid())
            {
                result.Name = resultUser.Data.Name;
                result.EmailId = resultUser.Data.EmailId;
                result.AccountBalance = resultUser.Data.AccountBalance;
                result.BlockedAmount = resultUser.Data.BlockedAmount;
            }
            else
            { }
            return result;
        }
        
    }
}
