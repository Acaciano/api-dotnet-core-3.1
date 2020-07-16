using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório!")]

        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}