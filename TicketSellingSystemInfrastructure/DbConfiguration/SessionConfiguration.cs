using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class SessionConfiguration : EntityTypeConfiguration<Session>
    {
        private SessionConfiguration()
        {
            ToTable("Sessions");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.FilmId)
                .HasColumnName("film_id")
                .IsRequired();

            Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();

            Property(e => e.Price)
                .HasColumnName("price")
                .IsRequired();

            Property(e => e.HallId)
                .HasColumnName("hall_id")
                .IsRequired();

            Property(e => e.CountTickets)
                .HasColumnName("count_tickets")
                .IsRequired();

            HasMany(e => e.SessionSeats)
                .WithRequired(e => e.Session)
                .HasForeignKey(e => e.SessionId)
                .WillCascadeOnDelete(false);
        }
    }
}