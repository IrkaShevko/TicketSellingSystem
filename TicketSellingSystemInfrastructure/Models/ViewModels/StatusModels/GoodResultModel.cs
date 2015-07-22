namespace TicketSellingSystemInfrastructure.Models.ViewModels.StatusModels
{
    public class GoodResultModel:ResultModel
    {
        public GoodResultModel(object result)
        {
            IsOk = true;
            Result = result;
        }
    }
}
