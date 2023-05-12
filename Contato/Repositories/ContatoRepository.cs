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

        public void Add(ContatoModel contato)
        {
            //Adiciono o contato no banco de dados 
            _dbContext.Contatos.Add(contato);

            _dbContext.SaveChanges();
        }

        public void Delete(ContatoModel contato)
        {
            _dbContext.Contatos.Remove(contato);

            _dbContext.SaveChanges();
        }

        public void Edit(ContatoModel contatoEditado, ContatoModel contatoVelho)
        {
            contatoVelho.Name = contatoEditado.Name;
            contatoVelho.Email = contatoEditado.Email;
            contatoVelho.Phone = contatoEditado.Phone;
            contatoVelho.imageUser = contatoEditado.imageUser;

            _dbContext.SaveChanges();
        }

        public ContatoModel GetContatoById(int id)
        {
           return _dbContext.Contatos.FirstOrDefault(Contato =>  Contato.Id == id);
        }

        public IEnumerable<ContatoModel> GetContatos(ContatoModel contato)
        {
            return _dbContext.Contatos; //retornar a tabela 
        }
    }
}
