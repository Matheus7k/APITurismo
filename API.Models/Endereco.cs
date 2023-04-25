using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Endereco
    {
        public static string INSERT = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @Cidade, @DataCadastro)";
        public static string GETALL = "select e.Id, e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, c.Id, c.Descricao from Endereco e inner join Cidade c on e.IdCidade = c.Id";

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade  { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
