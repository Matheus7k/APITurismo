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
    public class EnderecoService
    {
        private IEnderecoRepository _enderecoRepository;

        public EnderecoService()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        public bool Insert(Endereco endereco)
        {
            return _enderecoRepository.Insert(endereco);
        }

        public List<Endereco> GetAll()
        {
            return _enderecoRepository.GetAll();
        }
    }
}
