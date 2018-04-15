using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoIntegradoAEDSO
{
    public class IO
    {

        public static FilaProcessos[] obterProcessos()
        {
            // Foi definido pelo enunciado do Trabalho que tem de ser criados 5 filas...
            FilaProcessos[] filas = new FilaProcessos[5];

            for(int i = 0; i < filas.Length; i++)
            {
                filas[i] = new FilaProcessos(i + 1);
                // i + 1 se refere a Prioridade que será inserida na fila, para recohecer prioridade da fila
            }

            // por aqui que a manipulação de arquivo começa
            StreamReader leitor = new StreamReader(@"dadosTIAED.txt", Encoding.UTF8);
            string[] linha;
            while (!leitor.EndOfStream)
            {

                linha = leitor.ReadLine().Split(';'); //a linha do arquivo é lida e já separa os argumentos

                //os argumentos são diretamente convertidos e utilizados para criar o objeto Processo
                Processo processo = new Processo(
                                                   int.Parse(linha[0]),
                                                   linha[1],
                                                   int.Parse(linha[2]),
                                                   float.Parse(linha[3]),
                                                   int.Parse(linha[4])
                                                 
                                                 );

                // o objeto é lançado para uma fila de acordo com sua prioridade,
                // [processo.Prioridade - 1] é usado para não dar conflito em um vetor de filas
                filas[processo.Prioridade - 1].Enfileirar(processo);


            }

            return filas;

        }

    }
}
