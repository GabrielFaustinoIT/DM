using System;
using System.Collections.Generic;
using System.Text;

namespace TRAB2.Models
{
    class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
