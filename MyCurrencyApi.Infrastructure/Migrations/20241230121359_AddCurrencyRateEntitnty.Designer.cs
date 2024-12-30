﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCurrencyApi.Infrastructure.DAL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyCurrencyApi.Infrastructure.Migrations
{
    [DbContext(typeof(CurrencyRateDbContext))]
    [Migration("20241230121359_AddCurrencyRateEntitnty")]
    partial class AddCurrencyRateEntitnty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyCurrencyApi.Domain.Entities.CurrencyRate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyRates");

                    b.HasDiscriminator().HasValue("CurrencyRate");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MyCurrencyApi.Domain.Entities.AskRate", b =>
                {
                    b.HasBaseType("MyCurrencyApi.Domain.Entities.CurrencyRate");

                    b.HasDiscriminator().HasValue("AskRate");
                });

            modelBuilder.Entity("MyCurrencyApi.Domain.Entities.BidRate", b =>
                {
                    b.HasBaseType("MyCurrencyApi.Domain.Entities.CurrencyRate");

                    b.HasDiscriminator().HasValue("BidRate");
                });

            modelBuilder.Entity("MyCurrencyApi.Domain.Entities.CurrencyRate", b =>
                {
                    b.OwnsOne("MyCurrencyApi.Domain.ValueObjects.Money", "Money", b1 =>
                        {
                            b1.Property<Guid>("CurrencyRateId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("Amount");

                            b1.HasKey("CurrencyRateId");

                            b1.ToTable("CurrencyRates");

                            b1.WithOwner()
                                .HasForeignKey("CurrencyRateId");

                            b1.OwnsOne("MyCurrencyApi.Domain.ValueObjects.Currency", "Currency", b2 =>
                                {
                                    b2.Property<Guid>("MoneyCurrencyRateId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("text")
                                        .HasColumnName("CurrencyCode");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text")
                                        .HasColumnName("CurrencyName");

                                    b2.HasKey("MoneyCurrencyRateId");

                                    b2.ToTable("CurrencyRates");

                                    b2.WithOwner()
                                        .HasForeignKey("MoneyCurrencyRateId");
                                });

                            b1.Navigation("Currency")
                                .IsRequired();
                        });

                    b.Navigation("Money")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}