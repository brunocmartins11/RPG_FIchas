using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Fichas.Models
{
    public class FichaAtributo
    {
        public int IdFichaAtributo { get; set; }
        public int IdFicha { get; set; }
        public int IdAtributo { get; set; }
        public int Valor { get; set; }
        public int Modificador { get; set; }

        // Relacionamentos
        public Ficha Ficha { get; set; }
        public Atributo Atributo { get; set; }
    }

}
