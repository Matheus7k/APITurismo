using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using Models;
using Dapper;

namespace API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";
        private EnderecoRepository _enderecoRepository = new();

        public List<Cliente> GetAll()
        {
            var db = new SqlConnection(_conn);

            db.Open();

            IDataReader dr = db.ExecuteReader(Cliente.GETALL);

            List<Cliente> clientes = new();

            while (dr.Read())
            {
                Cliente cliente = new();

                cliente.Id = 0;
                cliente.Nome = (string)dr["Nome"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Endereco = _enderecoRepository.GetEnderecoId((int)dr["IdEndereco"]);
                cliente.DataCadastro = (DateTime)dr["DataCadastro"];

                clientes.Add(cliente);
            }

            return clientes;
        }

        public Cliente GetClienteId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Cliente cliente)
        {
            StringBuilder sb = new();
            sb.Append(Cliente.INSERT);
            sb.Replace("@Endereco", _enderecoRepository.InsertEndereco(cliente.Endereco).ToString());

            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(sb.ToString(), cliente);

            db.Close();

            return true;
        }

        public int InsertCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
