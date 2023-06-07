using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Models;

public class Session
{
    [Key]
    [Required]
    public int Id { get; set; }
    
}