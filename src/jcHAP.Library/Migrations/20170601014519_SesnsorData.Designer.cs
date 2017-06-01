using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using jcHAP.Library.DAL.SQLite;
using jcHAP.Library.Enums;

namespace jcHAP.Library.Migrations
{
    [DbContext(typeof(SQLiteDAL))]
    [Migration("20170601014519_SesnsorData")]
    partial class SesnsorData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("jcHAP.Library.DAL.SQLite.Tables.Dashboard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DashboardName");

                    b.Property<string>("JSON");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<DateTime>("Modified");

                    b.HasKey("ID");

                    b.ToTable("Dashboard");
                });

            modelBuilder.Entity("jcHAP.Library.DAL.SQLite.Tables.SensorData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("JSONData");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("SensorName");

                    b.HasKey("ID");

                    b.ToTable("SensoeData");
                });

            modelBuilder.Entity("jcHAP.Library.DAL.SQLite.Tables.Settings", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("HelpLabel");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("SettingsFieldType");

                    b.Property<string>("TitleLabel");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.ToTable("Settings");
                });
        }
    }
}
