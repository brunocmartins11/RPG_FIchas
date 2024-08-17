using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Fichas.Models
{
    public class FichaEquipamento
    {
        public int IdFichaEquipamento { get; set; }
        public int IdFicha { get; set; }
        public int IdEquipamento { get; set; }
        public int Quantidade { get; set; }

        // Relacionamentos
        public Ficha Ficha { get; set; }
        public Equipamento Equipamento { get; set; } // A classe Equipamento deve estar acessível aqui
    }
}
