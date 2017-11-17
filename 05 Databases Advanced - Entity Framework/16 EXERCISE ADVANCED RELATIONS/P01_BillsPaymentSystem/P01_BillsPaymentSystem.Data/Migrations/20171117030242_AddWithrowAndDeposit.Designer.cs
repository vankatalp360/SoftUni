﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using P01_BillsPaymentMethodsystem.Data;
using P01_BillsPaymentMethodsystem.Data.Models;
using System;

namespace P01_BillsPaymentSystem.Data.Migrations
{
    [DbContext(typeof(BillsPaymentSystemContext))]
    [Migration("20171117030242_AddWithrowAndDeposit")]
    partial class AddWithrowAndDeposit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P01_BillsPaymentMethodsystem.Data.Models.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("SwiftCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("BankAccountId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("P01_BillsPaymentMethodsystem.Data.Models.CreditCard", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<decimal>("Limit");

                    b.Property<decimal>("MoneyOwed");

                    b.HasKey("CreditCardId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("P01_BillsPaymentMethodsystem.Data.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BankAccountId");

                    b.Property<int?>("CreditCardId");

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId")
                        .IsUnique()
                        .HasFilter("[BankAccountId] IS NOT NULL");

                    b.HasIndex("CreditCardId")
                        .IsUnique()
                        .HasFilter("[CreditCardId] IS NOT NULL");

                    b.HasIndex("UserId", "BankAccountId", "CreditCardId")
                        .IsUnique()
                        .HasFilter("[BankAccountId] IS NOT NULL AND [CreditCardId] IS NOT NULL");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("P01_BillsPaymentMethodsystem.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("P01_BillsPaymentMethodsystem.Data.Models.PaymentMethod", b =>
                {
                    b.HasOne("P01_BillsPaymentMethodsystem.Data.Models.BankAccount", "BankAccount")
                        .WithOne("PaymentMethod")
                        .HasForeignKey("P01_BillsPaymentMethodsystem.Data.Models.PaymentMethod", "BankAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P01_BillsPaymentMethodsystem.Data.Models.CreditCard", "CreditCard")
                        .WithOne("PaymentMethod")
                        .HasForeignKey("P01_BillsPaymentMethodsystem.Data.Models.PaymentMethod", "CreditCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P01_BillsPaymentMethodsystem.Data.Models.User", "User")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
