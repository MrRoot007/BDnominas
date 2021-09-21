using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomina2018.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina2018.Infrastructure.Data
{
    public partial class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("iIdEmployee");

            builder.Property(e => e.DSalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("dSalary");

            builder.Property(e => e.IIdDepartment).HasColumnName("iIdDepartment");

            builder.Property(e => e.SLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sLastName");

            builder.Property(e => e.SName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sName");

            builder.Property(e => e.SStreet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SStreet");

            builder.Property(e => e.IZipCode)
                .IsUnicode(false)
                .HasColumnName("IZipCode");

            builder.Property(e => e.SCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sCity");

            builder.HasOne(d => d.IIdDepartmentNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.IIdDepartment)
                .HasConstraintName("FK_Employee_Department");

        }
    }
}
