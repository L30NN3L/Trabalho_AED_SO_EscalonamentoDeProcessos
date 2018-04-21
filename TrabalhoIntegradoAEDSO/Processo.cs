using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIntegradoAEDSO
{
    public class Processo
    {

        private int id;
        private string nome;
        private int prioridade;
        private float tempo;
        private int ciclos;
        private string status; // <- seria usado para reconhecer o estado de cada processo

        private Processo proximo;

       

        //public int Prioridade { get => prioridade; set => prioridade = value; }
        //public float Tempo { get => tempo; set => tempo = value; }
        //public int Ciclos { get => ciclos; set => ciclos = value; }
        //public string Status { get => status; set => status = value; }

        //internal Processo Proximo { get => proximo; set => proximo = value; }


        public Processo(int id, string nome, int prioridade, float tempo, int ciclos)
        {
            this.id = id;
            this.nome = nome;
            this.Prioridade = prioridade;
            this.Tempo = tempo;
            this.Ciclos = ciclos;
        //    this.status = "PRONTO";
        }

        public Processo()
        {

        }

        public void ImprimeProcesso()
        {
            Console.WriteLine("Id: {0} \nNome: {1} \nPrioridade: {2} \nTempo: {3} \nCiclos: {4} \n", 
                this.id, this.nome, this.Prioridade, this.Tempo, this.Ciclos);
        }


        public int Prioridade
        {
            get
            {
                return prioridade;
            }

            set
            {
                prioridade = value;
            }
        }

        public float Tempo
        {
            get
            {
                return tempo;
            }

            set
            {
                tempo = value;
            }
        }

        public int Ciclos
        {
            get
            {
                return ciclos;
            }

            set
            {
                ciclos = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Processo Proximo
        {
            get
            {
                return proximo;
            }

            set
            {
                proximo = value;
            }
        }


    }
}
