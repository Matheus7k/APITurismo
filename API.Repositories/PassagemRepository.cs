
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using Dapper;
using Models;

namespace API.Repositories
{
    public class PassagemRepository : IPassagemRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";
        private EnderecoRepository _enderecoRepository = new();
        private ClienteRepository _clienteRepository = new();

        public List<Passagem> GetAll()
        {
            var db = new SqlConnection(_conn);

            db.Open();

            IDataReader dr = db.ExecuteReader(Passagem.GETALL);

            List<Passagem> passagens = new();

            while (dr.Read())
            {
                Passagem passagem = new();

                passagem.Id = (int)dr["Id"];
                passagem.Origem = _enderecoRepository.GetEnderecoId((int)dr["Origem"]);
                passagem.Destino = _enderecoRepository.GetEnderecoId((int)dr["Destino"]);
                passagem.Cliente = _clienteRepository.GetClienteId((int)dr["IdCliente"]);
                passagem.Data = (DateTime)dr["Data"];
                passagem.Valor = (decimal)dr["Valor"];

                passagens.Add(passagem);
            }

            db.Close();

            return passagens;
        }

        public bool Insert(Passagem passagem)
        {
            string strInsert = $"insert into Passagem (Origem, Destino, IdCliente, [Data], Valor) values " +
                $"({_enderecoRepository.InsertEndereco(passagem.Origem)}, {_enderecoRepository.InsertEndereco(passagem.Destino)}, {_clienteRepository.InsertCliente(passagem.Cliente)}, @Data, @Valor)";

            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(strInsert, passagem);

            db.Close();

            return true;
        }

        public int InsertPassagem(Passagem passagem)
        {
            string strInsert = $"insert into Passagem (Origem, Destino, IdCliente, [Data], Valor) values " +
                $"({_enderecoRepository.InsertEndereco(passagem.Origem)}, {_enderecoRepository.InsertEndereco(passagem.Destino)}, {_clienteRepository.InsertCliente(passagem.Cliente)}, @Data, @Valor); " +
                $"select cast(scope_identity() as int)";

            var db = new SqlConnection(_conn);

            return (int)db.ExecuteScalar(strInsert, passagem);
        }

        public Passagem GetPassagemId(int id)
        {
            string strSelect = $"select Id, Origem, Destino, IdCliente, [Data], Valor from Passagem where Id = {id}";

            var db = new SqlConnection(_conn);

            IDataReader dr = db.ExecuteReader(strSelect);

            Passagem passagem = new();

            while (dr.Read())
            {
                passagem.Id = (int)dr["Id"];
                passagem.Origem = _enderecoRepository.GetEnderecoId((int)dr["Origem"]);
                passagem.Destino = _enderecoRepository.GetEnderecoId((int)dr["Destino"]);
                passagem.Cliente = _clienteRepository.GetClienteId((int)dr["IdCliente"]);
                passagem.Data = (DateTime)dr["Data"];
                passagem.Valor = (decimal)dr["Valor"];
            }

            return passagem;
        }

        public void UpdatePassagem(Passagem passagem)
        {
            string strUpdate = "update Passagem set Valor = @Valor where Id = @Id";

            var db = new SqlConnection(_conn);

            db.Execute(strUpdate, passagem);
        }
    }
}
