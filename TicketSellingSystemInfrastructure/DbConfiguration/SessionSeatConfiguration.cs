using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class SessionSeatConfiguration : EntityTypeConfiguration<SessionSeat>
    {
        private SessionSeatConfiguration()
        {
            ToTable("SessionSeats");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.SeatId)
                .HasColumnName("seat_id")
                .IsRequired();

            Property(e => e.Blocked)
                .HasColumnName("blocked")
                .IsRequired();

            Property(e => e.Bought)
                .HasColumnName("bought")
                .IsRequired();

            Property(e => e.SessionId)
                .HasColumnName("session_id")
                .IsRequired();
        }
    }
}