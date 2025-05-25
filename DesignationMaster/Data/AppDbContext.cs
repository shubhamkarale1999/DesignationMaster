using DesignationMaster.Models;
using Microsoft.EntityFrameworkCore;


namespace DesignationMaster.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<DesignationMasterViewModel> DesignationMasterViewModel { get; set; }
        public DbSet<StreamViewModel> StreamViewModel { get; set; }
        public DbSet<CollegeViewMode> CollegeViewMode { get; set; }
    }
}
