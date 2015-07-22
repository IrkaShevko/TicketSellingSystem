using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class FilmConfiguration : EntityTypeConfiguration<Film>
    {
        private FilmConfiguration()
        {
            ToTable("Films");
            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            Property(e => e.Duration)
                .HasColumnName("duration")
                .HasPrecision(0)
                .IsRequired();

            Property(e => e.PublishingYear)
                .HasColumnName("publishing_year")
                .HasMaxLength(4)
                .IsRequired();

            Property(e => e.Genre)
                .HasColumnName("genre")
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();

            Property(e => e.Country)
                .HasColumnName("country")
                .IsRequired();

            Property(e => e.LogoPath)
                .HasColumnName("logo_path")
                .IsOptional();

            HasMany(e => e.Recalls)
                .WithRequired(e => e.Film)
                .HasForeignKey(e => e.FilmId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Sessions)
                .WithRequired(e => e.Film)
                .HasForeignKey(e => e.FilmId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Votes)
                .WithRequired(e => e.Film)
                .HasForeignKey(e => e.FilmId)
                .WillCascadeOnDelete(false);
        }
    }
}