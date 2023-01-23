using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace WebApiLibros.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Titulo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Descripcion { get; set; }
        public int Autor_Id { get; set; }
        [ForeignKey("Autor_Id")]
        public virtual Autor Autor { get; set; }

    }
}
