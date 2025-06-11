using _3katman_digital_mvc.Models;
using Entitiy.Configration;
using Entitiy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //Tablolar
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectRequest> ProjectRequests { get; set; }
        public DbSet<ProjectImages> ProjectImages { get; set; }
        public DbSet<Service> Services{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigration());
            modelBuilder.ApplyConfiguration(new ProjectConfigration());
            modelBuilder.ApplyConfiguration(new ProjectImagesConfigration());
            modelBuilder.ApplyConfiguration(new ProjectRequestConfigration());
            modelBuilder.ApplyConfiguration(new ServiceConfigration());

        }



    }
}
