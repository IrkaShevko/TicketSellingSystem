using System.Data.Entity;
using System.Reflection;
using TicketSellingSystemInfrastructure.DbConfiguration;
using TicketSellingSystemInfrastructure.Models.EFModels;

namespace TicketSellingSystemInfrastructure.Context
{
    public class TicketSellingSystemContext : DbContext
    {
        public TicketSellingSystemContext()
            : base("name=TicketSellingSystemContext")
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Recall> Recalls { get; set; }
        public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<SeatType> SeaTypes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionSeat> SessionsSeats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Configurations
                .AddFromAssembly(Assembly.GetAssembly(typeof(CinemaConfiguration)));
        }
    }
}