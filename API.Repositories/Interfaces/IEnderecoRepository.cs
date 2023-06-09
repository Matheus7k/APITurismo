﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace API.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        bool Insert(Endereco endereco);
        List<Endereco> GetAll();
        int InsertEndereco(Endereco endereco);
        Endereco GetEnderecoId(int id);
        void UpdateEndereco(Endereco endereco);
    }
}
