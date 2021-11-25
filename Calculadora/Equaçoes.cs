using System.Collections.Generic;
using System.Linq;
using DecimalMath;


namespace Calculadora
{
    public class Equaçoes
    {
        //aqui, essa classe deve ser a que mais te interessa, aqui tem as 4 funções de desvio, as 2 médias e as de coeficiente...
        public static decimal PopulaçaoNormal(out decimal mediaout)
        {
            //variável e constante....
            decimal media;
            const decimal potencia = 2;
            
            //chamo a função da média e recebo o valor que ela retorna...
            media = MediaAritmética();

            decimal Somatorio = 0;
            foreach (decimal valor in Program.lista)
            {
                var subtraçao = (valor - media);                

                //aqui somo a potenciação ao que tiver no Somatorio
                Somatorio = Somatorio + DecimalEx.Pow(subtraçao, potencia);                
            }
            //aqui divido Somatório e o valor que representa a quantidade de itens na lista
            var divisao = (Somatorio / (Program.lista.Count));

            //aqui eu passo a resposta da raiz quadrada da divisao
            decimal resposta = DecimalEx.Sqrt(divisao);

            mediaout = media;
            return resposta;
        }
        public static decimal PopulaçaoAgrupado(out decimal mediaout)
        {
            decimal media;
            const decimal potencia = 2;

            media = MediaPonderada(out decimal freqTotal);
            
            decimal Somatorio = 0;
            foreach (decimal valor in Program.lista)
            {
                //aqui pode parecer meio complicado mas na verdade, eu pego a frequencia que estiver na mesma posição que o valor e a uso na hora do loop forEach
                //já que a mesma posição das listas contém o valor e sua frequência. EX: lista[5] guarda um valor na posição 5, frequencia[5] guarda
                //o valor da frequencia, do elemento da lista[5]

                decimal freq = Program.frequencia[Program.lista.IndexOf(valor)];

                Somatorio = Somatorio + (DecimalEx.Pow((valor - media), potencia) * freq);
            }
            var divisao = (Somatorio / (freqTotal));

            decimal resposta = DecimalEx.Sqrt(divisao);

            mediaout = media;
            return resposta;
        }
        public static decimal AmostraAgrupado(out decimal mediaout)
        {
            decimal media = 0;
            const decimal potencia = 2;

            foreach (decimal dado in Program.lista)
            {
                media = media + dado;
            }
            media = media / Program.lista.Count;

            decimal Somatorio = 0;
            foreach (decimal valor in Program.lista)
            {
                decimal freq = Program.frequencia[Program.lista.IndexOf(valor)];

                Somatorio = Somatorio + (DecimalEx.Pow((valor - media), potencia) * freq);
            }

            decimal resposta = DecimalEx.Sqrt((Somatorio / (Program.lista.Count - 1)));
            mediaout = media;
            return resposta;
        }
        public static decimal AmostraNormal(out decimal mediaout)
        {
            decimal media = 0;

            foreach (decimal dado in Program.lista)
            {
                media = media + dado;
            }
            media = media / Program.lista.Count;

            decimal Somatorio = 0;
            foreach (decimal valor in Program.lista)
            {
                Somatorio = Somatorio + (DecimalEx.Pow((valor - media), 2));
            }

            decimal resposta = DecimalEx.Sqrt((Somatorio / (Program.lista.Count - 1)));
            mediaout = media;
            return resposta;
        }
        public static decimal CoeficienteVariaçao(decimal media, decimal desvio)
        {
            return ((desvio / media)*100);
        }

        public static decimal MediaAritmética()
        {
            decimal media = 0;

            foreach (decimal dado in Program.lista)
            {
                media = media + dado;
            }
            media = (media / Program.lista.Count);
            return media;
        }
        public static decimal MediaPonderada(out decimal frequenciafinal)
        {
            decimal media = 0;
            decimal freqFinal = 0;
            int contador = 0;

            foreach (decimal valor in Program.lista)
            {
                //como aqui eu devo passar por todos os valores de frequencia, eu uso uma variavel contador,
                //lembrando que sempre em uma lista, a primeira posição é 0 e que contador++ equivale a contador + 1;

                decimal freq = Program.frequencia[contador];

                media = media + (freq * valor);
                contador++;
            }
            foreach (decimal item in Program.frequencia)
            {
                freqFinal = freqFinal + item;
            }
            media = media / freqFinal;

            frequenciafinal = freqFinal;
            return media;
        }
        public static decimal CoeficienteAssimetria(decimal desvio, decimal media, out string orientaçao)
        {
            //aqui eu uso somente a equação com a mediana, já que fazer a moda ficou muito complicado pra mim
            
            var mediana = Mediana();
            string orientaçaoDaAssimetria;
            decimal subtraçao = (media - mediana);

            var resposta = ((3 * subtraçao) / desvio);

            //aqui vejo a orientação da simetria
            if (media - mediana == 0)
            {
                orientaçaoDaAssimetria = "simétrica";
            }
            else if(media - mediana > 0)
            {
                orientaçaoDaAssimetria = "Assimétrica á direita (positivo)";
            }
            else
            {
                orientaçaoDaAssimetria = "Asssimétrica á esquerda (negativo)";
            }

            //aqui identifico o grau de simetria; positivo
            if (resposta >= 1)
            {
                orientaçaoDaAssimetria += ", grau forte";
            }
            else if (resposta >= (decimal)0.15 & resposta < 1)
            {
                orientaçaoDaAssimetria += ", grau moderado";
            }
            else if (resposta < (decimal)0.15 & resposta > 0)
            {
                orientaçaoDaAssimetria += ", grau fraco";
            }

            //negativo
            else if (resposta <= -1)
            {
                orientaçaoDaAssimetria += ", grau forte";
            }
            else if (resposta <= (decimal)-0.15 & resposta < -1)
            {
                orientaçaoDaAssimetria += ", grau moderado";
            }
            else if (resposta > (decimal)-0.15 & resposta < 0)
            {
                orientaçaoDaAssimetria += ", grau fraco";
            }
            else
                orientaçaoDaAssimetria += ", sem grau definido";

            orientaçao = orientaçaoDaAssimetria;

            return resposta;
        }

        public static decimal Mediana()
        {
            var tamanho = Program.lista.Count();
            decimal resultado;

            //aqui eu vejo se o resto da divisão entre o tamanho e 2 equivale 0, significando que o tamanho é par

            if (tamanho % 2 == 0)
            {
                List<int> itensCentrais = new List<int>();

                var indice = tamanho / 2;
                itensCentrais.Add(indice + 1);
                itensCentrais.Add(indice - 1);
                //aqui eu divido o tamanho e pego o valor como referencia para achar os valores centrais e os adiciono na lista ItensCentrais

                decimal X, Y;
                X = Program.lista[itensCentrais[0]];
                Y = Program.lista[itensCentrais[1]];

                //aqui eu atribuo os valores que achei á variaveis e termino a equação
                resultado = ((X + Y) / 2);
                return resultado;
            }
            else
            {
                //se o tamanho não for par, significa que existe um valor mediano, aqui eu só acho ele e o retorno

                var indice = (tamanho - 1) / 2;
                resultado = Program.lista[indice + 1];
                return resultado;
            }            
        }
    }
}
