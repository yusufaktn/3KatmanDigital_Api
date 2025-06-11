using Entitiy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.Configration
{
    public class ProjectConfigration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p=>p.Description).IsRequired()
                .HasMaxLength(500);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Images)
                .WithOne(pi => pi.Project)
                .HasForeignKey(pi => pi.ProjectID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
