﻿// <auto-generated />
using API_PDS.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_PDS.Migrations
{
    [DbContext(typeof(CondoSocialContext))]
    [Migration("20250406175722_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_PDS.Model.CodigoPostal", b =>
                {
                    b.Property<string>("CP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CP");

                    b.ToTable("CodigoPostal");
                });

            modelBuilder.Entity("API_PDS.Model.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CP")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CP");

                    b.ToTable("Condominios");
                });

            modelBuilder.Entity("API_PDS.Model.ContactoEmergencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("ContactosEmergencia");
                });

            modelBuilder.Entity("API_PDS.Model.GestorCondominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("GestoresCondominio");
                });

            modelBuilder.Entity("API_PDS.Model.Utilizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<int>("GestorCondominioId")
                        .HasColumnType("int");

                    b.Property<int>("NPorta")
                        .HasColumnType("int");

                    b.Property<int>("Nif")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.HasIndex("GestorCondominioId");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("API_PDS.Model.Condominio", b =>
                {
                    b.HasOne("API_PDS.Model.CodigoPostal", "CodigoPostal")
                        .WithMany("Condominios")
                        .HasForeignKey("CP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CodigoPostal");
                });

            modelBuilder.Entity("API_PDS.Model.ContactoEmergencia", b =>
                {
                    b.HasOne("API_PDS.Model.Condominio", "Condominio")
                        .WithMany("ContactosEmergencia")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("API_PDS.Model.GestorCondominio", b =>
                {
                    b.HasOne("API_PDS.Model.Condominio", "Condominio")
                        .WithMany("GestoresCondominio")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Utilizador", b =>
                {
                    b.HasOne("API_PDS.Model.Condominio", "Condominio")
                        .WithMany("Utilizadores")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.GestorCondominio", "GestorCondominio")
                        .WithMany()
                        .HasForeignKey("GestorCondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");

                    b.Navigation("GestorCondominio");
                });

            modelBuilder.Entity("API_PDS.Model.CodigoPostal", b =>
                {
                    b.Navigation("Condominios");
                });

            modelBuilder.Entity("API_PDS.Model.Condominio", b =>
                {
                    b.Navigation("ContactosEmergencia");

                    b.Navigation("GestoresCondominio");

                    b.Navigation("Utilizadores");
                });
#pragma warning restore 612, 618
        }
    }
}
