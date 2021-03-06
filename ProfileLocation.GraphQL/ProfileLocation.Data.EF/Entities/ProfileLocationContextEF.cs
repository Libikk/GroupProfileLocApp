// <auto-generated />
using EntityFrameworkCore.Triggers;
﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProfileLocation.Domain.ORM.Models;

namespace ProfileLocation.Data.EF.Entities
{
    public partial class ProfileLocationContextEF : DbContextWithTriggers
    {
        public ProfileLocationContextEF()
        {
        }

        public ProfileLocationContextEF(DbContextOptions<ProfileLocationContextEF> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileGroup> ProfileGroups { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<SocialType> SocialTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=STO1813\\SQL2017;Database=ProfileLocation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Location1).IsUnicode(false);

                entity.Property(e => e.ViewPort).IsUnicode(false);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Mobile).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Nicknames).IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Profile_Location");
            });

            modelBuilder.Entity<ProfileGroup>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProfileGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileGroup_Group");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.ProfileGroups)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileGroup_Profile");
            });

            modelBuilder.Entity<Social>(entity =>
            {
                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Socials)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Social_Profile");

                entity.HasOne(d => d.SocialType)
                    .WithMany(p => p.Socials)
                    .HasForeignKey(d => d.SocialTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Social_SocialType");
            });

            modelBuilder.Entity<SocialType>(entity =>
            {
                entity.Property(e => e.IconUrl).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
