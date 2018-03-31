using Microsoft.EntityFrameworkCore;

namespace BalotoResults.Models
{
    public class ResultsContext : DbContext
    {
        public ResultsContext(DbContextOptions<ResultsContext> options)
            : base(options)
        {
        }

        public DbSet<Result> Results { get; set; }
    }
}