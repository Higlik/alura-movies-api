using alura_movies_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alura_movies_api.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts)
        : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>()
            .HasKey(session => new{ session.MovieId,session.MovieTheaterId});

        modelBuilder.Entity<Session>()
            .HasOne(session => session.MovieTheater)
            .WithMany(movieTheater => movieTheater.Sessions)
            .HasForeignKey(session => session.MovieTheaterId);

        modelBuilder.Entity<Session>()
            .HasOne(session => session.Movie)
            .WithMany(movie => movie.Sessions)
            .HasForeignKey(session => session.MovieId);

        modelBuilder.Entity<Address>()
            .HasOne(address => address.MovieTheater)
            .WithOne(movieTheater => movieTheater.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }
    public DbSet<Movie> Movies {get;set;}
    public DbSet<MovieTheater> MovieTheaters {get;set;}
    public DbSet<Address> Addresses {get;set;}
    public DbSet<Session> Sessions {get;set;}



}