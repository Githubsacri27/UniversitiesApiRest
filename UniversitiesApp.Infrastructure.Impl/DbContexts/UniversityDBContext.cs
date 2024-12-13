﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated> 
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniversitiesApp.Infrastructure.Contracts.Entities;
using UniversitiesApp.Infrastructure.Impl;

namespace UniversitiesApp.Infrastructure.Impl.DbContexts
{
    public partial class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
        {
        }

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<UniversityDomain> UniversityDomain { get; set; }
        public virtual DbSet<UniversityPage> UniversityPage { get; set; }
        public virtual DbSet<UniversityWebPage> UniversityWebPage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=yourDB;Persist Security Info=True;User ID=user;Password=yourpassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>(entity =>
            {
                entity.HasOne(d => d.UniversityPage)
                    .WithMany(p => p.University)
                    .HasForeignKey(d => d.UniversityPageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UniversityPage_University");
            });

            modelBuilder.Entity<UniversityDomain>(entity =>
            {
                entity.HasOne(d => d.University)
                    .WithMany(p => p.UniversityDomain)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_University_UniversityDomain");
            });

            modelBuilder.Entity<UniversityWebPage>(entity =>
            {
                entity.HasOne(d => d.University)
                    .WithMany(p => p.UniversityWebPage)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_University_UniversityWebPage");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}