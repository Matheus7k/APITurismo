using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        public static string INSERT = "insert into Cliente (Nome, Telefone, IdEndereco, DataCadastro) values (@Nome, @Telefone, @Endereco, @DataCadastro)";
        public static string GETALL = "select Id, Nome, Telefone, IdEndereco, DataCadastro from Cliente";

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
