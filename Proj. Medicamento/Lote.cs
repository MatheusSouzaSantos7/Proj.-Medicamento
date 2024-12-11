using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj._Medicamento
{
    public class Lote
    {
        // Propriedades
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime Vencimento { get; set; }

        // Construtores
        public Lote() { }

        public Lote(int id, int quantidade, DateTime vencimento)
        {
            Id = id;
            Quantidade = quantidade;
            Vencimento = vencimento;
        }

        // Método para retornar uma string representando o lote
        public override string ToString()
        {
            return $"{Id}-{Quantidade}-{Vencimento:dd/MM/yyyy}";
        }
    }
}