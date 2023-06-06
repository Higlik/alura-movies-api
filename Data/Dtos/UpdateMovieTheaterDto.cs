using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Data.Dtos;

public class UpdateMovieTheaterDto
{
    [Required(ErrorMessage = "The name is required")]
    public string Name { get; set; }
}