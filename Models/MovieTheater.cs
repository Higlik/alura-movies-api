using System.ComponentModel.DataAnnotations;

namespace alura_movies_api.Models;

public class MovieTheater
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The name is required")]
    public string Name { get; set; }

    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}