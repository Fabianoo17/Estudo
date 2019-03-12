using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProdutoCRUD.Dominio
{   [Table("Produtos")]
    public class Produto
    {   [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha a Descrição")]
        [MaxLength(250, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Descrição do Produto")]
        public string DescProduto { get; set; }
        [DisplayName("Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadasto { get; set; }
        [DisplayName("Data de Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimento { get; set; }
        [DisplayName("Preço")]
        [Required(ErrorMessage = "Preencha o campo Preço")]
        public Decimal Preco { get; set; }
        [Required(ErrorMessage = "Preencha o campo Categoria")]
        
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public bool ProdutoVencido(Produto produto)
        {
            return DateTime.Now >= DataVencimento;
        }


    }
}
