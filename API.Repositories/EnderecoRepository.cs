using Dapper;
using Models;
using System.Data.SqlClient;
using API.Repositories.Interfaces;
using System.Data;
using System.Text;
using System.Runtime.ConstrainedExecution;

namespace API.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";
        private CidadeRepository _cidadeRepository = new();

        public bool Insert(Endereco endereco)
        {
            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(Endereco.INSERT, new
            {
                endereco.Logradouro,
                endereco.Numero,
                endereco.Bairro,
                endereco.CEP,
                endereco.Complemento,
                IdCidade = _cidadeRepository.InsertCidade(endereco.Cidade),
                endereco.DataCadastro
            });

            db.Close();

            return true;
        }

        public List<Endereco> GetAll()
        {
            List<Endereco> listaEnderecos = new();

            var db = new SqlConnection(_conn);

            db.Open();

            IDataReader dr = db.ExecuteReader(Endereco.GETALL);

            while (dr.Read())
            {
                Endereco endereco = new Endereco();

                endereco.Id = (int)dr["Id"];
                endereco.Logradouro = (string)dr["Logradouro"];
                endereco.Numero = (int)dr["Numero"];
                endereco.Bairro = (string)dr["Bairro"];
                endereco.CEP = (string)dr["CEP"];
                endereco.Complemento = (string)dr["Complemento"];
                endereco.Cidade = _cidadeRepository.GetCidadeId((int)dr["IdCidade"]);
                endereco.DataCadastro = (DateTime)dr["DataCadastro"];

                listaEnderecos.Add(endereco);
            }

            db.Close();

            return listaEnderecos;
        }

        public int InsertEndereco(Endereco endereco)
        {
            StringBuilder sb = new();
            sb.Append(Endereco.INSERT);
            sb.Replace("@Cidade", _cidadeRepository.InsertCidade(endereco.Cidade).ToString());
            sb.Append("; select cast(scope_identity() as int)");


            var db = new SqlConnection(_conn);

            return (int)db.ExecuteScalar(sb.ToString(), endereco);
        }

        public Endereco GetEnderecoId(int id)
        {
            var db = new SqlConnection(_conn);

            string strTeste = $"select Id, Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro from Endereco where Id = {id}";

            IDataReader dr = db.ExecuteReader(strTeste);

            Endereco endereco = new();

            while (dr.Read())
            {
                endereco.Id = (int)dr["Id"];
                endereco.Logradouro = (string)dr["Logradouro"];
                endereco.Numero = (int)dr["Numero"];
                endereco.Bairro = (string)dr["Bairro"];
                endereco.CEP = (string)dr["CEP"];
                endereco.Complemento = (string)dr["Complemento"];
                endereco.Cidade = _cidadeRepository.GetCidadeId((int)dr["IdCidade"]);
                endereco.DataCadastro = (DateTime)dr["DataCadastro"];
            }

            return endereco;
        }
    }
}
