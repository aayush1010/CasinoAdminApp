using Casino.AdminPortal.Business.Validation;
using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;

namespace Casino.AdminPortal.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }

        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> createUserReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, Constants.UserMessage.CreateUserEmail);

                if (!validationResult.IsValid)
                {
                    createUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDAC employeeDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                    IUserDTO returnedUserDTO = employeeDAC.CreateUser(userDTO);
                    if (returnedUserDTO != null)
                    {
                        createUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.Usercreatedsuccessfully);
                    }
                    else
                    {
                        createUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                    }
                }
            }
            catch (DACException dacEx)
            {
                createUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                createUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return createUserReturnValue;
        }

        public OperationResult<IList<IUserDTO>> GetAllUsers()
        {
            OperationResult<IList<IUserDTO>> retVal = null;
            IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
            IList<IUserDTO> result = userDAC.GetAllUsers();
            retVal = OperationResult<IList<IUserDTO>>.CreateSuccessResult(result);
            return retVal;
        }

        public OperationResult<IUserDTO> GetUserByEmail(string email)
        {
            OperationResult<IUserDTO> getUserReturnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO returnedUserDTO = userDAC.GetUserByEmail(email);
                if (returnedUserDTO != null)
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.Successfully);
                }
                else
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getUserReturnValue;
        }

        public OperationResult<IUserDTO> GetUserByContactNumber(string contactNumber)
        {
            OperationResult<IUserDTO> getUserReturnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO returnedUserDTO = userDAC.GetUserByContactNumber(contactNumber);
                if (returnedUserDTO != null)
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.Reterived);
                }
                else
                {
                    getUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getUserReturnValue;
        }

        public OperationResult<IUserDTO> RechargeAccount(string emailId, decimal amount)
        {
            OperationResult<IUserDTO>returnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO returnedUserDTO = userDAC.RechargeAccount(emailId, amount);
                if (returnedUserDTO != null)
                {
                    returnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.Reterived);
                }
                else
                {
                    returnValue = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }

            }
            catch (DACException dacEx)
            {
                returnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                returnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return returnValue;
        }

        public OperationResult<IUserDTO> BlockAmount(string emailId, int amount)
        {
            OperationResult<IUserDTO> returnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO returnedUserDTO = userDAC.BlockAmount(emailId, amount);
                if (returnedUserDTO != null)
                {
                    returnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.Reterived);
                }
                else
                {
                    returnValue = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }

            }
            catch (DACException dacEx)
            {
                returnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                returnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return returnValue;
        }

        public OperationResult<IUserDTO> AddWinningAmount(string emailId, int betAmount, decimal multiply)
        {
            OperationResult<IUserDTO> returnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO returnedUserDTO = userDAC.AddWinningAmount(emailId, betAmount, multiply);
                if (returnedUserDTO != null)
                {
                    returnValue = OperationResult<IUserDTO>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.Reterived);
                }
                else
                {
                    returnValue = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                }

            }
            catch (DACException dacEx)
            {
                returnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                returnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return returnValue;
        }

        public OperationResult<IList<IUserDTO>> SearchUser(string name, string contact, string email)
        {
            OperationResult<IList<IUserDTO>> getUserReturnValue = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IList<IUserDTO> returnedUserDTO = userDAC.SearchUser(name, contact,email);
                if (returnedUserDTO != null)
                {
                    getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateSuccessResult(returnedUserDTO, Constants.UserMessage.SearchSuc);
                }
                else
                {
                    getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateFailureResult(Constants.UserMessage.SearchFail);
                }
            }
            catch (DACException dacEx)
            {
                getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getUserReturnValue = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return getUserReturnValue;
        }
    }
}
