using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class SeatTypeConfiguration : EntityTypeConfiguration<SeatType>
    {
        private SeatTypeConfiguration()
        {
            ToTable("SeatTypes");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Multiplier)
                .HasColumnName("koef")
                .IsRequired();

            HasMany(e => e.Seats)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);
        }
    }
}