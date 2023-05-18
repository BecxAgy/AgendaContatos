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
           var cnt =  await  _dbContext.Contatos.FirstOrDefaultAsync(Contato =>  Contato.Id == id);
            return cnt; 
        }

        public IEnumerable<ContatoModel> GetContatos()
        {
            return _dbContext.Contatos.ToList(); //retornar a tabela 
        }
    }
}
