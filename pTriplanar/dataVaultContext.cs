using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pTriplanar
{
    public partial class dataVaultContext : DbContext
    {
        public dataVaultContext()
        {
        }

        public dataVaultContext(DbContextOptions<dataVaultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<game_data> game_data { get; set; }
        public virtual DbSet<user_data> user_data { get; set; }
        public virtual DbSet<user_record> user_record { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=dataVault;Username=postgres;Password=C9s0v0yf;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<game_data>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("game_data");

                entity.Property(e => e.description).HasColumnName("description");
            });

            modelBuilder.Entity<user_data>(entity =>
            {
                entity.HasKey(e => e.user_id)
                    .HasName("user_data_pkey");

                entity.ToTable("user_data");

                entity.Property(e => e.user_id)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.email).HasColumnName("email");

                entity.Property(e => e.nickname).HasColumnName("nickname");

                entity.Property(e => e.savestring).HasColumnName("savestring");
            });

            modelBuilder.Entity<user_record>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_record");

                entity.Property(e => e.maxenergylvl).HasColumnName("maxenergylvl");

                entity.Property(e => e.maxmatterlvl).HasColumnName("maxmatterlvl");

                entity.Property(e => e.maxnaturelvl).HasColumnName("maxnaturelvl");

                entity.Property(e => e.user_id).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("user_record_user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
