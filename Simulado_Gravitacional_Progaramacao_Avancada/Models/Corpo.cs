using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulado_Gravitacional_Progaramacao_Avancada.Models
{
    class Corpo
    {
        public string Nome { get; set; }
        public double Massa { get; set; }
        public double Raio { get; set; }
        public double Densidade { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double VelX { get; set; }
        public double VelY { get; set; }

        public static Corpo operator +(Corpo c1, Corpo c2)
        {
            Corpo cp = new Corpo();
            cp.Massa = c1.Massa + c2.Massa;

            return cp;
        }

        

    }
}
