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

            var clientes = db.Query<Cliente, Endereco,Cidade, Cliente>(Cliente.GETALL, (cliente, endereco,cidade) =>
            {
                cliente.Endereco = endereco;
                cliente.Endereco.Cidade = cidade;
                return cliente;
            });
            return (List<Cliente>)clientes;
        }

        public Cliente GetClienteId(int id)
        {
            string strSelect = $"select Id, Nome, Telefone, IdEndereco, DataCadastro from Cliente where Id = {id}";

            var db = new SqlConnection(_conn);

            var cliente = db.Query<Cliente, Endereco, Cidade, Cliente>(strSelect, (cliente, endereco, cidade) =>
            {
                cliente.Endereco = endereco;
                cliente.Endereco.Cidade = cidade;
                return cliente;
            });

            return (Cliente)cliente;
        }

        public bool Insert(Cliente cliente)
        {
            string strInsert = $"insert into Cliente (Nome, Telefone, IdEndereco, DataCadastro) values (@Nome, @Telefone, {_enderecoRepository.InsertEndereco(cliente.Endereco)}, @DataCadastro)";

            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(strInsert, cliente);

            db.Close();

            return true;
        }

        public int InsertCliente(Cliente cliente)
        {
            string strInsert = $"insert into Cliente (Nome, Telefone, IdEndereco, DataCadastro) values (@Nome, @Telefone, {_enderecoRepository.InsertEndereco(cliente.Endereco)}, @DataCadastro); select cast(scope_identity() as int)";

            var db = new SqlConnection(_conn);

            return (int)db.ExecuteScalar(strInsert, cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            string strUpdate = "update Cliente set Nome = @Nome, Telefone = @Telefone where Id = @Id";

            var db = new SqlConnection(_conn);

            db.Execute(strUpdate, cliente);
        }
    }
}
