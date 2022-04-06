﻿// <auto-generated />
using ApiSMRv4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiSMRv4.Migrations
{
    [DbContext(typeof(ApiSMRv4Context))]
    [Migration("20220406064732_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiSMRv4.Models.Clientes", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProfesionalRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.Property<string>("mainChallenges")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApiSMRv4.Models.Elementos", b =>
                {
                    b.Property<string>("Elemento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tipoPregunta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Elemento");

                    b.HasIndex("IdPregunta");

                    b.ToTable("Elementos");
                });

            modelBuilder.Entity("ApiSMRv4.Models.Preguntas", b =>
                {
                    b.Property<string>("PreguntaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pregunta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subdimension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoPregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PreguntaId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("ApiSMRv4.Models.PreguntasTabla", b =>
                {
                    b.Property<string>("ElementoPregunta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ElementoPregunta");

                    b.HasIndex("IdPregunta");

                    b.ToTable("PreguntasTabla");
                });

            modelBuilder.Entity("ApiSMRv4.Models.Respuestas", b =>
                {
                    b.Property<int>("IdRespuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Respuesta")
                        .HasColumnType("int");

                    b.HasKey("IdRespuesta");

                    b.HasIndex("Email");

                    b.HasIndex("IdPregunta");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("ApiSMRv4.Models.Elementos", b =>
                {
                    b.HasOne("ApiSMRv4.Models.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("IdPregunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preguntas");
                });

            modelBuilder.Entity("ApiSMRv4.Models.PreguntasTabla", b =>
                {
                    b.HasOne("ApiSMRv4.Models.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("IdPregunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preguntas");
                });

            modelBuilder.Entity("ApiSMRv4.Models.Respuestas", b =>
                {
                    b.HasOne("ApiSMRv4.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiSMRv4.Models.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("IdPregunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Preguntas");
                });
#pragma warning restore 612, 618
        }
    }
}
