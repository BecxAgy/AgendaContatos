using Contato.Data;
using Contato.Models;
using Contato.Repositories.Interfaces;
using Contato.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Contato.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository; //aqui eu to chamando o repositorio e criando a variavel 
        public ContatoController(IContatoRepository _contatoRepository)
        {
            this._contatoRepository =  
                _contatoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult List()
        {
            //pegar a lista de contatos do banco e retornar para a view
            var lista = _contatoRepository.GetContatos;

            ContatoViewModel VM = new ContatoViewModel
            { //instanciar a view 
               // ListaContatos = lista
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
                contatoVelho.imageUser = contatoEditado.imageUser;

                _context.SaveChanges();
            }
            //update
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if(id==null) return NotFound(); 
            //Verifico se esse id existe no banco 
            var contatoExiste = _context.Contatos.FirstOrDefault(contato => contato.Id == id);

            //se existe eu retorno a view 
            if (contatoExiste != null) return View();
           

            //se nao existir eu retorno a view list
            return NotFound();

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var acharContato = _context.Contatos.FirstOrDefault(contato => contato.Id == id);

            _context.Contatos.Remove(acharContato);

            _context.SaveChanges(); 

            return RedirectToAction("List");
        }

        
       
    }
}
