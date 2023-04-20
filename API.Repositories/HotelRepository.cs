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
    public class HotelRepository : IHotelRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";
        private EnderecoRepository _enderecoRepository = new();

        public List<Hotel> GetAll()
        {
            var db = new SqlConnection(_conn);

            db.Open();

            IDataReader dr = db.ExecuteReader(Hotel.GETALL);

            List<Hotel> hoteis = new();

            while (dr.Read())
            {
                Hotel hotel = new();

                hotel.Id = 0;
                hotel.Nome = (string)dr["Nome"];
                hotel.Endereco = _enderecoRepository.GetEnderecoId((int)dr["IdEndereco"]);
                hotel.DataCadastro = (DateTime)dr["DataCadastro"];
                hotel.Valor = (decimal)dr["Valor"];

                hoteis.Add(hotel);
            }

            return hoteis;
        }

        public bool Insert(Hotel hotel)
        {
            string strInsert = $"insert into Hotel (Nome, IdEndereco, DataCadastro, Valor) values (@Nome, {_enderecoRepository.InsertEndereco(hotel.Endereco)}, @DataCadastro, @Valor)";

            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(strInsert, hotel);

            db.Close();

            return true;
        }
    }
}
