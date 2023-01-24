using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLibros.Validations;
namespace WebApiLibros.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [PrimeraLetraMayusculaAtributte]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        [Range(18, 110, ErrorMessage = "La edad debe ser entre 18 y 110")]
        public int? Edad { get; set;}

        [Column(TypeName = "date")]
        [FechaMinimaAtributte]
        public DateTime FechaDeNacimiento { get; set; }

        public virtual List<Libro> Libros { get; set; }

    }
}
