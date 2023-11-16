using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AquaBrainAPI;

public partial class DevelopmentContext : DbContext
{
    public DevelopmentContext()
    {
    }

    public DevelopmentContext(DbContextOptions<DevelopmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Klant> Klanten { get; set; }

    public virtual DbSet<OnderhoudLogboek> OnderhoudLogboeks { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<Valve> Valves { get; set; }

    public virtual DbSet<Waterton> Watertonnen { get; set; }

    public virtual DbSet<Woning> Woningen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.154.22;port=3306;database=development;user=Backend;password=AquaBrain-BE", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("klant");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Achternaam).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Created_date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Gebruikersnaam).HasMaxLength(255);
            entity.Property(e => e.Telefoon).HasMaxLength(255);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasDefaultValueSql("'Particulier'")
                .HasComment("Bedrijf, Particulier");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Updated_date");
            entity.Property(e => e.Voornaam).HasMaxLength(255);
            entity.Property(e => e.Wachtwoord)
                .HasMaxLength(255)
                .HasComment("Plain text");
        });

        modelBuilder.Entity<OnderhoudLogboek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("onderhoud_logboek");

            entity.HasIndex(e => e.WatertonId, "FKOnderhoud_959560");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Created_date");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Updated_date");
            entity.Property(e => e.WatertonId).HasColumnName("Waterton_ID");

            entity.HasOne(d => d.Waterton).WithMany(p => p.OnderhoudLogboeks)
                .HasForeignKey(d => d.WatertonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOnderhoud_959560");
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sensor");

            entity.HasIndex(e => e.WatertonId, "FKSensor891887");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Created_date");
            entity.Property(e => e.SensorId).HasColumnName("Sensor_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasComment("waterniveau\nwaterverbruik\nwaterkwaliteit");
            entity.Property(e => e.WatertonId).HasColumnName("Waterton_ID");

            entity.HasOne(d => d.Waterton).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.WatertonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSensor891887");
        });

        modelBuilder.Entity<Valve>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("valve");

            entity.HasIndex(e => e.WatertonId, "valve_FK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Created_date");
            entity.Property(e => e.WatertonId).HasColumnName("Waterton_ID");

            entity.HasOne(d => d.Waterton).WithMany(p => p.Valves)
                .HasForeignKey(d => d.WatertonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("valve_FK");
        });

        modelBuilder.Entity<Waterton>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("waterton");

            entity.HasIndex(e => e.WoningId, "FKWaterton711584");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Created_date");
            entity.Property(e => e.Inhoud).HasComment("Huidige Inhoud");
            entity.Property(e => e.LaatsteOnderhoud)
                .HasColumnType("timestamp")
                .HasColumnName("Laatste_onderhoud");
            entity.Property(e => e.MaxInhoud)
                .HasDefaultValueSql("'168'")
                .HasComment("L")
                .HasColumnName("Max_inhoud");
            entity.Property(e => e.Naam)
                .HasMaxLength(255)
                .HasDefaultValueSql("'Waterton'");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Updated_date");
            entity.Property(e => e.VolgendeOnderhoud)
                .HasColumnType("timestamp")
                .HasColumnName("Volgende_onderhoud");
            entity.Property(e => e.WoningId).HasColumnName("Woning_ID");

            entity.HasOne(d => d.Woning).WithMany(p => p.Watertons)
                .HasForeignKey(d => d.WoningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKWaterton711584");
        });

        modelBuilder.Entity<Woning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("woning");

            entity.HasIndex(e => e.KlantId, "FKWoning312185");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adres).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Created_date");
            entity.Property(e => e.KlantId).HasColumnName("Klant_ID");
            entity.Property(e => e.Land).HasMaxLength(255);
            entity.Property(e => e.Naam)
                .HasMaxLength(255)
                .HasDefaultValueSql("'Woning'");
            entity.Property(e => e.Oppervlakte).HasComment("M3");
            entity.Property(e => e.Plaats).HasMaxLength(255);
            entity.Property(e => e.Postcode).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("Updated_date");

            entity.HasOne(d => d.Klant).WithMany(p => p.Wonings)
                .HasForeignKey(d => d.KlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKWoning312185");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
