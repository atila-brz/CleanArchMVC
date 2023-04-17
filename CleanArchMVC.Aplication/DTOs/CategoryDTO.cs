using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Aplication.DTOs
{
    public class CategoryDTO
    {
        
        public int Id { get; set; }

        [Display(Name = "Nome da Categoria")]
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo {1} caracteres.")]
        [MinLength(3, ErrorMessage = "O nome da categoria deve ter no mínimo {1} caracteres.")]
        public string Name { get; set; }

    }
}
