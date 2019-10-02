using Casino.AdminPortal.Shared;
using System.ComponentModel.DataAnnotations;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Common.Constants;
using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.Web.Models
{
    public class UserModel : DtoBase ,IUserDto
    {
       public int PlayerId { get; set; }
       [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = Constants.UserMessage.ErrorName)]
       [Required]
       public string Name { get; set; }
       [Range(1000000000, 9999999999, ErrorMessage = Constants.UserMessage.ErrorContact)]
       [Required]
       public string ContactNumber { get; set; }
       [Required]
       [EmailAddress(ErrorMessage = Constants.UserMessage.ErrorEmail)]
       public string EmailId { get; set; }
       [Required]
       public System.DateTime DateOfBirth { get; set; }
       public decimal AccountBalance { get; set; }
       public byte[] IdentityProof { get; set; }
       public int BlockedAmount { get; set; }
       public decimal RechargeAmount { get; set; }
    }
}