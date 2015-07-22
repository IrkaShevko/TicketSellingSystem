using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        private TicketConfiguration()
        {
            ToTable("Tickets");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            Property(e => e.SessionSeatId)
                .HasColumnName("session_seat_id")
                .IsRequired();

            HasRequired(e => e.SessionSeat)
                .WithRequiredDependent(e => e.Ticket);
        }
    }
}