using F.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F.DAL
{
    public class FDBContext: DbContext
    {

        public DbSet<PersonaF> PersonasF { get; set; }

        private readonly string _dbConnectionString = "Data Source=LEENIN-DESKTOP5NFAILV\\LEENINRUGAMASQL;Initial Catalog=FDB;Trusted_Connection=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ahora _dbConnectionString está inicializado
            optionsBuilder.UseSqlServer(_dbConnectionString, sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        }
    }
}
