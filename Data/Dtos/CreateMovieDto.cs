using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Data.Dtos;

public class CreateMovieDto
{
    [Required(ErrorMessage = "The title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "The movie need a gender")]
    [StringLength(30, ErrorMessage = "Gender can be a maximum of 30 characters")]
    public string Gender { get; set; }
    [Required]
    [Range(70,600,ErrorMessage = "Duration should be between 70 to 600 minutes")]
    public int Time { get; set; }
}