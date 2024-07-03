﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpendWise_Server.Repos.DataLayer;

#nullable disable

namespace SpendWise_Server.Repos.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpendWise_Server.Models.Currencies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Economies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Economies");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Income_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Income_Categories");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Incomes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Income_CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Reccurence")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Income_CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.Exchange", b =>
                {
                    b.Property<int>("FirstCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("SecondCurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("FirstCurrencyId", "SecondCurrencyId");

                    b.HasIndex("SecondCurrencyId");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.Expense_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Expense_Categories");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Expense_CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("Expense_CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.User_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<int>("Expense_CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Expense_CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Categories");
                });

            modelBuilder.Entity("SpendWise_Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserName", "Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SpendWise_Server.Models.Economies", b =>
                {
                    b.HasOne("SpendWise_Server.Models.User", "User")
                        .WithMany("Economies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Incomes", b =>
                {
                    b.HasOne("SpendWise_Server.Models.Income_Categories", "Income_Category")
                        .WithMany("Incomes")
                        .HasForeignKey("Income_CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SpendWise_Server.Models.User", "User")
                        .WithMany("Incomes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Income_Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.Exchange", b =>
                {
                    b.HasOne("SpendWise_Server.Models.Currencies", "FirstCurrency")
                        .WithMany("FirstExchanges")
                        .HasForeignKey("FirstCurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SpendWise_Server.Models.Currencies", "SecondCurrency")
                        .WithMany("SecondExchanges")
                        .HasForeignKey("SecondCurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FirstCurrency");

                    b.Navigation("SecondCurrency");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.Expenses", b =>
                {
                    b.HasOne("SpendWise_Server.Models.Currencies", "Currency")
                        .WithMany("Expenses")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpendWise_Server.Models.Models.Expense_Categories", "Expense_Category")
                        .WithMany("Expenses")
                        .HasForeignKey("Expense_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpendWise_Server.Models.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Expense_Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.User_Categories", b =>
                {
                    b.HasOne("SpendWise_Server.Models.Models.Expense_Categories", "Expense_Category")
                        .WithMany("User_Categories")
                        .HasForeignKey("Expense_CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SpendWise_Server.Models.User", "User")
                        .WithMany("User_Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Expense_Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpendWise_Server.Models.User", b =>
                {
                    b.HasOne("SpendWise_Server.Models.Currencies", "Currency")
                        .WithMany("Users")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Currencies", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("FirstExchanges");

                    b.Navigation("SecondExchanges");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Income_Categories", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("SpendWise_Server.Models.Models.Expense_Categories", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("User_Categories");
                });

            modelBuilder.Entity("SpendWise_Server.Models.User", b =>
                {
                    b.Navigation("Economies");

                    b.Navigation("Expenses");

                    b.Navigation("Incomes");

                    b.Navigation("User_Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
