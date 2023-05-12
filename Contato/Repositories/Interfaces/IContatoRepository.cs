using Contato.Models;
using Microsoft.CodeAnalysis.Differencing;

namespace Contato.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        //add
        void Add(ContatoModel contato);
        //assinatura tipo de retorno + nome do método +  (parametros?)

        IEnumerable<ContatoModel> GetContatos(ContatoModel contato); //assinatura 

        //edit
        void Edit(ContatoModel contato, ContatoModel contatoVelho);

        void Delete(ContatoModel contato);

        ContatoModel GetContatoById(int id);
    }
}
