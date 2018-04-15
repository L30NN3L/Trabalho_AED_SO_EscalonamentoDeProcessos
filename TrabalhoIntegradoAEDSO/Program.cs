using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TrabalhoIntegradoAEDSO
{
    class Program
    {
        static void Main(string[] args)
        {

            /* COMPOSIÇÃO DO GRUPO:

                Felipe Massato
                Hugo Leonel
                Luis Otávio
                Victória Lopes

             */

            //Instanciado objeto que observará o desempenho do escalonador
            Stopwatch sw = new Stopwatch();

            // Objeto inicia a observação de desempenho
            sw.Start();

            //Instanciação do escalonador
            Escalonador escalonador = new Escalonador();

            /* É executado o método obterProcessos() criado dentro de uma classe específica de manipulação de arquivo,
               este método retorna um vetor de Filas já preenchidas de processos */
            escalonador.Filas = IO.obterProcessos();

            // Escalonador inicia seu algoritmo de escalonamento
            escalonador.AlgoritmoEscalonamento();

            //objeto termina observação de desempenho do código
            sw.Stop();

            // é armazenado o tempo do desempenho
            TimeSpan tempo = sw.Elapsed;

            // é exibido o tempo de desempenho
            Console.WriteLine("Minutos:{0}", tempo.Minutes);

            // testa se não existe mais algum processo nas filas de processos
            Console.WriteLine("Filas Vazias: " + escalonador.FilasVazias() + "\n\n");


            Console.WriteLine("COMPOSIÇÃO DO GRUPO: \n\n"+

                " Felipe Massato\n" +
                " Hugo Leonel\n" +
                " Luis Otávio\n" +
                " Victória Lopes\n");

            Console.ReadLine();

        }
    }
}
