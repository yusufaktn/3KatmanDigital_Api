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
    public class ProjectImagesConfigration : IEntityTypeConfiguration<ProjectImages>
    {
        public void Configure(EntityTypeBuilder<ProjectImages> builder)
        {
            builder.HasKey(pi => pi.ID);
            builder.Property(pi => pi.ImagePath)
                .IsRequired();

            builder.HasOne(pi=>pi.Project)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProjectID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
