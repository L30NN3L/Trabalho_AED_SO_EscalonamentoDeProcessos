using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrabalhoIntegradoAEDSO
{
    public class Escalonador
    {
        // ponteiro útil para apontar o processo que será excutado
        private Processo execucao;

        // campo onde armazena um vetor de filas, útil para ocorrer o algoritmo de escalonamento
        private FilaProcessos[] filas;

        public FilaProcessos[] Filas { get => filas; set => filas = value; }
        
        public void AlgoritmoEscalonamento()
        {
            // Enquanto existir processos em qualquer fila, será executado este bloco
            while (!FilasVazias())
            {
                // para cada fila no vetor
                for(int i = 0; i < filas.Length; i++)
                {
                    // sendo que esta fila não esteja vazia
                    if (!filas[i].FilaVazia())
                    {
                        // será executado este bloco por ( (Quantidade de Filas) - (Prioridade - 1) ) vezes
                        // exemplo: Prioridade 1 executará 5 vezes e prioridade 5 executará 1 vez.
                        for (int j = 0; j < (filas.Length - i); j++)
                        {
                            //é escolhido o processo que será executado
                            Escolher(i);
                        }

                    }
                }

            }


        }

        public bool FilasVazias()
        {
            // Algoritmo para reconhecer se existe algum processo existente em qualquer fila
            int numProcessos = 0;
            for(int i = 0; i < filas.Length; i++)
            {
                numProcessos += filas[i].Count;
            }

            if(numProcessos > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void Escolher(int prioridade)
        {
            // De acordo com a prioridade da fila, um processo sairá desta fila para ser executado
            Processo processo = filas[prioridade].Desenfileirar();
            if(processo != null)
            {
                //Aqui é o caminho para a suposta "CPU"
                Executar(processo);
            }
            

        }

        private void Executar(Processo paraExecutar)
        {
            // Se o processo ainda tiver ciclos e tiver tempo para ser processado....
            if(paraExecutar.Ciclos > 0 && paraExecutar.Tempo > 0)
            {
                // processo é apontado na variável que é utilizada para processamento
                this.execucao = paraExecutar;

                // o tamanho do processo é convertido de float para int...
                int tamanhoProcesso = (int)(this.execucao.Tempo * 1000);

                // para determinar uma quantidade de vezes para ser processado através dos ciclos
                long numFor = tamanhoProcesso / this.execucao.Ciclos;
                
                // para cada iteração, o tempo de processamento em um processo diminuirá 1 millisegundo
                for (int i = 0; i < numFor; i++)
                {
                    // sendo que o processo precisa de conter tempo para ser processado
                    if (this.execucao.Tempo > 0)
                    {
                        Thread.Sleep(1); // para millisegundo...
                        this.execucao.Tempo -= 0.001f; // é decrementado o tempo de processamento do processo
                      //  Console.Clear();
                        this.execucao.ImprimeProcesso(); // os processos são impressos no Console para avaliar desempenho
                    }
                    else { return;  }
                }

                this.execucao.Ciclos--; // após o laço de iterações de processamento... 
                                        // o processo perde numero de ciclos por cada visita
                                        
                if (this.execucao.Ciclos > 0) //se o processo ainda tiver ciclos...
                {
                    //o processo retorna á sua fila de pronto
                    this.filas[this.execucao.Prioridade - 1].Enfileirar(this.execucao);
                }
                else
                {
                    // senão ele é apenas impresso no console
                    this.execucao.ImprimeProcesso();
                }

               
            }

            // variável sempre apontará para nulo quando terminar de processar determinado processo
            // processos "terminados" supostamente serão consumidos pelo Garbage Collector
            this.execucao = null;

        }

    }
}
