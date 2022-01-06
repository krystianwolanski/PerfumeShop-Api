using Data.Entities;
using Data.Extensions;
using Data.Models;
using Data.Models.EntityHelpers;
using FragranceShopApi.Extensions;
using FragranceShopApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FragranceShopApi
{
    public class PerfumeDbContext : DbContext
    {
        private readonly IUserContextService _userContextService;
        
        public PerfumeDbContext(
            DbContextOptions<PerfumeDbContext> options,
            IUserContextService userContextService) : base(options)
        {
            _userContextService = userContextService;
        }

        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Perfumer> Perfumers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PerfumeBrand> PerfumeBrands { get; set; }
        public DbSet<FragranceNote> FragranceNotes { get; set; }
        public DbSet<FragranceNotePerfume> FragranceNotesPerfumes { get; set; }
        public DbSet<PerfumeGenderType> PerfumeGenderTypes { get; set; }
        public DbSet<PerfumeImg> PerfumeImgs { get; set; }
        public DbSet<PerfumeReview> PerfumeReviews { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = _userContextService.User.GetUserId();
                        entry.Entity.DateCreated = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedById = _userContextService.User.GetUserId();
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(320);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Role
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
            #endregion

            #region Perfume
            modelBuilder.Entity<Perfume>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Perfume>()
                .Property(p => p.CurrentPrice)
                .IsRequired();

            modelBuilder.Entity<Perfume>()
                .Property(p => p.BasePrice)
                .IsRequired();

            modelBuilder.Entity<Perfume>()
                .Property(p => p.Quantity)
                .IsRequired();

            modelBuilder.Entity<Perfume>()
                .Property(p => p.Capacity)
                .IsRequired();

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.PerfumeGenderType)
                .WithMany(g => g.Perfumes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Perfume>()
                .HasIndex(p => p.PerfumeGenderTypeId)
                .IsClustered(false)
                .IncludeProperties(
                    nameof(Perfume.Id),
                    nameof(Perfume.Name),
                    nameof(Perfume.Year),
                    nameof(Perfume.CurrentPrice),
                    nameof(Perfume.BasePrice),
                    nameof(Perfume.Quantity),
                    nameof(Perfume.PerfumerId),
                    nameof(Perfume.PerfumeBrandId),
                    nameof(Perfume.Capacity)
                );

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.PerfumeBrand)
                .WithMany(b => b.Perfumes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Perfume>()
                .HasMany(p => p.PerfumeImgs)
                .WithOne(p => p.Perfume)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Perfume>()
                .Property(p => p.PerfumeGenderTypeId)
                .HasConversion<int>();
            #endregion

            #region PerfumeGenderType
            modelBuilder.Entity<PerfumeGenderType>()
                .Property(p => p.Id)
                .HasConversion<int>();

            modelBuilder.Entity<PerfumeGenderType>()
                .HasData(Enum.GetValues(typeof(PerfumeGenderTypeId))
                    .Cast<PerfumeGenderTypeId>()
                    .Select(e => new PerfumeGenderType()
                    {
                        Id = e,
                        Name = e.GetDescription()
                    }));
            #endregion

            #region Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region OrderStatus
            modelBuilder.Entity<OrderStatus>()
                .Property(s => s.Id)
                .HasConversion<int>();

            modelBuilder.Entity<OrderStatus>()
                .HasData(Enum.GetValues(typeof(OrderStatusId))
                    .Cast<OrderStatusId>()
                    .Select(e => new OrderStatus
                    {
                        Id = e,
                        Name = e.GetDescription()
                    }));

            modelBuilder.Entity<OrderStatus>()
                .Property(s => s.Name)
                .HasMaxLength(30);
            #endregion

            #region FragranceNoteType
            modelBuilder.Entity<FragranceNoteType>()
                .Property(p => p.FragranceNoteTypeId)
                .HasConversion<int>();

            modelBuilder.Entity<FragranceNoteType>()
                .HasData(Enum.GetValues(typeof(FragranceNoteTypeId))
                    .Cast<FragranceNoteTypeId>()
                    .Select(e => new FragranceNoteType()
                    {
                        FragranceNoteTypeId = e,
                        Name = e.GetDescription()
                    }));
            #endregion

            #region Perfumer
            modelBuilder.Entity<Perfumer>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Perfumer>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Perfumer>()
                .HasOne(p => p.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region PerfumeBrand
            modelBuilder.Entity<PerfumeBrand>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<PerfumeBrand>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<PerfumeBrand>()
                .HasOne(b => b.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region FragranceNote
            modelBuilder.Entity<FragranceNote>()
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(30);
            #endregion

            #region FragranceNotePerfume

            modelBuilder.Entity<FragranceNotePerfume>()
                .HasIndex(fp => new
                {
                    fp.FragranceNoteId,
                    fp.FragranceNoteTypeId,
                    fp.PerfumeId,
                }).IsUnique();

            modelBuilder.Entity<FragranceNotePerfume>()
                .HasOne(fp => fp.FragranceNoteType)
                .WithMany(ft => ft.FragranceNotePerfumes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FragranceNotePerfume>()
                .HasOne(fp => fp.FragranceNote)
                .WithMany(ft => ft.FragranceNotesPerfumes)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region PerfumeReview
            modelBuilder.Entity<PerfumeReview>()
                .Property(r => r.Review)
                .HasMaxLength(6000);

            modelBuilder.Entity<PerfumeReview>()
                .HasOne(r => r.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
