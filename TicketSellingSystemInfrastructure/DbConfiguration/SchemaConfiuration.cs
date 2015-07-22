using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class SchemaConfiuration : EntityTypeConfiguration<Schema>
    {
        private SchemaConfiuration()
        {
            ToTable("Schema");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.HallId)
                .HasColumnName("hall_id")
                .IsRequired();

            Property(e => e.OverallCountSeats)
                .HasColumnName("overall_count_seats")
                .IsRequired();

            HasRequired(e => e.Hall)
                .WithRequiredDependent(e => e.Schema);

            HasMany(e => e.Rows)
                .WithRequired(e => e.Schema)
                .HasForeignKey(e => e.SchemaId)
                .WillCascadeOnDelete(false);
        }
    }
}