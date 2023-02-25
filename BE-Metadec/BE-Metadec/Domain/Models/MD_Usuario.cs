using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Metadec.Domain.Models
{
    public class MD_Usuario
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Usuario { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string TipoUsuario { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string AvatarUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombres { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Apellidos { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Sexo { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(70)")]
        public string Correo { get; set; } = null!;

        public bool TratamientoDatos { get; set; }


        public DateTime FechaCreacion { get; set; }

        public bool ActivoJuego { get; set; }

        public bool ActivoWeb { get; set; }

        public int PaisId { get; set; }
        public MD_Pais? Pais { get; set; }


    }
}
