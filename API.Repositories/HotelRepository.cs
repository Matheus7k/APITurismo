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

                hotel.Id = (int)dr["Id"];
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

        public int InsertHotel(Hotel hotel)
        {
            string strInsert = $"insert into Hotel (Nome, IdEndereco, DataCadastro, Valor) values (@Nome, {_enderecoRepository.InsertEndereco(hotel.Endereco)}, @DataCadastro, @Valor);" +
                $" select cast(scope_identity() as int)";

            var db = new SqlConnection(_conn);

            return (int)db.ExecuteScalar(strInsert, hotel);
        }

        public Hotel GetHotelId(int id)
        {
            string strSelect = $"select Id, Nome, IdEndereco, DataCadastro, Valor from Hotel where Id = {id}";

            var db = new SqlConnection(_conn);

            IDataReader dr = db.ExecuteReader(strSelect);

            Hotel hotel = new();

            while (dr.Read())
            {
                hotel.Id = (int)dr["Id"];
                hotel.Nome = (string)dr["Nome"];
                hotel.Endereco = _enderecoRepository.GetEnderecoId((int)dr["IdEndereco"]);
                hotel.DataCadastro = (DateTime)dr["DataCadastro"];
                hotel.Valor = (decimal)dr["Valor"];
            }

            return hotel;
        }

        public void UpdateHotel(Hotel hotel)
        {
            string strUpdate = "update Hotel set Nome = @Nome, Valor = @Valor where Id = @Id";

            var db = new SqlConnection(_conn);

            db.Execute(strUpdate, hotel);
        }
    }
}
