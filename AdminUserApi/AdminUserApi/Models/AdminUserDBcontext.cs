using System;
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

                entity.HasIndex(e => e.Code, "UQ__Permissi__A25C5AA7188807E5")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Identificador unico del Permiso");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
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

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionRole_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionRole_Role");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasIndex(e => e.Code, "UQ__Role__A25C5AA76F602BFB")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("Identificador unico del Rol");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Código unico del Rol");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Code, "UQ__Users__A25C5AA7F194ABDE")
                    .IsUnique();

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
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
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
