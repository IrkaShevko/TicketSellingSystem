using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.DbConfiguration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        private UserConfiguration()
        {
            ToTable("Users");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired();

            Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired();

            Property(e => e.Salt)
                .HasColumnName("salt")
                .HasMaxLength(20)
                .IsRequired();

            Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(50)
                .IsOptional();

            Property(e => e.Blocked)
                .HasColumnName("blocked")
                .IsRequired();

            Property(e => e.Roles)
                .HasColumnName("roles")
                .IsRequired();

            HasMany(e => e.Recalls)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Tickets)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Votes)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}