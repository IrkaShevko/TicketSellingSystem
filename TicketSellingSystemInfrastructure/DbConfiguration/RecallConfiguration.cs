using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class RecallConfiguration : EntityTypeConfiguration<Recall>
    {
        private RecallConfiguration()
        {
            ToTable("Recalls");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            Property(e => e.Text)
                .HasColumnName("text")
                .HasColumnType("ntext")
                .IsRequired();

            Property(e => e.FilmId)
                .HasColumnName("film_id")
                .IsRequired();
        }
    }
}