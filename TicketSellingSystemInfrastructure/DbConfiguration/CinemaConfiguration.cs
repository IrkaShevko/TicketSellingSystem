using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class CinemaConfiguration : EntityTypeConfiguration<Cinema>
    {
        private CinemaConfiguration()
        {
            ToTable("Cinemas");

            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired();

            Property(c => c.Name)
                .HasColumnName("address")
                .IsRequired();

            Property(c => c.LogoPath)
                .HasColumnName("logo_path")
                .IsOptional();

            HasMany(e => e.Films)
                .WithMany(e => e.Cinemas)
                .Map(e =>
                {
                    e.MapLeftKey("film_id");
                    e.MapRightKey("cinema_id");
                    e.ToTable("FilmsInCinemas");
                });

            HasMany(e => e.Halls)
                .WithRequired(e => e.Cinema)
                .HasForeignKey(e => e.CinemaId)
                .WillCascadeOnDelete(false);
        }
    }
}