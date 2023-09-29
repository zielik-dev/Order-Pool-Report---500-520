using Microsoft.EntityFrameworkCore;
using Order_Pool_Report___500___520.Models.Commands;
using Order_Pool_Report___500___520.RemoteConfigurations.EcoSystemServerConfig;

namespace Order_Pool_Report___500___520.DbContext
{
    public class ApplicationLogsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private static string _DbConnectionLogsProd, _DbConnectionLogsTest, _environment;

        public ApplicationLogsDbContext(string environment)
        {
            _DbConnectionLogsProd = DbConnectionLogsProd.Read();
            _DbConnectionLogsTest = DbConnectionLogsTest.Read();
            _environment = environment;
        }
        public DbSet<MainLogsModel> MainLogsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_environment == "Production")
                optionsBuilder.UseSqlServer(_DbConnectionLogsProd);
            else
                optionsBuilder.UseSqlServer(_DbConnectionLogsTest);
        }
    }
}
