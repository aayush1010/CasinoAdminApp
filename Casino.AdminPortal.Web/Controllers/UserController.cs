using Casino.AdminPortal.Shared;
using Casino.AdminPortal.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Casino.AdminPortal.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);

        public byte[] convertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public ActionResult SearchUser(string searchName, string searchContact, string searchEmail)
        {
            
            List<UserModel> result = new List<UserModel>();
            if (searchContact == "" && searchName == "" && searchEmail == "") { }
            else
            {
                searchName = (searchName == "") ? null : searchName;
                searchContact = (searchContact == "") ? null : searchContact;
                searchEmail = (searchEmail == "") ? null : searchEmail;

            }
            OperationResult<IList<IUserDTO>> resultAllUsers = userFacade.SearchUser(searchName, searchContact, searchEmail);
            if (resultAllUsers.IsValid())
            {
                foreach (var item in resultAllUsers.Data)
                {
                    UserModel userData = new UserModel();
                    DTOConverter.FillViewModelFromDTO(userData, item);
                    result.Add(userData);
                }
            }
            int pageSize = 5;
            int pageNumber = 1;
            return View("GetAllUsers", result.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult Index()
        {
            return PartialView();
        }

        public ActionResult GetAllUsers(int ?page)
        {
            OperationResult<IList<IUserDTO>> resultAllUsers = userFacade.GetAllUsers();
            List<UserModel> result = new List<UserModel>();
            if (resultAllUsers.IsValid())
            {
                foreach (var item in resultAllUsers.Data)
                {
                    UserModel userData = new UserModel();
                    DTOConverter.FillViewModelFromDTO(userData, item);
                    result.Add(userData);
                }
            }
            else
            {
                IList<EmployeePortalValidationFailure> resultFail = resultAllUsers.ValidationResult.Errors;
                foreach (var item in resultFail)
                {

                }
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(result.OrderBy(item => item.Name).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            UserModel result = new UserModel();
            return View(result);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel responseModel)
        {
            IUserDTO userDTOToCreate = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            HttpPostedFileBase file = Request.Files["ImageData"];
            responseModel.IdentityProof = convertToBytes(file);
            if (ModelState.IsValid)
            {
                DTOConverter.FillDTOFromViewModel(userDTOToCreate, responseModel);
                OperationResult<IUserDTO> resultCreate = userFacade.CreateUser(userDTOToCreate);
                if (resultCreate.ValidationResult != null && resultCreate.ValidationResult.Errors != null)
                {
                    IList<EmployeePortalValidationFailure> resultFail = resultCreate.ValidationResult.Errors;
                    foreach (var item in resultFail)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();
                }
                return View("../Home/Index");
            }
            return View();

        }
        
        public ActionResult AddMoney(string EmailId, decimal RechargeAmount)
        {
            OperationResult<IUserDTO> resultCreate = userFacade.RechargeAccount(EmailId, RechargeAmount);

            if (resultCreate.ValidationResult != null && resultCreate.ValidationResult.Errors != null)
            {
                IList<EmployeePortalValidationFailure> resultFail = resultCreate.ValidationResult.Errors;
                foreach (var item in resultFail)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            return RedirectToAction("GetAllUsers", "User");
        }
              
    }
}