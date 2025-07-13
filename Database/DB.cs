using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransRD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace TransRD.Database
{
  public class DB : DbContext
  {
    public DbSet<User> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(String.Format("Data Source={0}\\SQLEXPRESS; Initial Catalog=TransRD; integrated security = true; TrustServerCertificate=true", "localhost"));
    }
  }
}
