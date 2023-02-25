using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_Metadec.Domain.Models
{
    public class MD_Pais
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Pais { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string CodigoPais { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Longitud { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Latitud { get; set; } = null!;

        public List<MD_Usuario>? Usuarios { get; set; }
    }
}
