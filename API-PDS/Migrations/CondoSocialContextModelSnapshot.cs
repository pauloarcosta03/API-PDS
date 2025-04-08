﻿// <auto-generated />
using System;
using API_PDS.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_PDS.Migrations
{
    [DbContext(typeof(CondoSocialContext))]
    partial class CondoSocialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("API_PDS.Model.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Comentario");
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

            modelBuilder.Entity("API_PDS.Model.Contacto", b =>
                {
                    b.Property<int>("Descricao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Descricao"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Descricao");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Contactos");
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

            modelBuilder.Entity("API_PDS.Model.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<int>("GestorCondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.HasIndex("GestorCondominioId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Incidencias");
                });

            modelBuilder.Entity("API_PDS.Model.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("API_PDS.Model.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("API_PDS.Model.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncidenciaId")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ReuniaoId")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.Property<bool>("Vista")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IncidenciaId");

                    b.HasIndex("PostId");

                    b.HasIndex("ReuniaoId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Notificacao");
                });

            modelBuilder.Entity("API_PDS.Model.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Confirma")
                        .HasColumnType("bit");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Participante");
                });

            modelBuilder.Entity("API_PDS.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aceite")
                        .HasColumnType("bit");

                    b.Property<int>("GestorCondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GestorCondominioId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("API_PDS.Model.Reuniao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GestorCondominioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GestorCondominioId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Reunioes");
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

                    b.Property<int>("LoginId")
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

                    b.HasIndex("LoginId");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("API_PDS.Model.Comentario", b =>
                {
                    b.HasOne("API_PDS.Model.Post", "Post")
                        .WithMany("Comentarios")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Comentarios")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Utilizador");
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

            modelBuilder.Entity("API_PDS.Model.Contacto", b =>
                {
                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Contactos")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
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

            modelBuilder.Entity("API_PDS.Model.Incidencia", b =>
                {
                    b.HasOne("API_PDS.Model.Condominio", "Condominio")
                        .WithMany("Incidencias")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.GestorCondominio", "GestorCondominio")
                        .WithMany("Incidencias")
                        .HasForeignKey("GestorCondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Incidencias")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");

                    b.Navigation("GestorCondominio");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Like", b =>
                {
                    b.HasOne("API_PDS.Model.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Likes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Login", b =>
                {
                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Notificacao", b =>
                {
                    b.HasOne("API_PDS.Model.Incidencia", "Incidencia")
                        .WithMany("Notificacoes")
                        .HasForeignKey("IncidenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Post", "Post")
                        .WithMany("Notificacoes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Reuniao", "Reuniao")
                        .WithMany("Notificacoes")
                        .HasForeignKey("ReuniaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Notificacoes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incidencia");

                    b.Navigation("Post");

                    b.Navigation("Reuniao");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Participante", b =>
                {
                    b.HasOne("API_PDS.Model.Post", "Post")
                        .WithMany("Participantes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Participantes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Post", b =>
                {
                    b.HasOne("API_PDS.Model.GestorCondominio", "GestorCondominio")
                        .WithMany("Posts")
                        .HasForeignKey("GestorCondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Posts")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GestorCondominio");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("API_PDS.Model.Reuniao", b =>
                {
                    b.HasOne("API_PDS.Model.GestorCondominio", "GestorCondominio")
                        .WithMany("Reunioes")
                        .HasForeignKey("GestorCondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PDS.Model.Utilizador", "Utilizador")
                        .WithMany("Reunioes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GestorCondominio");

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

                    b.HasOne("API_PDS.Model.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");

                    b.Navigation("GestorCondominio");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("API_PDS.Model.CodigoPostal", b =>
                {
                    b.Navigation("Condominios");
                });

            modelBuilder.Entity("API_PDS.Model.Condominio", b =>
                {
                    b.Navigation("ContactosEmergencia");

                    b.Navigation("GestoresCondominio");

                    b.Navigation("Incidencias");

                    b.Navigation("Utilizadores");
                });

            modelBuilder.Entity("API_PDS.Model.GestorCondominio", b =>
                {
                    b.Navigation("Incidencias");

                    b.Navigation("Posts");

                    b.Navigation("Reunioes");
                });

            modelBuilder.Entity("API_PDS.Model.Incidencia", b =>
                {
                    b.Navigation("Notificacoes");
                });

            modelBuilder.Entity("API_PDS.Model.Post", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Likes");

                    b.Navigation("Notificacoes");

                    b.Navigation("Participantes");
                });

            modelBuilder.Entity("API_PDS.Model.Reuniao", b =>
                {
                    b.Navigation("Notificacoes");
                });

            modelBuilder.Entity("API_PDS.Model.Utilizador", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Contactos");

                    b.Navigation("Incidencias");

                    b.Navigation("Likes");

                    b.Navigation("Notificacoes");

                    b.Navigation("Participantes");

                    b.Navigation("Posts");

                    b.Navigation("Reunioes");
                });
#pragma warning restore 612, 618
        }
    }
}
