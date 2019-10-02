using Casino.AdminPortal.EntityDataModel.EntityModel;
using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino.AdminPortal.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }

        public IUserDTO CreateUser(IUserDTO userDTO)
        {
            IUserDTO createUserRetval = null;
            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player player = new Player();
                    userDTO.BlockedAmount = 0;
                    userDTO.AccountBalance = 500;
                    EntityDataModel.EntityConverter.FillEntityFromDTO(userDTO, player);
                    context.Players.Add(player);
                    if (context.SaveChanges() > 0)
                    {
                        userDTO.PlayerId = player.PlayerId;
                        createUserRetval = userDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;
        }


        public IList<IUserDTO> GetAllUsers()
        {
            IList<IUserDTO> userDtoList = new List<IUserDTO>();
            using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
            {
                foreach (Player player in context.Players)
                {
                    IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                    EntityDataModel.EntityConverter.FillDTOFromEntity(player, userDTO);
                    userDtoList.Add(userDTO);
                }
                    return userDtoList;
            }
        }


        public IUserDTO GetUserByEmail(string email)
        {
            IUserDTO createUserRetval = null;

            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.EmailId == email);

                    if (playerDetails != null)
                    {
                        createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;
        
        }

        public IUserDTO GetUserByContactNumber(string contactNumber)
        {
            IUserDTO createUserRetval = null;

            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.ContactNumber == contactNumber);

                    if (playerDetails != null)
                    {
                        createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;
        }

        public IUserDTO RechargeAccount(string emailId, decimal amount)
        {
            IUserDTO createUserRetval = null;

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
                            createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;
        }

        public IUserDTO BlockAmount(string emailId, int amount)
        {
            IUserDTO createUserRetval = null;
            decimal amountD = (decimal)amount;
            try
            {
                using (CasinoAdminPortalEntities context = new CasinoAdminPortalEntities())
                {
                    Player playerDetails = context.Players.FirstOrDefault(item => item.EmailId == emailId);
                    if (playerDetails.AccountBalance < amountD)
                    {
                        createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);
                    }
                    else
                    {

                        playerDetails.BlockedAmount = amount;
                        playerDetails.AccountBalance -= amountD;
                        if (context.SaveChanges() > 0)
                        {
                            createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);
                        }
                    }
                }
            }
            catch (Exception ex){
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;
        }

        public IUserDTO AddWinningAmount(string emailId, int betAmount, decimal multiply)
        {
            IUserDTO createUserRetval = null;

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
                            createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;
        }



        public IList<IUserDTO> SearchUser(string name, string contact, string email)
        {
            IList<IUserDTO> retVal = null;
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
                        retVal = new List<IUserDTO>();
                        foreach (var user in userList)
                        {
                            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                            retVal.Add(userDTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retVal;

        }
    }
}
