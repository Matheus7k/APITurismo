using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace API.Repositories.Interfaces
{
    public interface ICidadeRepository
    {
        bool Insert(Cidade cidade);
        List<Cidade> GetAll();
    }
}
