using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Aplication.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome do produto deve ter no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome do produto deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [MinLength(5, ErrorMessage = "A descrição do produto deve ter no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição do produto deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Valor do produto")]
        [Required(ErrorMessage = "O valor do produto é obrigatória.")]
        [Column(TypeName = "decial(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Imagem do Produto")]
        [MaxLength(250, ErrorMessage = "O nome da imagem deve ter no máximo {1} caracteres.")]
        public string Image { get; set; }

        [Display(Name = "Quantidade de estoque")]
        [Required(ErrorMessage = "A quantidade de estoque é obrigatória.")]
        [Range(1, 9999)]
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
