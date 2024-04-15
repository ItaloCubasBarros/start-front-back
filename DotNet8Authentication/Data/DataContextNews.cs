using DotNet8Authentication.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8Authentication.Data
{
    public class DataContextNews : DbContext
    {
        public DataContextNews(DbContextOptions<DataContextNews> options) : base(options) 
        {
            
        }

        public DbSet<News> News { get; set; }
    }
}
