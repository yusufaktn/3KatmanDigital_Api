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
    public class ProjectRequestConfigration : IEntityTypeConfiguration<ProjectRequest>
    {
        public void Configure(EntityTypeBuilder<ProjectRequest> builder)
        {
            builder.HasKey(r => r.ID);
            builder.Property(r => r.NameSurname)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Email)
                .IsRequired();

            builder.Property( r => r.Message)
                .HasMaxLength(300);  

            builder.HasOne(r => r.Category)
                .WithMany(c => c.ProjectRequests)
                .HasForeignKey(r => r.CategoryID)
                .OnDelete(DeleteBehavior.NoAction); 
            
            


        }

    }
}
