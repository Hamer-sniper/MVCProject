using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class DataBookContext : DbContext
    {
        public DbSet<DataBook> DataBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            Microsoft.Data.SqlClient.SqlConnectionStringBuilder sqlCon = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"MSSQLLocalDemo",
                IntegratedSecurity = true,
                UserID = "sa",
                Password = "123",
                Pooling = false
            };
            return sqlCon.ConnectionString;
        }
    }
}
