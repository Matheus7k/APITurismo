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
    public class ClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public bool Insert(Cliente cliente)
        {
            return _clienteRepository.Insert(cliente);
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepository.UpdateCliente(cliente);
        }
    }
}
