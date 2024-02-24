using Employ_of_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Employ_of_Company.DATA
{
    public class DATA_AccessPoint : DbContext
    {
        public DATA_AccessPoint(DbContextOptions<DATA_AccessPoint> options) : base(options)
        {
            
        }

        public DbSet<EmployInfo> Employs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //have to be called when you are creating data in programm 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployInfo>().HasData(
                new EmployInfo { Id = 1, Name = "eken", Position="BOSS", Phone="1234567890", CreatedDate=DateTime.Now }

                );

        }
    }
}
