using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj._Medicamento
{
    public class Medicamento
    {
        // Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public Queue<Lote> Lotes { get; set; }

        // Construtores
        public Medicamento()
        {
            Lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            Lotes = new Queue<Lote>();
        }

        // Retorna a quantidade total disponível
        public int QtdeDisponivel()
        {
            return Lotes.Sum(lote => lote.Quantidade);
        }

        // Adiciona um lote à fila de lotes
        public void Comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }

        // Realiza a venda de uma quantidade específica
        public bool Vender(int qtde)
        {
            if (QtdeDisponivel() < qtde)
                return false;

            while (qtde > 0 && Lotes.Count > 0)
            {
                var loteAtual = Lotes.Peek();
                if (loteAtual.Quantidade > qtde)
                {
                    loteAtual.Quantidade -= qtde;
                    qtde = 0;
                }
                else
                {
                    qtde -= loteAtual.Quantidade;
                    Lotes.Dequeue();
                }
            }
            return true;
        }

        // Retorna os dados do medicamento como string
        public override string ToString()
        {
            return $"{Id}-{Nome}-{Laboratorio}-{QtdeDisponivel()}";
        }

        // Permite comparação pelo ID
        public override bool Equals(object obj)
        {
            if (obj is Medicamento medicamento)
                return Id == medicamento.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}