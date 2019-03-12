using ProdutoCRUD.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoCRUD.Infra.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {

        public CategoriaConfiguration()
           {
                HasKey(c => c.CategoriaId);

                Property(c => c.CategoriaNome)
                .IsRequired()
                .HasMaxLength(150);

       
            
            }
    }
}
