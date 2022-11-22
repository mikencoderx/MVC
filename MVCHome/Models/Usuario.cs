using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHome.Models
{
    public class Usuario
    {
        [Key]
        public int PkUser { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        [ForeignKey("Rol")]
        public int? FkRol { get; set; }
        public Roles Rol { get; set; }
        //TODO poner el link del css para que aparezcan los iconos y seguir con el codigo
    }
}
