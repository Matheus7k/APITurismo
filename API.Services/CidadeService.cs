using API.Repositories;
using API.Repositories.Interfaces;
using Models;

namespace API.Services
{
    public class CidadeService
    {
        private ICidadeRepository _cidadeRepository;

        public CidadeService()
        {
            _cidadeRepository = new CidadeRepository();
        }

        public bool Insert(Cidade cidade)
        {
            return _cidadeRepository.Insert(cidade);
        }

        public List<Cidade> GetAll()
        {
            return _cidadeRepository.GetAll();
        }

        public void UpdateCidade(Cidade cidade)
        {
            _cidadeRepository.UpdateCidade(cidade);
        }
    }
}