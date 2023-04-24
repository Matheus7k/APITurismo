using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Repositories;
using API.Repositories.Interfaces;
using Models;

namespace API.Services
{
    public class PacoteService
    {
        private readonly IPacoteRepository _pacoteRepository;

        public PacoteService()
        {
            _pacoteRepository = new PacoteRepository();
        }

        public bool Insert(Pacote pacote)
        {
            return _pacoteRepository.Insert(pacote);
        }

        public List<Pacote> GetAll()
        {
            return _pacoteRepository.GetAll();
        }

        public void Delete(int id)
        {
            _pacoteRepository.Delete(id);
        }

        public void UpdatePacote(Pacote pacote)
        {
            _pacoteRepository.UpdatePacote(pacote);
        }
    }
}
