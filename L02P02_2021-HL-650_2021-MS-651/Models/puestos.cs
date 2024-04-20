using System.ComponentModel.DataAnnotations;

namespace L02P02_2021_HL_650_2021_MS_651.Models
{
	public class puestos
	{

		[Key]
        
        public int id { get; set; }
		public string? puesto { get; set; }
		public string? estado { get; set; }
		public byte[]? created_at { get; set; }
	



	}
}
