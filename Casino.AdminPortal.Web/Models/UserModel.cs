using Casino.AdminPortal.Shared;
using System.ComponentModel.DataAnnotations;

namespace Casino.AdminPortal.Web.Models
{
    public class UserModel : DTOBase ,IUserDTO
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