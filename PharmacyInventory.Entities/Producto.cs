using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyInventory.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Proveedor { get; set; }
        public string Aplicacion { get; set; }
        public string Prospecto { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
    }
}
