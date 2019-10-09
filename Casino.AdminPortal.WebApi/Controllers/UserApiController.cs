using Casino.AdminPortal.Shared;
using Casino.AdminPortal.WebApi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Casino.AdminPortal.WebApi.Controllers
{
    public class UserApiController : ApiController
    {
        readonly IUserFacade _userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
        public UserList GetAllUsers()
        {
           
            OperationResult<IList<IUserDto>> resultAllUsers = _userFacade.GetAllUsers();
            UserList result = new UserList();
            result.UserList = new List<User>();
            if (resultAllUsers.IsValid())
            {
                foreach (var item in resultAllUsers.Data)
                {
                    User temp = new User();
                    temp.Name = item.Name;
                    temp.EmailId = item.EmailId;
                    temp.AccountBalance = item.AccountBalance;
                    temp.BlockedAmount = item.BlockedAmount;
                    result.UserList.Add(temp);
                }
            }
            else
            {
            }
            return result;
        }

        public User GetUserByMail(string email)
        {

            OperationResult<IUserDto> resultUser = _userFacade.GetUserByEmail(email);
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
            OperationResult<IUserDto> resultUser = _userFacade.BlockAmount(emailid, amount);
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
            OperationResult<IUserDto> resultUser = _userFacade.AddWinningAmount(emailid, amount, multiply);
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
