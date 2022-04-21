using BuildingSiteManagementWebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingSiteManagementWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable("Users")
                    .Property(u => u.NationalId).IsRequired();
                entity.HasIndex(u => u.NationalId).IsUnique();
                entity.Property(u => u.Name).IsRequired();
                entity.Property(u => u.LastName).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
                //entity.Navigation(u => new { u.OwnedResidences, u.RentedResidences }).AutoInclude();
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });


            builder.Entity<Building>(entity =>
            {
                entity.ToTable("Buildings")
                    .Property(b => b.NumberOfFloors).IsRequired();
                entity.HasIndex(b => b.Name).IsUnique();
                entity.Navigation(b => b.Residences).AutoInclude();
            });
            builder.Entity<HomeType>(entity =>
            {
                entity.ToTable("HomeTypes")
                    .Property(h => h.Name).IsRequired();
                entity.HasIndex(h => h.Name).HasFilter("Name IS NOT NULL").IsUnique();
            });
            builder.Entity<Message>(entity =>
            {
                entity.ToTable("Messages")
                    .Property(m => m.Subject).IsRequired();
                entity.Property(m => m.ReceiverId).IsRequired();
                entity.Property(m => m.SenderId).IsRequired();
                entity.HasOne(m => m.Sender).WithMany(u => u.SentMessages).HasForeignKey(m => m.SenderId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(m => m.Receiver).WithMany(u => u.ReceivedMessages).HasForeignKey(m => m.ReceiverId).OnDelete(DeleteBehavior.NoAction);

            });
            builder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments")
                    .Property(p => p.UserId).IsRequired();
                entity.Navigation(p => p.User).AutoInclude();
                entity.Navigation(p => p.Invoice).AutoInclude();
            });
            builder.Entity<Residence>(entity =>
            {
                entity.ToTable("Residences")
                    .HasOne(r => r.Owner).WithMany(u => u.OwnedResidences).HasForeignKey(r => r.OwnerId).OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(r => r.User).WithMany(u => u.RentedResidences).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(r => r.Building).WithMany(b => b.Residences).OnDelete(DeleteBehavior.Restrict);
                //entity.Navigation(r => new { r.Owner, r.Building, r.User, r.ResidenceType }).AutoInclude();
                entity.Navigation(r => r.Owner).AutoInclude();
                entity.Navigation(r => r.Building).AutoInclude();
                entity.Navigation(r => r.User).AutoInclude();
                entity.Navigation(r => r.ResidenceType).AutoInclude();

            });
            builder.Entity<ResidenceInvoice>(entity =>
            {
                entity.ToTable("ResidenceInvoices");
                entity.Navigation(e => e.Residence).AutoInclude();
            });
            builder.Entity<ResidenceType>(entity =>
            {
                entity.ToTable("ResidenceTypes").Navigation(e => e.HomeType).AutoInclude();
            });
            builder.Entity<Resident>(entity =>
            {
                entity.ToTable("Residents"); //.Navigation(r => new { r.RentedResidences, r.OwnedResidences, r.Residence }).AutoInclude();
            });
            builder.Entity<SiteInvoice>(entity =>
            {
                entity.ToTable("SiteInvoices")
                    .Property(s => s.Payee).IsRequired();
            });
            builder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicles")
                    .Property(v => v.Plate).IsRequired();
                entity.HasIndex(v => v.Plate).IsUnique();
                entity.Navigation(v => v.Resident).AutoInclude();
            });
            builder.Entity<BaseInvoice>(entity =>
            {
                entity.ToTable("BaseInvoices")
                    .Property(bi => bi.InvAmount).HasColumnType("decimal").HasPrecision(10,2);
            });
        }
    }
}
