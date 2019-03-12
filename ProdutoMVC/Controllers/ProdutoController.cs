using ProdutoCRUD.Dominio;
using ProdutoCRUD.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdutoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();
       
        // GET: Produto
        public ActionResult Index()
        {

            var listaCategoria = new CategoriaRepository().GetAll();
            ViewBag.CategoriaId = new SelectList(
              listaCategoria,
               "CategoriaId",
               "CategoriaNome"
          );
            IEnumerable<Produto> produtos = _produtoRepository.GetAll();
            
            return View(produtos);
        }
        [HttpPost]
        public ActionResult index(int id)
        {

            var listaCategoria = new CategoriaRepository().GetAll();
            ViewBag.CategoriaId = new SelectList(
              listaCategoria,
               "CategoriaId",
               "CategoriaNome"
          );
            IEnumerable<Produto> produtosid = _produtoRepository.GetAll().Where(c => c.CategoriaId == id);

            return View(produtosid);
        }



        public ActionResult Cadastrar() 
        {
            var listaCategoria = new CategoriaRepository().GetAll();
            ViewBag.CategoriaId = new SelectList(
              listaCategoria,
               "CategoriaId",
               "CategoriaNome"
          );
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DataCadasto = DateTime.Now;
                _produtoRepository.Add(produto);
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                var listaCategoria = new CategoriaRepository().GetAll();
                ViewBag.CategoriaId = new SelectList(
                  listaCategoria,
                   "CategoriaId",
                   "CategoriaNome"
              );
                return View(produto);
            }


            return View(produto);
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Produto produto)
        {

           
                Categoria cat = new Categoria();
                cat.CategoriaNome = produto.Nome;
                new CategoriaRepository().Add(cat);
                return RedirectToAction("Cadastrar");
            
           
        }
    }
}