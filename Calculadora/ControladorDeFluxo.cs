using System;

namespace Calculadora
{
    public class ControladorDeFluxo
    {
        public static void Funcao()
        {
            decimal media;
            int dadosAgrupados;
            int tipoDeDesvio;

            Mensagens.Seletor1();
            
            //aqui declarei variáveis e mostrei umas mensagens na tela;
            //depois vou receber a informação do usuário e ver se não dá erro

            try
            {
                dadosAgrupados = int.Parse(Console.ReadLine());
                if (dadosAgrupados != 1 && dadosAgrupados != 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Mensagens.Erro();
                throw;
            }

            //mesma coisa, pego a informação e vejo se é válida...

            Mensagens.Seletor2();
            try
            {
                tipoDeDesvio = int.Parse(Console.ReadLine());
                if (tipoDeDesvio != 1 && tipoDeDesvio != 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Mensagens.Erro();
                throw;
            }

            /*
            meio dificil de entender, mas aqui vai uma colinha:

            para dados agrupados, primeira variavel deve ser false (0);
            para não agrupados, primeira variavel deve ser true (1);
            para dados população, segunda variavel deve ser false (0);
            para amostras, segunda variavel deve ser true (1);
            */

            //aqui chamo uma das 2 funções que recebe os dados, cada uma tem sua particularidade
            if (dadosAgrupados == 0)
            {
                RecebeDados.FuncaoAgrupada();
            }
            else
            {
                RecebeDados.FuncaoNormal();
            }
            
            //depois que recebi os dados, vejo qual a combinação de 0s e 1ns para chamar a função de cálculo correta...
            //e que o valor já é passado para a função que escreve o resultado na tela...

            switch ((dadosAgrupados, tipoDeDesvio))
            {
                //agrupados
                case (0, 1):
                    EscreveDados.Funcao(Equaçoes.AmostraAgrupado(out media), media);
                    break;
                case (0, 0):
                    EscreveDados.Funcao(Equaçoes.PopulaçaoAgrupado(out media), media);
                    break;
                //não agrupados
                case (1, 1):
                    EscreveDados.Funcao(Equaçoes.AmostraNormal(out media), media);
                    break;
                case (1, 0):
                    EscreveDados.Funcao(Equaçoes.PopulaçaoNormal(out media), media);
                    break;
            }
        }
    }
}
