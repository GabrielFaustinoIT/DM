using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDM_TP04.Models
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Aprovado { get; set; }
    }
}
