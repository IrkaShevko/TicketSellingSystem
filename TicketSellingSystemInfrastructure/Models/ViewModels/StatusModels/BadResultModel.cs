using TicketSellingSystemInfrastructure.Constants;

namespace TicketSellingSystemInfrastructure.Models.ViewModels.StatusModels
{
    public class BadResultModel : ResultModel
    {
        public BadResultModel(string message)
        {
            IsOk = false;
            ErrorMessage = message;
        }

        public BadResultModel()
        {
            IsOk = false;
            ErrorMessage = ErrorMessages.CommonError;
        }
    }
}