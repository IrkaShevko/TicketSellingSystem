using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class SeatConfiguration : EntityTypeConfiguration<Seat>
    {
        private SeatConfiguration()
        {
            ToTable("Seats");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.SeatNumber)
                .HasColumnName("seat_number")
                .IsRequired();

            Property(e => e.EmptySpace)
                .HasColumnName("empty_space")
                .IsRequired();

            Property(e => e.RowId)
                .HasColumnName("row_id")
                .IsRequired();

            HasMany(e => e.SessionSeats)
                .WithRequired(e => e.Seat)
                .HasForeignKey(e => e.SeatId)
                .WillCascadeOnDelete(false);
        }
    }
}