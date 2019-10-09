using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.Shared.Functional.DataTransferObjects
{
     
    public interface IUserDto : IDto
    {
 
        int PlayerId { get; set; }
         
        string Name { get; set; }
        
        string ContactNumber { get; set; }
        string EmailId { get; set; }
        System.DateTime DateOfBirth { get; set; }
        decimal AccountBalance { get; set; }
        byte[] IdentityProof { get; set; }
        int BlockedAmount { get; set; }
    }
}
