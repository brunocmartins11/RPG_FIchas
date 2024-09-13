using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Fichas.Models;

namespace RPG_Fichas.Models
{
    public class Ficha
    {
        public int IdFicha { get; set; }
        public string NomePersonagem { get; set; }
        public int Nivel { get; set; }
        public string Classe { get; set; }
        public string Raca { get; set; }
        public string Antecedente { get; set; }
        public string Alinhamento { get; set; }
        public int PontosDeVida { get; set; }
        public int Ca { get; set; }
        public int Deslocamento { get; set; }

        // Relacionamentos

        public int? IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
