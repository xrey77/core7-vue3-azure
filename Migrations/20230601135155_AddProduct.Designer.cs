﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using core7_vue3_azure.Helpers;

#nullable disable

namespace core7_vue3_azure.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230601135155_AddProduct")]
    partial class AddProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("core7_vue3_azure.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("alert_level")
                        .HasColumnType("int")
                        .HasColumnName("alert_level");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category");

                    b.Property<decimal>("cost_price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("cost_price");

                    b.Property<int>("critical_level")
                        .HasColumnType("int")
                        .HasColumnName("critical_level");

                    b.Property<DateTime>("datecreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("datecreated");

                    b.Property<DateTime>("dateupdated")
                        .HasColumnType("datetime2")
                        .HasColumnName("dateupdated");

                    b.Property<string>("descriptions")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descriptions");

                    b.Property<string>("prod_pic")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("prod_pic");

                    b.Property<int>("qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.Property<decimal>("sale_price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("sale_price");

                    b.Property<decimal>("sell_price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("sell_price");

                    b.Property<string>("unit")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("unit");

                    b.HasKey("id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("core7_vue3_azure.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_created")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("Date_updated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_updated");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstname");

                    b.Property<int>("Isactivated")
                        .HasColumnType("int")
                        .HasColumnName("isactivated");

                    b.Property<int>("Isblocked")
                        .HasColumnType("int")
                        .HasColumnName("isblocked");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastname");

                    b.Property<int>("Mailtoken")
                        .HasColumnType("int")
                        .HasColumnName("mailtoken");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mobile");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Profilepic")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("profilepic");

                    b.Property<string>("Qrcodeurl")
                        .HasColumnType("ntext")
                        .HasColumnName("qrcodeurl");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("roles");

                    b.Property<string>("Secretkey")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("secretkey");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
