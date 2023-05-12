using Contato.Models;

namespace Contato.ViewModels
{
    public class ContatoViewModel
    {
        public IEnumerable<ContatoModel> ListaContatos { get; set; }

        public static implicit operator ContatoViewModel(ContatoViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
