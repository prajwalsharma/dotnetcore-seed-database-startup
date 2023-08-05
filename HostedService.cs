using Dapper;
using System.Data.SqlClient;

namespace dotnetcore_seed_database_startup
{
    public class HostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "usp_get_users.sql");
            string sql = File.ReadAllText(path);
            using var connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=mydb;Trusted_Connection=True;");
            
            foreach (var item in sql.Split("GO"))
            {
                await connection.ExecuteAsync(item);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("App Stopped!");
            return Task.CompletedTask;
        }
    }
}
