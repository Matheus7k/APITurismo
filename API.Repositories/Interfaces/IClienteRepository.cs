using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace API.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public bool Insert(Cliente cliente);
        public List<Cliente> GetAll();
        public int InsertCliente(Cliente cliente);
        public Cliente GetClienteId(int id);
        public void UpdateCliente(Cliente cliente);
    }
}
