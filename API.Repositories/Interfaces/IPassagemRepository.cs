using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace API.Repositories.Interfaces
{
    public interface IPassagemRepository
    {
        bool Insert(Passagem passagem);
        List<Passagem> GetAll();
        int InsertPassagem(Passagem passagem);
        Passagem GetPassagemId(int id);
        void UpdatePassagem(Passagem passagem);
    }
}
