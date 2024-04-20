using System.ComponentModel.DataAnnotations;
namespace L02P02_2021_HL_650_2021_MS_651.Models
{
    public class clientes
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? url_imagen {  get; set; }
        public string? direccion { get; set; }
        public string? genero { get; set; }
        public int? id_departamento { get; set; }
        public int? ip_puesto { get; set; }
        public string? estado_registro { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }


    }
}
