using alura_movies_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alura_movies_api.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts)
        : base(opts)
    {
        
    }
    public DbSet<Movie> Movies {get;set;}
    public DbSet<MovieTheater> MovieTheaters {get;set;}
    public DbSet<Address> Addresses {get;set;}


}