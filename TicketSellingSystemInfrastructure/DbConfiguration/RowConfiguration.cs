using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class RowConfiguration : EntityTypeConfiguration<Row>
    {
        private RowConfiguration()
        {
            ToTable("Rows");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.SchemaId)
                .HasColumnName("schema_id")
                .IsRequired();

            Property(e => e.CountSeats)
                .HasColumnName("count_seats")
                .IsRequired();

            Property(e => e.Number)
                .HasColumnName("number")
                .IsRequired();

            HasMany(e => e.Seats)
                .WithRequired(e => e.Row)
                .HasForeignKey(e => e.RowId)
                .WillCascadeOnDelete(false);
        }
    }
}