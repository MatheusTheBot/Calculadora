using System;
using System.Text.RegularExpressions;

namespace Calculadora
{
    public class RecebeDados
    {
        public static void FuncaoNormal()
        {
            Console.Clear();

            Console.WriteLine("Pode começar a inserir os dados..." + Environment.NewLine +
            "insira 'X' para continuar com os dados atuais...");
            Console.WriteLine("Para inserir multiplos dados, coloque um espaço para dividi-los...");
            int numerodainformação = 1;
            byte trava = 0;

            while (trava == 0)
            {
                string entrada;
                string[] intermediaria;

                try
                {
                    Console.Write(numerodainformação + ": - ");
                    entrada = Console.ReadLine();

                    entrada = Regex.Replace(entrada, ".", ",");
                    entrada = Regex.Replace(entrada, "/", " ");
                    entrada = Regex.Replace(entrada, "\\s+", " ");

                    //aqui eu já pego a variável e a manipulo, tirando espaços desnecessários, convertendo acentuação e o organizando

                    if (entrada == "X" || entrada == "x")
                    {
                        break;
                    }

                    if (entrada.Contains(" "))
                    {
                        intermediaria = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string dado in intermediaria)
                        {
                            Program.lista.Add(decimal.Parse(dado));
                        }
                        Console.Clear();
                        Console.WriteLine("Dados adicionados nesta leva: ");
                        foreach (string dado in intermediaria)
                        {
                            Console.WriteLine(numerodainformação + ": - " + dado.ToString());
                            numerodainformação++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pode continuar digitando valores...");

                    }
                    else
                    {
                        Program.lista.Add(decimal.Parse(entrada));
                        numerodainformação++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Opa, deu um erro, mas bora voltar... (os dados foram salvos)");
                    Console.WriteLine("Os dados salvos: " + Program.lista.ToString());
                    Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace + Environment.NewLine + e.Source + Environment.NewLine + e.Data);
                    Console.ReadKey();
                    ControladorDeFluxo.Funcao();
                }
                //nesse bloco de código acima, eu recebo os dados, os divido e adiciono naquelas listas do começo, em ordem e vejo se deu erro
                //depois que o processo é feito, a gente volta lá pro ControladorDeFluxo...
            }
        }
        public static void FuncaoAgrupada()
        {
            //nessa função, o processo é quase o mesmo que a outra, mas aqui aceita as frequências junto

            Console.Clear();

            Console.WriteLine("Pode começar a inserir os dados e sua frequência..." + Environment.NewLine + "Exemplo: 12-5 ou 12 (para elementos unicos)..." + Environment.NewLine +
            "insira 'X' para continuar com os dados atuais...");
            Console.WriteLine("Para inserir multiplos dados, coloque um espaço para dividi-los...");

            int numerodainformação = 1;
            byte trava = 0;

            while (trava == 0)
            {
                string entrada;
                string[] interLista;

                try
                {
                    Console.Write(numerodainformação + ": - ");
                    entrada = Console.ReadLine();

                    entrada = Regex.Replace(entrada, "\\.", ",");
                    entrada = Regex.Replace(entrada, "/", " ");
                    entrada = Regex.Replace(entrada, "\\s+", " ");

                    if (entrada == "X" || entrada == "x")
                    {
                        break;
                    }

                    if (entrada.Contains(" "))
                    {
                        interLista = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string dado in interLista)
                        {
                            if (dado.Contains("-"))
                            {
                                Program.frequencia.Add(decimal.Parse(dado.Substring(dado.IndexOf("-") + 1)));
                                Program.lista.Add(decimal.Parse(dado.Substring(0, dado.IndexOf("-"))));                                
                            }
                            else
                            {
                                Program.lista.Add(decimal.Parse(dado));
                                Program.frequencia.Add(1);                                
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("Dados adicionados nesta leva: ");
                        foreach (string dado in interLista)
                        {
                            Console.WriteLine(numerodainformação + ": - " + Program.lista[numerodainformação - 1].ToString() + 
                                              " Frequência: " + Program.frequencia[numerodainformação - 1].ToString());
                            numerodainformação++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pode continuar digitando valores...");
                        
                    }
                    else
                    {
                        if (entrada.Contains("-"))
                        {
                            Program.frequencia.Add(decimal.Parse(entrada.Substring(entrada.IndexOf("-") + 1)));
                            Program.lista.Add(decimal.Parse(entrada.Substring(0, entrada.IndexOf("-"))));
                            numerodainformação++;
                        }
                        else
                        {
                            Program.lista.Add(decimal.Parse(entrada));
                            Program.frequencia.Add(1);
                            numerodainformação++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Opa, deu um erro, mas bora voltar... (os dados foram salvos)");
                    Console.WriteLine("Os dados salvos:        " + Program.lista.ToString());
                    Console.WriteLine("Frequencias (em ordem): " + Program.frequencia.ToString());
                    Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace + Environment.NewLine + e.Source + Environment.NewLine + e.Data);
                    Console.ReadKey();
                    ControladorDeFluxo.Funcao();
                }
            }
        }
    }
}
