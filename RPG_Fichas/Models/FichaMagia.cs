using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Fichas.Models
{
    public class FichaMagia
    {
        public int IdFichaMagia { get; set; }
        public int IdFicha { get; set; }
        public int IdMagia { get; set; }
        public int Dano { get; set; }

        // Relacionamentos
        public Ficha Ficha { get; set; }
        public Magia Magia { get; set; }
    }
}
