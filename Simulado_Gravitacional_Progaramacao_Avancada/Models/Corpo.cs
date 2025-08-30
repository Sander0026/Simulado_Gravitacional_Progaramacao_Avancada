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


        public Corpo(string nome, double massa, double raio, double densidade, double posX, double posY, double velX, double velY)
        {
            this. Nome = nome;
            this.Massa = massa;
            this.Raio = raio;
            this.Densidade = densidade;
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
        }

        // Sobrecarga do operador de soma (+) para simular uma colisão perfeitamente inelástica (fusão) entre dois corpos.
        public static Corpo operator +(Corpo c1, Corpo c2)
        {
            // Tratamento de casos onde um dos corpos pode ser nulo
            if (c1 == null) return c2;
            if (c2 == null) return c1;

            double massaTotal = c1.Massa + c2.Massa;

            // Previne divisão por zero se a massa total for 0.
            if (massaTotal <= 0)
            {
                // Aqui, retornaremos o corpo de maior massa para evitar que a simulação quebre.
                return c1.Massa > c2.Massa ? c1 : c2;
            }

            // Velocidade: Baseada na conservação da quantidade de movimento (m1*v1 + m2*v2 = m_total*v_final).
            double velFinalX = (c1.Massa * c1.VelX + c2.Massa * c2.VelX) / massaTotal;
            double velFinalY = (c1.Massa * c1.VelY + c2.Massa * c2.VelY) / massaTotal;

            // Posição: O novo corpo se posiciona no centro de massa do sistema.
            double posFinalX = (c1.Massa * c1.PosX + c2.Massa * c2.PosX) / massaTotal;
            double posFinalY = (c1.Massa * c1.PosY + c2.Massa * c2.PosY) / massaTotal;

            double area1 = c1.Massa / c1.Densidade;
            double area2 = c2.Massa / c2.Densidade;
            double areaTotal = area1 + area2;

            double densidadeFinal = massaTotal / areaTotal;
            double raioFinal = Math.Sqrt(areaTotal / Math.PI);

            Corpo corpoResultante = new Corpo(
                nome: $"{c1.Nome}-{c2.Nome}",
                massa: massaTotal,
                raio: raioFinal,
                densidade: densidadeFinal,
                posX: posFinalX,
                posY: posFinalY,
                velX: velFinalX,
                velY: velFinalY
            );
            return corpoResultante;
        }
    }
}
