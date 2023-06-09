﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Passagem
    {
        public static string GETALL = "select Id, Origem, Destino, IdCliente, [Data], Valor from Passagem";

        public int Id { get; set; }
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
