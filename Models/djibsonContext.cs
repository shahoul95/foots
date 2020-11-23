
using Microsoft.EntityFrameworkCore;


namespace foots.Models
{
    public partial class DjibsonContext : DbContext
    {
        public DjibsonContext()
        {
        }

        public DjibsonContext(DbContextOptions<DjibsonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amis> Amis { get; set; }
        public virtual DbSet<Membre> Membre { get; set; }
        public virtual DbSet<MessageRecu> MessageRecu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=8889;user=root;password=root;database=djibson");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amis>(entity =>
            {
                entity.ToTable("amis");

                entity.HasIndex(e => e.IdAmis)
                    .HasName("id_amis");

                entity.HasIndex(e => e.IdMembre)
                    .HasName("ids");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAmis)
                    .HasColumnName("id_amis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMembre)
                    .HasColumnName("id_membre")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAmisNavigation)
                    .WithMany(p => p.AmisIdAmisNavigation)
                    .HasForeignKey(d => d.IdAmis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("amis_ibfk_2");

                entity.HasOne(d => d.IdMembreNavigation)
                    .WithMany(p => p.AmisIdMembreNavigation)
                    .HasForeignKey(d => d.IdMembre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("amis_ibfk_1");
            });

            modelBuilder.Entity<Membre>(entity =>
            {
                entity.HasKey(e => e.IdMembres)
                    .HasName("PRIMARY");

                entity.ToTable("membre");

                entity.Property(e => e.IdMembres)
                    .HasColumnName("id_membres")
                    .HasColumnType("int(255)");

                entity.Property(e => e.Equipe)
                    .HasColumnName("equipe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MotPasses)
                    .IsRequired()
                    .HasColumnName("mot_passes")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Poste)
                    .HasColumnName("poste")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MessageRecu>(entity =>
            {
                entity.HasKey(e => e.Ids)
                    .HasName("PRIMARY");

                entity.ToTable("message_recu");

                entity.HasIndex(e => e.Expediteur)
                    .HasName("id_membre");

                entity.Property(e => e.Ids)
                    .HasColumnName("ids")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Destinataire)
                    .IsRequired()
                    .HasColumnName("destinataire")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expediteur)
                    .HasColumnName("expediteur")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Heure)
                    .HasColumnName("heure")
                    .HasColumnType("date");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NonVue)
                    .HasColumnName("non_vue")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Vue)
                    .HasColumnName("vue")
                    .HasColumnType("int(1)");

                entity.HasOne(d => d.ExpediteurNavigation)
                    .WithMany(p => p.MessageRecu)
                    .HasForeignKey(d => d.Expediteur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("message_recu_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
