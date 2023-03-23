namespace Application.Models
{
	public class DangerousDateDto
	{
		public DateTime Date { get; set; }
		public int AccidentsCount { get; set; }
		public WeatherDto? Weather { get; set; }
	}
}
