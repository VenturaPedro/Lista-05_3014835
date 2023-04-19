using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;


namespace Lista5{
    class Lista05{

        static void Exercicio1(){
            /*a classe System.Environment para acessar informações sobre a máquina em que o código C# está sendo executado. Alguns exemplos de informações que você pode obter são:
                - Nome do computador: Environment.MachineName
                - Nome do usuário atual: Environment.UserName
                - Diretório inicial do usuário: Environment.UserProfile
                - Versão do sistema operacional: Environment.OSVersion
                - Diretório atual de trabalho: Environment.CurrentDirectory

                 Além disso, você também pode usar a classe System.Management.ManagementObjectSearcher para obter 
                 informações mais detalhadas sobre o hardware do sistema. */

            string NomeComputador, NomeUsuario, Periodo = " ";

            DateTime Data;

            NomeComputador = Environment.MachineName;
            NomeUsuario = Environment.UserName;
            Data = DateTime.Today;
            DayOfWeek DiaSemana = DateTime.Now.DayOfWeek;

            CultureInfo cultura = new CultureInfo("pt-BR");
            string nomeDiaSemana = cultura.DateTimeFormat.GetDayName(DiaSemana);
            string mesAtual = DateTime.Now.ToString("MMMM");
            int Dia = Data.Day;
            int Mes = Data.Month;
            int Ano = Data.Year;
            int Hora = DateTime.Now.Hour;



            if (Hora >= 6 || Hora <= 12){
                Periodo = "Bom Dia!";
            }
            else if (Hora > 12 || Hora <= 18){
                    Periodo = "Boa Tarde!";
            }
            else {
                Periodo = "Boa Noite!";
            }

            string messagem = string.Format("{0} {1} ", Periodo, NomeUsuario);
            string messagem1 = string.Format("Você está utilizando a Maquina {0}", NomeComputador);
            string messagem2 = string.Format("Hojé é {0}, {1} de {2} de {3} ", nomeDiaSemana, Dia, mesAtual, Ano);
            Console.WriteLine(messagem);
            Console.WriteLine(messagem1);
            Console.WriteLine(messagem2);

        }
        static void Exercicio2(){
            string Texto = "3.2649195;9300419;8240871%2791073;3917173;9851056#9925124,4763040.0965918;93\r\n09297%1010589;5634190,7310819#0258142,0929306.0592849#2628868;1392209;49417\r\n11%6802169%3655235.1180040#6889981;4529558,3395538;3095206.8162707,5306168\r\n%3277453.0758859,8014857.6402319%2329297.7429486#4680437%5500518#7865391\r\n#2873377#8086382#5447877%5426116,5085634%7224325#5798439,1178516%431207\r\n2.0796522.9304179;0434651%6509028#4787438#8491024%3015385,5290222%529492\r\n7%5561596.0460024%1321386,1368206;3408249,6508625.7336954%8002371;7576263\r\n%3747889#7408701%0201462#4900590;9622169#0048623%4969522%4528884#49907\r\n86.3003232;6365305%3586311.5647329%3264194;2114295,3171009;9876958,4020305,\r\n1632979%0031475.2552181%2602640.5303671.8059160%4988532.4693670%9150725,3\r\n340225,6376627.0780785;0990199.4341820.0463039%3299347,7393254%4523854#660\r\n3120%9368998#5944279,9085068#8137433,3239866,6379195#7431356.5898614.58104\r\n97.3487996#5400022#6149677,8533754%6088682%2032031.6332587,7284531#923933\r\n1%8866454,3964222#3314980#8428029.2546101;7316677%0460178;8789264;9316756.\r\n1965642;7585590,7383219;9062609,8482023,5717895;2684729;0466794%5370084,0484\r\n922;4599156,5815576%3414149.1343440#16129";

            string NovoTexto = Regex.Replace(Texto, @"\D+", "");

            char[] NovoTextoVetor = NovoTexto.ToCharArray(); //ToCharArray

            int[] numerosInteiros = new int[NovoTextoVetor.Length];


            for (int i = 0; i < NovoTextoVetor.Length; i++){
                numerosInteiros[i] = int.Parse(NovoTextoVetor[i].ToString());
            }
            long maiorProduto = 0;
            int[] numerosConsecutivos = new int[5];

            // Percorre o array de inteiros em busca da sequência de 5 números com o maior produto
            for (int i = 0; i < numerosInteiros.Length - 4; i++){
                long produto = numerosInteiros[i] * numerosInteiros[i + 1] * numerosInteiros[i + 2] * numerosInteiros[i + 3] * numerosInteiros[i + 4];
                if (produto > maiorProduto){
                    maiorProduto = produto;
                    numerosConsecutivos[0] = numerosInteiros[i];
                    numerosConsecutivos[1] = numerosInteiros[i + 1];
                    numerosConsecutivos[2] = numerosInteiros[i + 2];
                    numerosConsecutivos[3] = numerosInteiros[i + 3];
                    numerosConsecutivos[4] = numerosInteiros[i + 4];
                }
            }

            Console.WriteLine("Os 5 números consecutivos com maior produto são:");
            Console.WriteLine(string.Join(", ", numerosConsecutivos));

        }
        static void Exercicio3(){
            string Texto = "3.2649195;9300419;8240871%2791073;3917173;9851056#9925124,4763040.0965918;93\r\n09297%1010589;5634190,7310819#0258142,0929306.0592849#2628868;1392209;49417\r\n11%6802169%3655235.1180040#6889981;4529558,3395538;3095206.8162707,5306168\r\n%3277453.0758859,8014857.6402319%2329297.7429486#4680437%5500518#7865391\r\n#2873377#8086382#5447877%5426116,5085634%7224325#5798439,1178516%431207\r\n2.0796522.9304179;0434651%6509028#4787438#8491024%3015385,5290222%529492\r\n7%5561596.0460024%1321386,1368206;3408249,6508625.7336954%8002371;7576263\r\n%3747889#7408701%0201462#4900590;9622169#0048623%4969522%4528884#49907\r\n86.3003232;6365305%3586311.5647329%3264194;2114295,3171009;9876958,4020305,\r\n1632979%0031475.2552181%2602640.5303671.8059160%4988532.4693670%9150725,3\r\n340225,6376627.0780785;0990199.4341820.0463039%3299347,7393254%4523854#660\r\n3120%9368998#5944279,9085068#8137433,3239866,6379195#7431356.5898614.58104\r\n97.3487996#5400022#6149677,8533754%6088682%2032031.6332587,7284531#923933\r\n1%8866454,3964222#3314980#8428029.2546101;7316677%0460178;8789264;9316756.\r\n1965642;7585590,7383219;9062609,8482023,5717895;2684729;0466794%5370084,0484\r\n922;4599156,5815576%3414149.1343440#16129";

            string NovoTexto = Regex.Replace(Texto, @"\D+", "");

            int somaTotal = 0;

            for (int i = 0; i < Texto.Length - 1; i++){
                if (NovoTexto.Substring(i, 2) == "11"){
                    string substring = NovoTexto.Substring(0, i + 2);
                    int somaSubstring = 0;
                    foreach (char c in substring){
                        if (Char.IsDigit(c)){
                            somaSubstring += int.Parse(c.ToString());
                        }
                    }
                    Console.WriteLine(substring + " - Soma: " + somaSubstring);
                    somaTotal += somaSubstring;
                }
            }
            Console.WriteLine("Soma total: " + somaTotal);
        }

        static int Main(string[] args){
            int ValorExercicio;

            do{
                Console.WriteLine("---------------------------------------- ");
                Console.WriteLine("----ENTRE COM O VALOR DO EXERCICIO------ ");
                Console.WriteLine("---------------------------------------- ");
                Console.WriteLine("---------------------------------------- ");
                Console.WriteLine("Apresentação--------------------------- 1 ");
                Console.WriteLine("VMostrar conteudo numerico acima------- 2 ");
                Console.WriteLine("cadeia de caracteres “11” ------------- 3 ");
                Console.WriteLine("----------------------------------------\n ");
                Console.WriteLine("Qual sera o exercicio da vez?: ");

                ValorExercicio = int.Parse(Console.ReadLine());

                switch (ValorExercicio){
                    case 0:
                        Console.WriteLine(" Até a próxima!");
                        Console.ReadKey();
                        break;
                    case 1:
                        Exercicio1();
                        break;
                    case 2:
                        Exercicio2();
                        break;
                    case 3:
                        Exercicio3();
                        break;
                    default:
                        Console.WriteLine("O numero não corresponde a lista de exercicios");
                        Console.ReadKey();
                        break;
                }
            } while (ValorExercicio != 0);
            return 0;
        }
    }
}
