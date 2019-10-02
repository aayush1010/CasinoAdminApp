using System;
using System.Collections.Generic;
using Casino.AdminPortal.Business.Validation;
using Casino.AdminPortal.Shared.Functional.BusinessDomainComponents;
using Casino.AdminPortal.Shared.Functional.DataAccessComponents;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Business;
using Casino.AdminPortal.Shared.Infrastructure.Common.Constants;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.Common.ExceptionHandling;
using Casino.AdminPortal.Shared.Infrastructure.Common.ExceptionHandling.CustomExceptionHandling;
using Casino.AdminPortal.Shared.Infrastructure.Common.OperationResult;
using Casino.AdminPortal.Shared.Infrastructure.Common.Validation;
using Casino.AdminPortal.Shared.Infrastructure.DAC;

namespace Casino.AdminPortal.Business.Business
{
    public class UserBdc : BdcBase, IUserBdc
    {
        public UserBdc()
            : base(BdcType.UserBdc)
        {

        }

        public OperationResult<IUserDto> CreateUser(IUserDto userDto)
        {
            OperationResult<IUserDto> createUserReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<UserValidator, IUserDto>.Validate(userDto, Constants.UserMessage.CreateUserEmail);

                if (!validationResult.IsValid)
                {
                    createUserReturnValue = OperationResult<IUserDto>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDac employeeDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                    IUserDto returnedUserDto = employeeDac.CreateUser(userDto);
                    if (returnedUserDto != null)
                    {
                        createUserReturnValue = OperationResult<IUserDto>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.Usercreatedsuccessfully);
                    }
                    else
                    {
                        createUserReturnValue = OperationResult<IUserDto>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                    }
                }
            }
            catch (DacException dacEx)
            {
                createUserReturnValue = OperationResult<IUserDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                createUserReturnValue = OperationResult<IUserDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return createUserReturnValue;
        }

        public OperationResult<IList<IUserDto>> GetAllUsers()
        {
            OperationResult<IList<IUserDto>> retVal = null;
            IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
            IList<IUserDto> result = userDac.GetAllUsers();
            retVal = OperationResult<IList<IUserDto>>.CreateSuccessResult(result);
            return retVal;
        }

        public OperationResult<IUserDto> GetUserByEmail(string email)
        {
            OperationResult<IUserDto> getUserReturnValue = null;
            try
            {
                IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                IUserDto returnedUserDto = userDac.GetUserByEmail(email);
                if (returnedUserDto != null)
                {
                    getUserReturnValue = OperationResult<IUserDto>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.Successfully);
                }
                else
                {
                    getUserReturnValue = OperationResult<IUserDto>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }
            }
            catch (DacException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getUserReturnValue;
        }

        public OperationResult<IUserDto> GetUserByContactNumber(string contactNumber)
        {
            OperationResult<IUserDto> getUserReturnValue = null;
            try
            {
                IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                IUserDto returnedUserDto = userDac.GetUserByContactNumber(contactNumber);
                if (returnedUserDto != null)
                {
                    getUserReturnValue = OperationResult<IUserDto>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.Reterived);
                }
                else
                {
                    getUserReturnValue = OperationResult<IUserDto>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }
            }
            catch (DacException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getUserReturnValue;
        }

        public OperationResult<IUserDto> RechargeAccount(string emailId, decimal amount)
        {
            OperationResult<IUserDto>returnValue = null;
            try
            {
                IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                IUserDto returnedUserDto = userDac.RechargeAccount(emailId, amount);
                if (returnedUserDto != null)
                {
                    returnValue = OperationResult<IUserDto>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.Reterived);
                }
                else
                {
                    returnValue = OperationResult<IUserDto>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }

            }
            catch (DacException dacEx)
            {
                returnValue = OperationResult<IUserDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                returnValue = OperationResult<IUserDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return returnValue;
        }

        public OperationResult<IUserDto> BlockAmount(string emailId, int amount)
        {
            OperationResult<IUserDto> returnValue = null;
            try
            {
                IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                IUserDto returnedUserDto = userDac.BlockAmount(emailId, amount);
                if (returnedUserDto != null)
                {
                    returnValue = OperationResult<IUserDto>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.Reterived);
                }
                else
                {
                    returnValue = OperationResult<IUserDto>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }

            }
            catch (DacException dacEx)
            {
                returnValue = OperationResult<IUserDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                returnValue = OperationResult<IUserDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return returnValue;
        }

        public OperationResult<IUserDto> AddWinningAmount(string emailId, int betAmount, decimal multiply)
        {
            OperationResult<IUserDto> returnValue = null;
            try
            {
                IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                IUserDto returnedUserDto = userDac.AddWinningAmount(emailId, betAmount, multiply);
                if (returnedUserDto != null)
                {
                    returnValue = OperationResult<IUserDto>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.Reterived);
                }
                else
                {
                    returnValue = OperationResult<IUserDto>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }

            }
            catch (DacException dacEx)
            {
                returnValue = OperationResult<IUserDto>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                returnValue = OperationResult<IUserDto>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return returnValue;
        }

        public OperationResult<IList<IUserDto>> SearchUser(string name, string contact, string email)
        {
            OperationResult<IList<IUserDto>> getUserReturnValue = null;
            try
            {
                IUserDac userDac = (IUserDac)DacFactory.Instance.Create(DacType.UserDac);
                IList<IUserDto> returnedUserDto = userDac.SearchUser(name, contact,email);
                if (returnedUserDto != null)
                {
                    getUserReturnValue = OperationResult<IList<IUserDto>>.CreateSuccessResult(returnedUserDto, Constants.UserMessage.SearchSuc);
                }
                else
                {
                    getUserReturnValue = OperationResult<IList<IUserDto>>.CreateFailureResult(Constants.UserMessage.SearchFail);
                }
            }
            catch (DacException dacEx)
            {
                getUserReturnValue = OperationResult<IList<IUserDto>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IList<IUserDto>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getUserReturnValue;
        }
    }
}
