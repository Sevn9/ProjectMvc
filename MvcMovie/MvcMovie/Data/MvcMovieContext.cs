using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovie.Data
{
  public class MvcMovieContext : DbContext
  {
    public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLoggerFactory(MyLoggerFactory);
    }
    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
      builder.AddConsole();
      // или так с более детальной настройкой
      //builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
      //            && level == LogLevel.Information)
      //       .AddConsole();
    });
  }
}
