using System.Configuration;
using System.Reflection.Emit;
using Disaster_Management_system.Models.AdminModels;
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data;

public class DMSDbContext : IdentityDbContext<ApplicationUser>
{
   
    public DMSDbContext(DbContextOptions<DMSDbContext> options)
        : base(options)
    {
       
    }


    public DbSet<LocationViewModel> Locations { get; set; }
    public DbSet<VictimViewModel> Victims { get; set; }
    public DbSet<PhotosViewModel> Photos { get; set; }
    public DbSet<DisasterViewModel> Disasters { get; set; }
    public DbSet<DisasterCategoryViewModel> DisasterCategory { get; set; }
   
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<LocationViewModel>(entity =>
        {
            entity.ToTable("user_location");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Province).IsRequired();
            entity.Property(e => e.District).IsRequired();
            entity.Property(e => e.Municipality).IsRequired();
            entity.Property(e => e.Ward).IsRequired();
            entity.Property(e => e.Tole).IsRequired();
           entity.HasOne(p => p.user)
              .WithMany(v => v.Locations)
              .HasForeignKey(p => p.user_id)
              .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Victim)
          .WithMany(v => v.Locations)
          .HasForeignKey(p => p.VictimId)
          .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<VictimViewModel>(entity =>
        {
            entity.ToTable("victims");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Age).IsRequired();
            entity.Property(e => e.Gender).IsRequired();
            entity.Property(e => e.ContactNumber).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.HasOne(p => p.user)
             .WithMany(v => v.Victims)
             .HasForeignKey(p => p.user_id)
             .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<DisasterViewModel>(entity =>
        {
            entity.ToTable("disasters");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.Severity).IsRequired();
            entity.Property(e => e.Date_Occured).IsRequired();
            entity.HasOne(p => p.user)
             .WithMany(v => v.Disasters)
             .HasForeignKey(p => p.user_id)
             .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Victim)
           .WithMany(v => v.Disasters)
           .HasForeignKey(p => p.VictimId)
           .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<PhotosViewModel>(entity =>
        {
            entity.ToTable("photos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Url).IsRequired();
            entity.HasOne(p => p.user)
                  .WithMany(v => v.Photos)
                  .HasForeignKey(p => p.user_id);
        });

        builder.Entity<DisasterCategoryViewModel>(entity =>
        {
            entity.ToTable("disasterCategory");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Severity).IsRequired();
            entity.Property(e => e.CreatedDate).IsRequired();

        });

    }
}
