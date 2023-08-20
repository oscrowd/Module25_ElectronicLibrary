
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace Module25_ElectronicLibrary.Repository
{
    public class UserRepository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserRepository()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J91KSOF\SQLEXPRESS;Database=ElectronicLibrary;Trusted_Connection= True;TrustServerCertificate=true");

        }
    }   
}
