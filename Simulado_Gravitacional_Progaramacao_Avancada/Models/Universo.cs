using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulado_Gravitacional_Progaramacao_Avancada.Models
{
    class Universo
    {
        public List<Corpo> Corpos { get; set; }
        private const double G = 6.674184e-11;

        public Universo()
        {
            Corpos = new List<Corpo>();
        }
        public void ProximoPasso(double deltaTime)
        {

        }
    }
}
