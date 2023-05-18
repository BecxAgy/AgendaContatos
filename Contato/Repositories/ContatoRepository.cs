using Contato.Data;
using Contato.Models;
using Contato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Contato.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _dbContext;

        public ContatoRepository(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;   
        }

        public async Task Add(ContatoModel contato)
        {
            //Adiciono o contato no banco de dados 
            _dbContext.Contatos.Add(contato);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(ContatoModel contato)
        {
            _dbContext.Contatos.Remove(contato);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(ContatoModel contatoEditado)
        {
            _dbContext.Update(contatoEditado);

            await _dbContext.SaveChangesAsync(); // o await é pra que eu espere que ele termine de executar 
        }

        public async Task<ContatoModel> GetContatoById(int? id)
        {
           return await _dbContext.Contatos.FirstOrDefaultAsync(Contato =>  Contato.Id == id);
           
        }

        public IEnumerable<ContatoModel> GetContatos()
        {
            return _dbContext.Contatos.ToList(); //retornar a tabela 
        }

        public async Task ToggleFavorite(ContatoModel contato)
        {
            if(contato.IsFavorite == true)
            {
                contato.IsFavorite = false;
            }else
            {
                contato.IsFavorite = true;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
