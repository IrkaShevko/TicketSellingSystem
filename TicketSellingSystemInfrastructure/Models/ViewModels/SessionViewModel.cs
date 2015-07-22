using System;

namespace TicketSellingSystemInfrastructure.Models.ViewModels
{
    public class SessionViewModel
    {
        public DateTime Date { get; set; }

        public string Day
        {
            get { return Date.Date.ToShortDateString(); }
        }

        public TimeSpan Time
        {
            get { return Date.TimeOfDay; }
        }

        public double Price { get; set; }
    }
}