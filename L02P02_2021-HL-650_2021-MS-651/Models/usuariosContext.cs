using Microsoft.EntityFrameworkCore;

namespace L02P02_2021_HL_650_2021_MS_651.Models
{
	public class usuariosContext : DbContext
	{

		public usuariosContext(DbContextOptions<usuariosContext> options) : base(options) 
		{
		
		

		}

	}
}
