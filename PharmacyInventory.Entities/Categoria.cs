using System.ComponentModel.DataAnnotations;

namespace PharmacyInventory.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
