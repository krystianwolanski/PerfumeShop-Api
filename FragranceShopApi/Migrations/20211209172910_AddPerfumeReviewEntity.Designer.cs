// <auto-generated />
using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FragranceShopApi.Migrations
{
    [DbContext(typeof(PerfumeDbContext))]
    [Migration("20211209172910_AddPerfumeReviewEntity")]
    partial class AddPerfumeReviewEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("FragranceNotes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNotePerfume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FragranceNoteId")
                        .HasColumnType("int");

                    b.Property<int>("FragranceNoteTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PerfumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FragranceNoteTypeId");

                    b.HasIndex("PerfumeId");

                    b.HasIndex("FragranceNoteId", "FragranceNoteTypeId", "PerfumeId")
                        .IsUnique();

                    b.ToTable("FragranceNotesPerfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNoteType", b =>
                {
                    b.Property<int>("FragranceNoteTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FragranceNoteTypeId");

                    b.ToTable("FragranceNoteType");

                    b.HasData(
                        new
                        {
                            FragranceNoteTypeId = 1,
                            Name = "Nuty głowy"
                        },
                        new
                        {
                            FragranceNoteTypeId = 2,
                            Name = "Nuty serca"
                        },
                        new
                        {
                            FragranceNoteTypeId = 3,
                            Name = "Nuty bazy"
                        });
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Perfume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PerfumeBrandId")
                        .HasColumnType("int");

                    b.Property<int>("PerfumeGenderTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PerfumerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PerfumeBrandId");

                    b.HasIndex("PerfumeGenderTypeId")
                        .IsClustered(false)
                        .HasAnnotation("SqlServer:Include", new[] { "Id", "Name", "Year", "CurrentPrice", "BasePrice", "Quantity", "PerfumerId", "PerfumeBrandId", "Capacity" });

                    b.HasIndex("PerfumerId");

                    b.ToTable("Perfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PerfumeBrands");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeGenderType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PerfumeGenderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Męski"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Damski"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Unisex"
                        });
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<int>("PerfumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfumeId");

                    b.ToTable("PerfumeImgs");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("PerfumeId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PerfumeId");

                    b.ToTable("PerfumeReviews");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Perfumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Perfumers");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNote", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNotePerfume", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.FragranceNote", "FragranceNote")
                        .WithMany("FragranceNotesPerfumes")
                        .HasForeignKey("FragranceNoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FragranceShopApi.Entities.FragranceNoteType", "FragranceNoteType")
                        .WithMany("FragranceNotePerfumes")
                        .HasForeignKey("FragranceNoteTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FragranceShopApi.Entities.Perfume", "Perfume")
                        .WithMany("FragranceNotesPerfumes")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FragranceNote");

                    b.Navigation("FragranceNoteType");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Perfume", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("FragranceShopApi.Entities.PerfumeBrand", "PerfumeBrand")
                        .WithMany("Perfumes")
                        .HasForeignKey("PerfumeBrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FragranceShopApi.Entities.PerfumeGenderType", "PerfumeGenderType")
                        .WithMany("Perfumes")
                        .HasForeignKey("PerfumeGenderTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FragranceShopApi.Entities.Perfumer", "Perfumer")
                        .WithMany("Perfumes")
                        .HasForeignKey("PerfumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("PerfumeBrand");

                    b.Navigation("PerfumeGenderType");

                    b.Navigation("Perfumer");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeBrand", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeImg", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.Perfume", "Perfume")
                        .WithMany("PerfumeImgs")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeReview", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FragranceShopApi.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("FragranceShopApi.Entities.Perfume", "Perfume")
                        .WithMany()
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("CreatedBy");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Perfumer", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.User", b =>
                {
                    b.HasOne("FragranceShopApi.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNote", b =>
                {
                    b.Navigation("FragranceNotesPerfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.FragranceNoteType", b =>
                {
                    b.Navigation("FragranceNotePerfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Perfume", b =>
                {
                    b.Navigation("FragranceNotesPerfumes");

                    b.Navigation("PerfumeImgs");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeBrand", b =>
                {
                    b.Navigation("Perfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.PerfumeGenderType", b =>
                {
                    b.Navigation("Perfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Perfumer", b =>
                {
                    b.Navigation("Perfumes");
                });

            modelBuilder.Entity("FragranceShopApi.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
