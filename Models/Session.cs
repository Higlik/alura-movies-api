using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Models;

public class Session
{
    public int? MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public int? MovieTheaterId { get; set; }
    public virtual MovieTheater MovieTheater { get; set; }

    
}