using ProdutoCRUD.Dominio;
using ProdutoCRUD.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoCRUD.Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto> , IProdutoRepository
    {
    }
}
