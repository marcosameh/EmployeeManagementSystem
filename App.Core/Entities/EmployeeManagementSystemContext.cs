﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Entities;

public partial class EmployeeManagementSystemContext : DbContext
{
    public EmployeeManagementSystemContext(DbContextOptions<EmployeeManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(e => e.MiddleName)
                .IsRequired()
                .HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}