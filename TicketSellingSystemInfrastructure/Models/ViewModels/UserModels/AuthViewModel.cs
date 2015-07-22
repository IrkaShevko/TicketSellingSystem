namespace TicketSellingSystemInfrastructure.Models.ViewModels.UserModels
{
    public class AuthViewModel
    {
        public UserViewModel User { get; set; }

        public bool IsAuthorized { get; set; }
    }
}
