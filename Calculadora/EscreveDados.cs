using System;

namespace Calculadora
{
    public class EscreveDados
    {
        //aqui escreve o resultado da tela e depois voltamos para a classe Program, e como lá não tem mais nada na função Main(), o programa termina...
        static public void Funcao(decimal func, decimal media)
        {
            Console.Clear();
            string orientação;

            Console.WriteLine("Seus dados: ");
            int a = 1;
            if (Program.frequencia.Count == 0)
            {
                foreach (decimal dado in Program.lista)
                {
                    Console.WriteLine(a + " - :" + dado.ToString());
                    a++;
                }
            }
            else
            {
                foreach (decimal dado in Program.lista)
                {
                    Console.WriteLine(a + " - :" + dado.ToString() + " Freq: " + Program.frequencia[(a - 1)].ToString());
                    a++;
                }
            }

            Console.WriteLine("---------");
            Console.WriteLine("Enter para continuar...");
            Console.ReadKey();

            Console.WriteLine();

            var resposta = func;
            resposta = Decimal.Round(resposta, 4);

            media = Decimal.Round(media, 4);

            var CV = Equaçoes.CoeficienteVariaçao(media, resposta);
            CV = Decimal.Round(CV, 4);

            var CA = Equaçoes.CoeficienteAssimetria(resposta, media, out orientação);
            CA = Decimal.Round(CA, 4);

            Console.WriteLine("Resposta da equação:");
            Console.WriteLine(resposta.ToString());
            Console.WriteLine("---------");
            Console.WriteLine("Média: " + media);
            Console.WriteLine("---------");
            Console.WriteLine("Coeficiente de Variação: ");
            Console.WriteLine(CV.ToString() + "%");
            Console.WriteLine("---------");
            Console.WriteLine("Coeficiente de Assimetria (via mediana):");
            Console.WriteLine(CA.ToString());
            Console.WriteLine("Orientação do Coeficiente: " + orientação);
            Console.ReadKey();
        }
    }
}
