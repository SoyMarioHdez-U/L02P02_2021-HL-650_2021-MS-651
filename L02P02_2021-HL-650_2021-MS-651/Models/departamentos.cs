using System.ComponentModel.DataAnnotations;
namespace L02P02_2021_HL_650_2021_MS_651.Models
{
	public class departamentos
	{

		[Key]
		public int id { get; set; }
		public string? departamento { get; set; }
		public string? estado { get; set; }
		public DateTime? created_at { get; set; }

	}
}
