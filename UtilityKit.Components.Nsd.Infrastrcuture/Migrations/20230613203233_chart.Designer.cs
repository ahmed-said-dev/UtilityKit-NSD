﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UtilityKit.Components.Nsd.Infrastrcuture;

#nullable disable

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations
{
    [DbContext(typeof(NsdDbContext))]
    [Migration("20230613203233_chart")]
    partial class chart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Chart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssetGroup")
                        .HasColumnType("integer");

                    b.Property<string>("AssetTableName")
                        .HasColumnType("text");

                    b.Property<string>("AssetType")
                        .HasColumnType("text");

                    b.Property<string>("CityId")
                        .HasColumnType("text");

                    b.Property<string>("DomainName")
                        .HasColumnType("text");

                    b.Property<string>("GovId")
                        .HasColumnType("text");

                    b.Property<int>("IsBasic")
                        .HasColumnType("integer");

                    b.Property<int>("TotalLength")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Dashboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DataSourceId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("LayoutId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("DataSourceId");

                    b.HasIndex("LayoutId");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.DataSource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConnectionDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("DataSources");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Layout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LayoutsDescriptions")
                        .HasColumnType("jsonb");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Layouts");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.LayoutCell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CellSize")
                        .HasColumnType("integer");

                    b.Property<string>("CellsDefinition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Configurations")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("DashboardId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WidgetId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.HasIndex("WidgetId");

                    b.ToTable("LayoutCells");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Widget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConfigurationDefinitions")
                        .HasColumnType("jsonb");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int[]>("Industries")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MinCellSize")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WidgetFileSource")
                        .HasColumnType("text");

                    b.Property<bool>("isBuiltIn")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Dashboard", b =>
                {
                    b.HasOne("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.DataSource", "DataSource")
                        .WithMany("Dashboards")
                        .HasForeignKey("DataSourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Layout", "Layout")
                        .WithMany("Dashboards")
                        .HasForeignKey("LayoutId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DataSource");

                    b.Navigation("Layout");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.LayoutCell", b =>
                {
                    b.HasOne("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Dashboard", "Dashboard")
                        .WithMany("layoutCells")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Widget", "Widget")
                        .WithMany("LayoutCells")
                        .HasForeignKey("WidgetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dashboard");

                    b.Navigation("Widget");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Dashboard", b =>
                {
                    b.Navigation("layoutCells");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.DataSource", b =>
                {
                    b.Navigation("Dashboards");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Layout", b =>
                {
                    b.Navigation("Dashboards");
                });

            modelBuilder.Entity("UtilityKit.Components.Nsd.Domain.BusinessModel.Entities.Widget", b =>
                {
                    b.Navigation("LayoutCells");
                });
#pragma warning restore 612, 618
        }
    }
}
