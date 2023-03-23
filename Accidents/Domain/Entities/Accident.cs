namespace Domain.Entities
{
	public class Accident : BaseEntity
	{
		public DateTime Date { get; set; }
		public string? Type { get; set; }
		public int ApproximateDamages { get; set; }
		public int ApproximateDamages2 { get; set; }
	}
}
