﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUserApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminUserApi.Models
{
    public class AdminUserDBcontext : DbContext
    {
        public AdminUserDBcontext(DbContextOptions<AdminUserDBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Identificador unico del Permiso");

                entity.Property(e => e.Code)
                    .ValueGeneratedOnAdd()
                    .HasComment("Código unico del Permiso");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre del Permiso");
            });

            modelBuilder.Entity<PermissionRole>(entity =>
            {
                entity.ToTable("PermissionRole");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Identificador unico");

                entity.Property(e => e.PermissionId).HasComment("Identificador del Permiso");

                entity.Property(e => e.RoleId).HasComment("Identificador del Rol");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Identificador unico del Rol");

                entity.Property(e => e.Code)
                    .ValueGeneratedOnAdd()
                    .HasComment("Código unico del Rol");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Identificador unico del usuario");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Dirección del usuario");

                entity.Property(e => e.Age).HasComment("Edad del usuario");

                entity.Property(e => e.Code)
                    .ValueGeneratedOnAdd()
                    .HasComment("Código unico del usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Correo electrónico del usuario");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre del usuario");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Telefono del usuario");

                entity.Property(e => e.RoleId).HasComment("Indetificador del rol de usuario");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });
        }
    }
}
