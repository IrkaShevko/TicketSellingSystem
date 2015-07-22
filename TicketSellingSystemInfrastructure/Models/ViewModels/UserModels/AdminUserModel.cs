namespace TicketSellingSystemInfrastructure.Models.ViewModels.UserModels
{
    public class AdminUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Roles { get; set; }
        public bool Blocked { get; set; }
    }
}
