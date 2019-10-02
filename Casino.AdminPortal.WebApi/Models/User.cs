namespace Casino.AdminPortal.WebApi.Models
{
    public class User
    {
     
        public string Name { get; set; }

        public string EmailId { get; set; }
        
        public decimal AccountBalance { get; set; }
        
        public int BlockedAmount { get; set; }

    }
}