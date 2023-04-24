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
    public class PacoteRepository : IPacoteRepository
    {
        private readonly string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\APITurismo\dbApiTurismo.mdf";
        private readonly HotelRepository _hotelRepository = new();
        private readonly PassagemRepository _passagemRepository = new();
        private readonly ClienteRepository _clienteRepository = new();

        public List<Pacote> GetAll()
        {
            var db = new SqlConnection(_conn);

            db.Open();

            IDataReader dr = db.ExecuteReader(Pacote.GETALL);

            List<Pacote> pacotes = new();

            while (dr.Read())
            {
                Pacote pacote = new();

                pacote.Id = (int)dr["Id"];
                pacote.Hotel = _hotelRepository.GetHotelId((int)dr["IdHotel"]);
                pacote.Passagem = _passagemRepository.GetPassagemId((int)dr["IdPassagem"]);
                pacote.DataCadastro = (DateTime)dr["DataCadastro"];
                pacote.Valor = (decimal)dr["Valor"];
                pacote.Cliente = _clienteRepository.GetClienteId((int)dr["IdCliente"]);

                pacotes.Add(pacote);
            }

            db.Close();

            return pacotes;
        }

        public bool Insert(Pacote pacote)
        {
            string strInsert = $"insert into Pacote (IdHotel, IdPassagem, DataCadastro, Valor, IdCliente) " +
                $"values ({_hotelRepository.InsertHotel(pacote.Hotel)}, {_passagemRepository.InsertPassagem(pacote.Passagem)}, @DataCadastro," +
                $" @Valor, {_clienteRepository.InsertCliente(pacote.Cliente)})";

            var db = new SqlConnection(_conn);

            db.Open();

            db.Execute(strInsert, pacote);

            db.Close();

            return true;
        }

        public void Delete(int id)
        {
            string strDelete = $"delete from Pacote where Id = {id}";

            var db = new SqlConnection(_conn);

            db.Execute(strDelete);
        }

        public void UpdatePacote(Pacote pacote)
        {
            string strUpdate = "update Pacote set Valor = @Valor where Id = @Id";

            var db = new SqlConnection(_conn);

            db.Execute(strUpdate, pacote);
        }
    }
}
