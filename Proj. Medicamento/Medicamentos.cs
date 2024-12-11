using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj._Medicamento
{
    public class Medicamentos
    {
        // Propriedade
        public List<Medicamento> ListaMedicamentos { get; set; }

        // Construtor
        public Medicamentos()
        {
            ListaMedicamentos = new List<Medicamento>();
        }

        // Adiciona um medicamento à lista
        public void Adicionar(Medicamento medicamento)
        {
            ListaMedicamentos.Add(medicamento);
        }

        // Remove um medicamento da lista se a quantidade disponível for zero
        public bool Deletar(Medicamento medicamento)
        {
            var encontrado = ListaMedicamentos.FirstOrDefault(m => m.Equals(medicamento));
            if (encontrado != null && encontrado.QtdeDisponivel() == 0)
            {
                ListaMedicamentos.Remove(encontrado);
                return true;
            }
            return false;
        }

        // Pesquisa um medicamento na lista usando o ID como chave
        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return ListaMedicamentos.FirstOrDefault(m => m.Equals(medicamento)) ?? new Medicamento();
        }
    }
}