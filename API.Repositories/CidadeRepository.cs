using System.Data;
using System.Data.SqlClient;
using System.Text;
using API.Repositories.Interfaces;
using Dapper;
using Models;

namespace API.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";

        public List<Cidade> GetAll()
        {
            List<Cidade> listaCidades = new();

            using (var db = new SqlConnection(_conn))
            {
                var cidades = db.Query<Cidade>(Cidade.GETALL);
                listaCidades = (List<Cidade>)cidades;
            }

            return listaCidades;
        }

        public bool Insert(Cidade cidade)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Cidade.INSERT, cidade);
            }

            return true;
        }

        public int InsertCidade(Cidade cidade)
        {
            StringBuilder sb = new();
            sb.Append(Cidade.INSERT);
            sb.Append("; select cast(scope_identity() as int)");

            var db = new SqlConnection(_conn);

            return (int)db.ExecuteScalar(sb.ToString(), cidade);
        }

        public Cidade GetCidadeId(int id)
        {
            string strGetCidadeId = $"select Id, Descricao, DataCadastro from Cidade where Id = {id}";

            var db = new SqlConnection(_conn);

            IDataReader dr = db.ExecuteReader(strGetCidadeId);

            Cidade cidade = new();

            while (dr.Read())
            {
                cidade.Id = (int)dr["Id"];
                cidade.Descricao = (string)dr["Descricao"];
                cidade.DataCadastro = (DateTime)dr["DataCadastro"];
            }

            return cidade;
        }
    }
}