using System.ComponentModel.DataAnnotations;

namespace ApiDotnet5SqliteSample.ViewModels
{
    public class ProdutoViewModel
    {
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public decimal Valor { get; set; }
    }
}