using Contato.Models;
using Microsoft.CodeAnalysis.Differencing;

namespace Contato.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        //add
        Task Add(ContatoModel contato);
        //assinatura tipo de retorno + nome do método +  (parametros?)

        IEnumerable<ContatoModel> GetContatos(); //assinatura 

        //edit
        Task Edit(ContatoModel contato);

        Task Delete(ContatoModel contato);

        Task<ContatoModel> GetContatoById(int? id);

        Task ToggleFavorite (ContatoModel contato);

        IEnumerable<ContatoModel> GetFavorites ();
    }
}
