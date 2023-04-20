using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cidade
    {
        public static string GETALL = "select Id, Descricao, DataCadastro from Cidade";
        public static string INSERT = "insert into Cidade (Descricao, DataCadastro) values (@Descricao, @DataCadastro)";
        public static string GETCIDADE = "select Id, Descricao, DataCadastro from Cidade where Id = 1";

        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
