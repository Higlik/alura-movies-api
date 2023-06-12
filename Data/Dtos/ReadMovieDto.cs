namespace alura_movies_api.Data.Dtos;

public class ReadMovieDto
{   
    public int Id { get; set;}
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Time { get; set; }
    public DateTime AppointmentTime {get;set;} = DateTime.Now;
    public ICollection<ReadSessionDto> Sessions { get; set; }
}