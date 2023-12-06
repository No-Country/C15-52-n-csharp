using System.ComponentModel.DataAnnotations;

namespace PharmacyInventory.Entities
{
    public class PrecioVenta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double SubTotal { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
