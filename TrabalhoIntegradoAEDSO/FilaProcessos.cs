using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIntegradoAEDSO
{
    public class FilaProcessos
    {
        private int count; // variável útil para saber quantidade de processos existentes em uma fila

        private int prioridade; // variável útil pra reconhcer prioridade determinada fila

        private Processo primeiro, ultimo;

        public int Count { get => count; set => count = value; }

        public FilaProcessos(int prioridade)
        {
            this.Count = 0;
            this.prioridade = prioridade;

            this.primeiro = new Processo();
            this.ultimo = this.primeiro;

        }

        public Processo Enfileirar(Processo novo)
        {
            Count++;
            this.ultimo.Proximo = novo;
            this.ultimo = novo;
            return this.ultimo;
        }

        public Processo Desenfileirar()
        {
            if (!FilaVazia())
            {
                Processo aux = this.primeiro.Proximo;
                this.primeiro.Proximo = aux.Proximo;
                aux.Proximo = null;
                Count--;
                return aux;
            }
            else
            {
                return null;
            }
            
        }

        public bool FilaVazia()
        {
            if(this.primeiro.Proximo == null)
            {
                return true;
            }

            return false;
        }

        public void ImprimeFila()
        {

            Processo aux = this.primeiro.Proximo;
            if(aux != null)
            {
                aux.ImprimeProcesso();
                aux = aux.Proximo;
            }
        }

    }
}
