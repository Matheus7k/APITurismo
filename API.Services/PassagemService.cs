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
    public class PassagemService
    {
        private IPassagemRepository _passagemRepository;

        public PassagemService()
        {
            _passagemRepository = new PassagemRepository();
        }

        public bool Insert(Passagem passagem)
        {
            return _passagemRepository.Insert(passagem);
        }


        public List<Passagem> GetAll()
        {
            return _passagemRepository.GetAll();
        }

        public void UpdatePassagem(Passagem passagem)
        {
            _passagemRepository.UpdatePassagem(passagem);
        }
    }
}
