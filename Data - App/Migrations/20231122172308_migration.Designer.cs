﻿// <auto-generated />
using Data___App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data___App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231122172308_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Data___App.Entities.CarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Moc")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("NrRejestracyjny")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PojemnoscSilnika")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Priorytet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Producent")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("RodzajSilnika")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("Wlasciciel")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Moc = 2,
                            Model = "Octavia",
                            NrRejestracyjny = "TNB",
                            OrganizationId = 1,
                            PojemnoscSilnika = 2m,
                            Priorytet = (byte)2,
                            Producent = "Skoda",
                            RodzajSilnika = "tdi",
                            Wlasciciel = "Wlasciciel"
                        },
                        new
                        {
                            Id = 2,
                            Moc = 3,
                            Model = "Astra",
                            NrRejestracyjny = "KDA",
                            OrganizationId = 2,
                            PojemnoscSilnika = 2m,
                            Priorytet = (byte)2,
                            Producent = "Opel",
                            RodzajSilnika = "tdi",
                            Wlasciciel = "Wlasciciel2"
                        });
                });

            modelBuilder.Entity("Data___App.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nip = "83492384",
                            Region = "13424234",
                            Tytul = "WSEI"
                        },
                        new
                        {
                            Id = 2,
                            Nip = "2498534",
                            Region = "0873439249",
                            Tytul = "Firma"
                        });
                });

            modelBuilder.Entity("Data___App.Entities.CarEntity", b =>
                {
                    b.HasOne("Data___App.Entities.OrganizationEntity", "Organization")
                        .WithMany("Cars")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data___App.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("Data___App.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("KodPocztowy")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Miasto")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Ulica")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    KodPocztowy = "31-150",
                                    Miasto = "Kraków",
                                    Region = "małopolskie",
                                    Ulica = "Św. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    KodPocztowy = "31-150",
                                    Miasto = "Kraków",
                                    Region = "małopolskie",
                                    Ulica = "Krowoderska 45/6"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data___App.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
