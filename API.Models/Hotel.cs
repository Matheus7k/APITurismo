using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hotel
    {
        public static string INSERT = "insert into Hotel (Nome, IdEndereco, DataCadastro, Valor) values (@Nome, @Endereco, @DataCadastro, @Valor)";
        public static string GETALL = "select Id, Nome, IdEndereco, DataCadastro, Valor from Hotel";

        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
    }
}
