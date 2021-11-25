using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Mensagens
    {
        public static void Erro()
        {
            Console.WriteLine("Opa, deu um erro aqui, vou recomeçar...");
            Console.WriteLine("Enter para continuar...");
            Console.ReadKey();
            ControladorDeFluxo.Funcao();
        }
        public static void Seletor1()
        {
            Console.Clear();

            Console.WriteLine("Calculadora");
            Console.WriteLine("/-**-*-*-*-**-/");
            Console.WriteLine("0 - Dados agrupados");
            Console.WriteLine("1 - Dados não agrupados");
        }
        public static void Seletor2()
        {
            Console.Clear();

            Console.WriteLine("Calculadora");
            Console.WriteLine("/-**-*-*-*-**-/");
            Console.WriteLine("0 - Desvio para populações");
            Console.WriteLine("1 - Desvio para amostras");
        }
    }
}
