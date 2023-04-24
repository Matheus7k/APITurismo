using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace API.Repositories.Interfaces
{
    public interface IPacoteRepository
    {
        bool Insert(Pacote pacote);
        List<Pacote> GetAll();
        void Delete(int id);
        void UpdatePacote(Pacote pacote);
    }
}
