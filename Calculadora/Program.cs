using System.Collections.Generic;
using System.Threading;

namespace Calculadora
{

    //Calculadora para aulas de matemática... 
    public class Program
    {
        //Aqui crio uma lista independente, onde vou colocar os números para o cálculo
        static public List<decimal> lista = new List<decimal>();
        static public List<decimal> frequencia = new List<decimal>();

        //A função Main() é a principal e é por aqui que o programa começa...
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("pt-BR");

            //aqui chamo a função principal da classe ControladorDeFluxo...
            ControladorDeFluxo.Funcao();
        }
    }
}
