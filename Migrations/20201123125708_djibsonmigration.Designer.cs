﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using foots.Models;

namespace foots.Migrations
{
    [DbContext(typeof(DjibsonContext))]
    [Migration("20201123125708_djibsonmigration")]
    partial class djibsonmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("foots.Models.Amis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdAmis")
                        .HasColumnName("id_amis")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdMembre")
                        .HasColumnName("id_membre")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("IdAmis")
                        .HasName("id_amis");

                    b.HasIndex("IdMembre")
                        .HasName("ids");

                    b.ToTable("amis");
                });

            modelBuilder.Entity("foots.Models.Membre", b =>
                {
                    b.Property<int>("IdMembres")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_membres")
                        .HasColumnType("int(255)");

                    b.Property<string>("Equipe")
                        .HasColumnName("equipe")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Login")
                        .HasColumnName("login")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("MotPasses")
                        .IsRequired()
                        .HasColumnName("mot_passes")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Nom")
                        .HasColumnName("nom")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Poste")
                        .HasColumnName("poste")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Prenom")
                        .HasColumnName("prenom")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdMembres")
                        .HasName("PRIMARY");

                    b.ToTable("membre");
                });

            modelBuilder.Entity("foots.Models.MessageRecu", b =>
                {
                    b.Property<int>("Ids")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ids")
                        .HasColumnType("int(11)");

                    b.Property<string>("Destinataire")
                        .IsRequired()
                        .HasColumnName("destinataire")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("Expediteur")
                        .HasColumnName("expediteur")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Heure")
                        .HasColumnName("heure")
                        .HasColumnType("date");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnName("message")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("NonVue")
                        .HasColumnName("non_vue")
                        .HasColumnType("int(1)");

                    b.Property<int?>("Vue")
                        .HasColumnName("vue")
                        .HasColumnType("int(1)");

                    b.HasKey("Ids")
                        .HasName("PRIMARY");

                    b.HasIndex("Expediteur")
                        .HasName("id_membre");

                    b.ToTable("message_recu");
                });

            modelBuilder.Entity("foots.Models.Amis", b =>
                {
                    b.HasOne("foots.Models.Membre", "IdAmisNavigation")
                        .WithMany("AmisIdAmisNavigation")
                        .HasForeignKey("IdAmis")
                        .HasConstraintName("amis_ibfk_2")
                        .IsRequired();

                    b.HasOne("foots.Models.Membre", "IdMembreNavigation")
                        .WithMany("AmisIdMembreNavigation")
                        .HasForeignKey("IdMembre")
                        .HasConstraintName("amis_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("foots.Models.MessageRecu", b =>
                {
                    b.HasOne("foots.Models.Membre", "ExpediteurNavigation")
                        .WithMany("MessageRecu")
                        .HasForeignKey("Expediteur")
                        .HasConstraintName("message_recu_ibfk_1")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
