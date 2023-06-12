using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Data.Dtos;

public class ReadAddressDto
{
    public int Id { get; set;}
    [Required]
    public string Street { get; set; }
    [Required]
    public int Number { get; set; }
}