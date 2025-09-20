﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Slug)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            builder.HasIndex(c => c.Name)
                   .IsUnique();

 
        }
    }
}
