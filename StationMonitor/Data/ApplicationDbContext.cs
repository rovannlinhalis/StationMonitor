using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StationInterface.Extensions;
using StationMonitor.Entidades;

namespace StationMonitor.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Convencoes de Nomenclatura
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Name.ToSnakeCase();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
            }
            #endregion



            builder.Entity<ApplicationUser>().Property(x => x.Id).HasMaxLength(100);
            builder.Entity<ApplicationUser>().Property(x => x.Id).HasColumnName("Id");
            builder.Entity<ApplicationUser>().HasIndex(x => new { x.Token, x.TokenSenha }).IsUnique();
            //builder.Entity<ApplicationUser>().HasMany(h => (IEnumerable<Estacao>)h.Estacoes).WithOne();//.HasForeignKey(x => x.Id);

            builder.Entity<Event>().HasKey(x => new { x.StationId, x.Sequence });
            builder.Entity<Driver>().HasKey(x => new { x.StationId, x.Letter });
            builder.Entity<Software>().HasKey(x => new { x.StationId, x.Sequence });
            builder.Entity<Connection>().HasKey(x => new { x.StationId, x.Sequence });

            //builder.Entity<Evento>().HasOne(x => x.Estacao).WithMany().HasForeignKey(x => x.Estacao.Id);
        }


        public DbSet<StationMonitor.Entidades.Station> Stations { get; set; }
        public DbSet<StationMonitor.Entidades.Event> Events { get; set; }
        public DbSet<StationMonitor.Entidades.Driver> Drivers { get; set; }
        public DbSet<StationMonitor.Entidades.Software> Softwares { get; set; }
        public DbSet<StationMonitor.Entidades.Connection> Connections { get; set; }
        public DbSet<StationMonitor.Entidades.Group> Groups { get; set; }
    }
}

