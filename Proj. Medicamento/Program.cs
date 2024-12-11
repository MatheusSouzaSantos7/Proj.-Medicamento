using System;
using System.Collections.Generic;
using Proj._Medicamento;

namespace Proj._Medicamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            int opcao;

            do
            {
                // Exibe o menu de opções
                Console.WriteLine("\nMENU DE OPÇÕES");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos (sintético)");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Processo finalizado.");
                        break;

                    case 1:
                        CadastrarMedicamento(medicamentos);
                        break;

                    case 2:
                        ConsultarMedicamentoSintetico(medicamentos);
                        break;

                    case 3:
                        ConsultarMedicamentoAnalitico(medicamentos);
                        break;

                    case 4:
                        ComprarMedicamento(medicamentos);
                        break;

                    case 5:
                        VenderMedicamento(medicamentos);
                        break;

                    case 6:
                        ListarMedicamentos(medicamentos);
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != 0);
        }

        // Funções auxiliares
        static void CadastrarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome do Medicamento: ");
            string nome = Console.ReadLine();
            Console.Write("Laboratório: ");
            string laboratorio = Console.ReadLine();

            Medicamento medicamento = new Medicamento(id, nome, laboratorio);
            medicamentos.Adicionar(medicamento);

            Console.WriteLine("Medicamento cadastrado com sucesso.");
        }

        static void ConsultarMedicamentoSintetico(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });

            if (medicamento.Id != 0)
            {
                Console.WriteLine(medicamento.ToString());
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ConsultarMedicamentoAnalitico(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });

            if (medicamento.Id != 0)
            {
                Console.WriteLine(medicamento.ToString());
                Console.WriteLine("Lotes:");
                foreach (var lote in medicamento.Lotes)
                {
                    Console.WriteLine(lote.ToString());
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ComprarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });

            if (medicamento.Id != 0)
            {
                Console.Write("ID do Lote: ");
                int idLote = int.Parse(Console.ReadLine());
                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());
                Console.Write("Data de Vencimento (dd/mm/yyyy): ");
                DateTime vencimento = DateTime.Parse(Console.ReadLine());

                Lote lote = new Lote(idLote, quantidade, vencimento);
                medicamento.Comprar(lote);

                Console.WriteLine("Lote cadastrado com sucesso.");
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void VenderMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Informe o ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });

            if (medicamento.Id != 0)
            {
                Console.Write("Quantidade para vender: ");
                int quantidade = int.Parse(Console.ReadLine());

                if (medicamento.Vender(quantidade))
                {
                    Console.WriteLine("Venda realizada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ListarMedicamentos(Medicamentos medicamentos)
        {
            Console.WriteLine("Medicamentos Cadastrados:");
            foreach (var medicamento in medicamentos.ListaMedicamentos)
            {
                Console.WriteLine(medicamento.ToString());
            }
        }
    }
}