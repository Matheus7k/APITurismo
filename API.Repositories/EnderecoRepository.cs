using Dapper;
using Models;
using System.Data.SqlClient;
using API.Repositories.Interfaces;
using System.Data;
using System.Text;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;

namespace API.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";
        private CidadeRepository _cidadeRepository = new();

        public bool Insert(Endereco endereco)
        {
            string strInsert = $"insert into Endereco(Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro) " +
                $"values(@Logradouro, @Numero, @Bairro, @CEP, @Complemento, {_cidadeRepository.InsertCidade(endereco.Cidade)}, @DataCadastro)";
            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(strInsert, endereco);

            db.Close();

            return true;
        }

        public List<Endereco> GetAll()
        {
            List<Endereco> listaEnderecos = new();

            var db = new SqlConnection(_conn);            

            var enderecos = db.Query<Endereco, Cidade, Endereco>(Endereco.GETALL, (endereco, cidade) =>
            {
                endereco.Cidade = cidade;
                return endereco;
            });
            return (List<Endereco>)enderecos;
        }

        public int InsertEndereco(Endereco endereco)
        {
            string strInsert = $"insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, {_cidadeRepository.InsertCidade(endereco.Cidade)}, @DataCadastro); select cast(scope_identity() as int)";


            var db = new SqlConnection(_conn);

            return (int)db.ExecuteScalar(strInsert, endereco);
        }

        public Endereco GetEnderecoId(int id)
        {
            var db = new SqlConnection(_conn);

            string strSelect = $"select Id, Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro from Endereco where Id = {id}";

            var endereco = db.Query<Endereco, Cidade, Endereco>(strSelect, (endereco, cidade) =>
            {
                endereco.Cidade = cidade;
                return endereco;
            });
            return (Endereco)endereco;
        }

        public void UpdateEndereco(Endereco endereco)
        {
            string strUpdate = "update Endereco set Logradouro = @Logradouro, Numero = @Numero, Bairro = @Bairro, CEP = @CEP, Complemento = @Complemento where Id = @Id";

            var db = new SqlConnection(_conn);

            db.Execute(strUpdate, endereco);
        }
    }
}
