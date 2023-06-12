using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "The movie need a gender")]
    [MaxLength(30, ErrorMessage = "Gender can be a maximum of 30 characters")]
    public string Gender { get; set; }
    [Required]
    [Range(70,600,ErrorMessage = "Duration should be between 70 to 600 minutes")]
    public int Time { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}