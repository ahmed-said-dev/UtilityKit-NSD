using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Nsd.Infrastrcuture.Constants;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using System.Diagnostics;
using G2Kit.Components.Identity.Core;
using System.Reflection.Metadata;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Infrastrcuture;
public class NsdDbContext : DbContext, IUnitOfWork
{
    #region --- Constructor
    public NsdDbContext(DbContextOptions<NsdDbContext> options) : base(options) { }
    #endregion

    #region --- Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension(PostgresExtensions.UUID_AUTOGENERATE);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder //TODO : Should to delete this before go to production 
         .LogTo(message => Debug.WriteLine(message))
         .EnableDetailedErrors();
    }
    #endregion

    #region --- Register Tables
    public DbSet<Dashboard> Dashboards { get; set; }
    public DbSet<DataSource> DataSources { get; set; }
    public DbSet<Layout> Layouts { get; set; }
    public DbSet<LayoutCell> LayoutCells { get; set; }
    public DbSet<Widget> Widgets { get; set; }
    public DbSet<Chart> Charts { get; set; }
    #endregion
}