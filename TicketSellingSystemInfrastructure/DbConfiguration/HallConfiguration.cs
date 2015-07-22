using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class HallConfiguration : EntityTypeConfiguration<Hall>
    {
        private HallConfiguration()
        {
            ToTable("Halls");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.CinemaId)
                .HasColumnName("cinema_id")
                .IsRequired();

            HasMany(e => e.Sessions)
                .WithRequired(e => e.Hall)
                .HasForeignKey(e => e.HallId)
                .WillCascadeOnDelete(false);
        }
    }
}