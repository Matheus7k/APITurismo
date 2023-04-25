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
        public static string GETALL = "select c.Id, c.Nome, c.Telefone, c.DataCadastro, e.Id, e.Logradouro, e.Numero, e.bairro, e.CEP, e.Complemento, ci.Id," +
            " ci.Descricao from Cliente c, Endereco e, Cidade ci where c.IdEndereco = e.Id and e.IdCidade = ci.Id";

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public Endereco Endereco { get; set; }
    }
}
