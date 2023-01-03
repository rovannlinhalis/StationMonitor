﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StationMonitor.Data;

namespace StationMonitor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181031013454_temperaturas")]
    partial class temperaturas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("role_name_index");

                    b.ToTable("asp_net_roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasName("ix_asp_net_role_claims_role_id");

                    b.ToTable("asp_net_role_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasName("ix_asp_net_user_claims_user_id");

                    b.ToTable("asp_net_user_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasName("ix_asp_net_user_logins_user_id");

                    b.ToTable("asp_net_user_logins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ix_asp_net_user_roles_role_id");

                    b.ToTable("asp_net_user_roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("asp_net_user_tokens");
                });

            modelBuilder.Entity("StationMonitor.Entidades.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(100);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp");

                    b.Property<Guid>("Token")
                        .HasColumnName("token");

                    b.Property<string>("TokenSenha")
                        .HasColumnName("token_senha")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasName("email_index");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("user_name_index");

                    b.HasIndex("Token", "TokenSenha")
                        .IsUnique();

                    b.ToTable("asp_net_users");
                });

            modelBuilder.Entity("StationMonitor.Entidades.Connection", b =>
                {
                    b.Property<Guid>("StationId")
                        .HasColumnName("station_id");

                    b.Property<int>("Sequence")
                        .HasColumnName("sequence");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(200);

                    b.Property<double>("Speed")
                        .HasColumnName("speed");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasMaxLength(50);

                    b.HasKey("StationId", "Sequence");

                    b.ToTable("connections");
                });

            modelBuilder.Entity("StationMonitor.Entidades.Driver", b =>
                {
                    b.Property<Guid>("StationId")
                        .HasColumnName("station_id");

                    b.Property<string>("Letter")
                        .HasColumnName("letter")
                        .HasMaxLength(5);

                    b.Property<string>("Format")
                        .HasColumnName("format")
                        .HasMaxLength(10);

                    b.Property<double>("FreeSize")
                        .HasColumnName("free_size");

                    b.Property<string>("Label")
                        .HasColumnName("label")
                        .HasMaxLength(50);

                    b.Property<double>("TotalSize")
                        .HasColumnName("total_size");

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.HasKey("StationId", "Letter");

                    b.ToTable("drivers");
                });

            modelBuilder.Entity("StationMonitor.Entidades.Event", b =>
                {
                    b.Property<Guid>("StationId")
                        .HasColumnName("station_id");

                    b.Property<int?>("Sequence")
                        .HasColumnName("sequence");

                    b.Property<double?>("CurrentTemperature")
                        .HasColumnName("current_temperature");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<string>("OSUserName")
                        .HasColumnName("osuser_name")
                        .HasMaxLength(200);

                    b.Property<string>("Process")
                        .HasColumnName("process")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(200);

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.Property<double?>("WarningTemperature")
                        .HasColumnName("warning_temperature");

                    b.Property<int?>("X")
                        .HasColumnName("x");

                    b.Property<int?>("Y")
                        .HasColumnName("y");

                    b.HasKey("StationId", "Sequence");

                    b.ToTable("events");
                });

            modelBuilder.Entity("StationMonitor.Entidades.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_groups");

                    b.HasIndex("UserId")
                        .HasName("ix_groups_user_id");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("StationMonitor.Entidades.Software", b =>
                {
                    b.Property<Guid>("StationId")
                        .HasColumnName("station_id");

                    b.Property<int>("Sequence")
                        .HasColumnName("sequence");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<string>("Manufacturer")
                        .HasColumnName("manufacturer")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(200);

                    b.HasKey("StationId", "Sequence");

                    b.ToTable("softwares");
                });

            modelBuilder.Entity("StationMonitor.Entidades.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Cpu")
                        .HasColumnName("cpu")
                        .HasMaxLength(100);

                    b.Property<Guid>("GroupId")
                        .HasColumnName("group_id");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnName("last_update");

                    b.Property<double>("Memory")
                        .HasColumnName("memory");

                    b.Property<string>("MotherBoard")
                        .HasColumnName("mother_board")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_stations");

                    b.HasIndex("GroupId")
                        .HasName("ix_stations_group_id");

                    b.HasIndex("UserId")
                        .HasName("ix_stations_user_id");

                    b.ToTable("stations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StationMonitor.Entidades.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StationMonitor.Entidades.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StationMonitor.Entidades.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StationMonitor.Entidades.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StationMonitor.Entidades.Connection", b =>
                {
                    b.HasOne("StationMonitor.Entidades.Station", "Station")
                        .WithMany("Connections")
                        .HasForeignKey("StationId")
                        .HasConstraintName("fk_connections_stations_station_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StationMonitor.Entidades.Driver", b =>
                {
                    b.HasOne("StationMonitor.Entidades.Station", "Station")
                        .WithMany("Drivers")
                        .HasForeignKey("StationId")
                        .HasConstraintName("fk_drivers_stations_station_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StationMonitor.Entidades.Event", b =>
                {
                    b.HasOne("StationMonitor.Entidades.Station", "Station")
                        .WithMany("Events")
                        .HasForeignKey("StationId")
                        .HasConstraintName("fk_events_stations_station_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StationMonitor.Entidades.Group", b =>
                {
                    b.HasOne("StationMonitor.Entidades.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_groups_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StationMonitor.Entidades.Software", b =>
                {
                    b.HasOne("StationMonitor.Entidades.Station", "Station")
                        .WithMany("Softwares")
                        .HasForeignKey("StationId")
                        .HasConstraintName("fk_softwares_stations_station_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StationMonitor.Entidades.Station", b =>
                {
                    b.HasOne("StationMonitor.Entidades.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_stations_groups_group_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StationMonitor.Entidades.ApplicationUser", "User")
                        .WithMany("Estacoes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_stations_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
