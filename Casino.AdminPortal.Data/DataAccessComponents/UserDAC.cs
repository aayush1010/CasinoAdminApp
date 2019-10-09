using System;
using System.Collections.Generic;
using System.Linq;
using Casino.AdminPortal.EntityDataModel.Converter;
using Casino.AdminPortal.EntityDataModel.EntityModel;
using Casino.AdminPortal.Shared.Functional.DataAccessComponents;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.Common.ExceptionHandling;
using Casino.AdminPortal.Shared.Infrastructure.Common.ExceptionHandling.CustomExceptionHandling;
using Casino.AdminPortal.Shared.Infrastructure.DAC;
using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.Data.DataAccessComponents
{
    public class UserDac : DacBase, IUserDac
    {
        public UserDac()
            : base(DacType.UserDac)
        {

        }

        public IUserDto CreateUser(IUserDto userDto)
        {
            IUserDto createUserRetval = null;
            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player player = new Player();
                    userDto.BlockedAmount = 0;
                    userDto.AccountBalance = 500;
                    EntityConverter.FillEntityFromDto(userDto, player);
                    context.Players.Add(player);
                    if (context.SaveChanges() > 0)
                    {
                        userDto.PlayerId = player.PlayerId;
                        createUserRetval = userDto;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return createUserRetval;
        }


        public IList<IUserDto> GetAllUsers()
        {
            IList<IUserDto> userDtoList = new List<IUserDto>();
            using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
            {
                foreach (Player player in context.Players)
                {
                    IUserDto userDto = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                    EntityConverter.FillDtoFromEntity(player, userDto);
                    userDtoList.Add(userDto);
                }
                    return userDtoList;
            }
        }


        public IUserDto GetUserByEmail(string email)
        {
            IUserDto createUserRetval = null;

            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.EmailId == email);

                    if (playerDetails != null)
                    {
                        createUserRetval = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                        EntityConverter.FillDtoFromEntity(playerDetails, createUserRetval);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return createUserRetval;
        
        }

        public IUserDto GetUserByContactNumber(string contactNumber)
        {
            IUserDto createUserRetval = null;

            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.ContactNumber == contactNumber);

                    if (playerDetails != null)
                    {
                        createUserRetval = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                        EntityConverter.FillDtoFromEntity(playerDetails, createUserRetval);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return createUserRetval;
        }

        public IUserDto RechargeAccount(string emailId, decimal amount)
        {
            IUserDto createUserRetval = null;

            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.EmailId == emailId);

                    if (playerDetails != null)
                    {
                        playerDetails.AccountBalance += amount;
                        if (context.SaveChanges() > 0)
                        {
                            createUserRetval = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                            EntityConverter.FillDtoFromEntity(playerDetails, createUserRetval);
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return createUserRetval;
        }

        public IUserDto BlockAmount(string emailId, int amount)
        {
            IUserDto createUserRetval = null;
            decimal amountD = (decimal)amount;
            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.EmailId == emailId);
                    if (playerDetails != null && playerDetails.AccountBalance < amountD)
                    {
                        createUserRetval = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                        EntityConverter.FillDtoFromEntity(playerDetails, createUserRetval);
                    }
                    else
                    {
                        if (playerDetails != null)
                        {
                            playerDetails.BlockedAmount = amount;
                            playerDetails.AccountBalance -= amountD;
                            if (context.SaveChanges() > 0)
                            {
                                createUserRetval = (IUserDto) DtoFactory.Instance.Create(DtoType.UserDto);
                                EntityConverter.FillDtoFromEntity(playerDetails, createUserRetval);
                            }
                        }
                    }
                }
            }
            catch (Exception ex){
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return createUserRetval;
        }

        public IUserDto AddWinningAmount(string emailId, int betAmount, decimal multiply)
        {
            IUserDto createUserRetval = null;

            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.EmailId == emailId);

                    if (playerDetails != null)
                    {
                        playerDetails.AccountBalance += (decimal)(betAmount*multiply) ;
                        playerDetails.BlockedAmount = 0;
                        if (context.SaveChanges() > 0)
                        {
                            createUserRetval = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                            EntityConverter.FillDtoFromEntity(playerDetails, createUserRetval);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return createUserRetval;
        }



        public IList<IUserDto> SearchUser(string name, string contact, string email)
        {
            IList<IUserDto> retVal = null;
            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    IList<SearchPlayer_Result> userList  = new List<SearchPlayer_Result>();
                    userList = (IList<SearchPlayer_Result>)context.SearchPlayer(name,
                                                            contact,
                                                            email).ToList();
                    if (userList.Count > 0)
                    {
                        retVal = new List<IUserDto>();
                        foreach (var user in userList)
                        {
                            IUserDto userDto = (IUserDto)DtoFactory.Instance.Create(DtoType.UserDto);
                            EntityConverter.FillDtoFromEntity(user, userDto);
                            retVal.Add(userDto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DacException(ex.Message);
            }
            return retVal;

        }
    }
}
