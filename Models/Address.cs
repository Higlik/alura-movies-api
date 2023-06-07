using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public int Number { get; set; }
    public virtual MovieTheater MovieTheater { get; set; }
}