using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Fichas.Models
{
    public class FichaHabilidade
    {
        public int IdFichaHabilidade { get; set; }
        public int IdFicha { get; set; }
        public int IdHabilidade { get; set; }
        public int Valor { get; set; }
        public bool Proficiencia { get; set; }

        // Relacionamentos
        public Ficha Ficha { get; set; }
        public Habilidade Habilidade { get; set; }
    }

}
