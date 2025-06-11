using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitiy.Models;
using _3katman_digital_mvc.Models;

namespace Entitiy.Configration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.ID);
            builder.Property(c=> c.Name).IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Projects)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.ProjectRequests)
                .WithOne(pr => pr.Category)
                .HasForeignKey(pr => pr.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
