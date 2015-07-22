namespace TicketSellingSystemInfrastructure.Models.ViewModels.StatusModels
{
    public class ResultModel
    {
        public string ErrorMessage { get; set; }
        public bool IsOk { get; set; }
        public object Result { get; set; }
    }
}
