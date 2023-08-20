
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace Module25_ElectronicLibrary
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J91KSOF\SQLEXPRESS;Database=ElectronicLibrary;Trusted_Connection= True;TrustServerCertificate=true");

        }
        private IDbConnection CreateConnection()
        {
           optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J91KSOF\SQLEXPRESS;Database=ElectronicLibrary;Trusted_Connection= True;TrustServerCertificate=true");
        }
    }

    public interface IUserRepository
    {
        int Create(User userEntity);
        User FindByEmail(string email);
        IEnumerable<User> FindAll();
        User FindById(int id);
        int Update(User userEntity);
        int DeleteById(int id);
    }
}
