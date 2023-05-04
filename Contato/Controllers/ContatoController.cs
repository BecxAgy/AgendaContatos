using Contato.Data;
using Contato.Models;
using Contato.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Contato.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AppDbContext _context;

        public ContatoController(AppDbContext context)
        {
            this._context = context;    
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult List()
        {
            //pegar a lista de contatos do banco e retornar para a view
            var lista = _context.Contatos;

            ContatoViewModel VM = new ContatoViewModel { //instanciar a view 
            ListaContatos = lista
            };

            return View(VM);
        }    
        
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContatoModel contato)
        {
            //verifico se esse modelo esta valido
            if (ModelState.IsValid)
            {
                //Adiciono o contato no banco de dados 
                _context.Contatos.Add(contato);

                _context.SaveChanges();

                //redireciona para a view 
                return RedirectToAction("List");

            }
            return View(contato);
        }

        public IActionResult Edit(int? id)
        {
            //verificar de id é nulo
            if(id == null) return NotFound();


            //verificar se contato existe no banco
            var entity = _context.Contatos.FirstOrDefault(x=> x.Id == id);

            if (entity == null) return NotFound();

            //retornar a view com a contato para ser editado
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(int id, ContatoModel contatoEditado)
        {
            if(id != contatoEditado.Id) return NotFound();

            //verifacar se o modelo está valido
            if(ModelState.IsValid)
            {
                //voce precisa achar a contato que tem o id passado pelo parametro
               var contatoVelho = _context.Contatos.FirstOrDefault(c => c.Id == id);  
                contatoVelho.Name = contatoEditado.Name;
                contatoVelho.Email = contatoEditado.Email;
                contatoVelho.Phone = contatoEditado.Phone;

                _context.SaveChanges();
            }
            //update
            return RedirectToAction("List");
        }

        
       
    }
}
