using Contato.Models;
using Contato.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Contato.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() 
        {
            List<ContatoModel> list = new List<ContatoModel>
            {
                new ContatoModel("Carol", "carol.lima.vitoria@gmail.com", "985286351","~/img/femUser.jpg"),
                new ContatoModel("Patricia", "patilinda@gmail.com", "940028922","~/img/otherFem.jpg")
            };

        

            var ViewModel = new ContatoViewModel
            {
                ListaContatos = list
            };

            return View(ViewModel);
        }


        public IActionResult Delete()
        {
            return View("List");

        }
    }
}
