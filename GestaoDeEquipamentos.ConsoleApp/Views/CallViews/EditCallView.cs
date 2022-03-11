using System.Globalization;
using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Enums;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class EditCallView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                ProgramUtils.ShowRegisteredCallsList();
                Console.Write("Digite o ID do chamado: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Call? call = CallService.FindCallById(id);
                if (call == null)
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("Chamado não encontrado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                }
                else
                {
                    ProgramUtils.ShowEditCallViewMenu(call);
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            EditCallTitle(call);
                            break;

                        case 2:
                            EditCallDescription(call);
                            break;

                        case 3:
                            EditCallEquipmentId(call);
                            break;

                        case 4:
                            EditCallRequesterId(call);
                            break;

                        case 5:
                            EditCallOpeningDate(call);
                            break;

                        case 6:
                            EditCallStatus(call);
                            break;

                        case 7:
                            CallMainView.Show();
                            break;

                        default:
                            Console.WriteLine();
                            ProgramUtils.ShowCustomMessage("Opção não encontrada.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Erro: O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
        }

        #region Métodos
        private static void EditCallTitle(Call call)
        {
            Console.Clear();
            Console.Write($"Insira um novo título para o chamado '{call.Id}': ");
            string? newTitle = Console.ReadLine();
            if (string.IsNullOrEmpty(newTitle))
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo titulo escolhido não pode ser nulo ou vazio.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
            else
            {
                call.Title = newTitle;
                Console.WriteLine();
                Console.WriteLine($"Titulo alterado para '{newTitle}' com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
            }
        }

        private static void EditCallDescription(Call call)
        {
            Console.Clear();
            Console.Write($"Insira uma nova descrição para o chamado '{call.Id}': ");
            string? newDescription = Console.ReadLine();
            if (string.IsNullOrEmpty(newDescription))
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("A nova descrição escolhida não pode ser nula ou vazia.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
            else
            {
                call.Description = newDescription;
                Console.WriteLine();
                Console.WriteLine($"Descrição alterada com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
            }
        }

        private static void EditCallEquipmentId(Call call)
        {
            Console.Clear();
            Console.Write($"Insira um novo ID de equipamento para o chamado '{call.Id}': ");
            int newEquipmentId = Convert.ToInt32(Console.ReadLine());
            Equipment? equipment = EquipmentService.FindEquipmentById(newEquipmentId);
            if (equipment == null)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Equipamento não encontrado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
            else
            {
                call.Equipment = equipment;
                Console.WriteLine();
                Console.WriteLine($"ID do equipamento alterado para '{newEquipmentId}'");
                Console.WriteLine($"Equipamento: '({call.Equipment.Id}) - {call.Equipment.Name}'");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
            }
        }

        private static void EditCallRequesterId(Call call)
        {
            Console.Clear();
            Console.Write($"Insira um novo ID de solicitante para o chamado '{call.Id}': ");
            int newRequesterId = Convert.ToInt32(Console.ReadLine());
            Requester? requester = RequesterService.FindRequesterById(newRequesterId);
            if (requester == null)
            {
                ProgramUtils.ShowCustomMessage("Solicitante não encontrado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
            else
            {
                call.Requester = requester;
                Console.WriteLine();
                Console.WriteLine($"ID do equipamento alterado para '{newRequesterId}'");
                Console.WriteLine($"Equipamento: '({call.Requester.Id}) - {call.Requester.Name}'");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
            }
        }

        private static void EditCallOpeningDate(Call call)
        {
            Console.Clear();
            Console.WriteLine("Formato: dd/MM/yyyy HH:mm");
            Console.Write($"Insira uma nova data de abertura para o chamado '{call.Id}' ");
            DateTime newOpeningDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            if (newOpeningDate > DateTime.Now)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Não é possível inserir uma data no futuro.", "Pressione qualquer tecla para voltar.", () => CallMainView.Show());
            }
            else
            {
                call.OpeningDate = newOpeningDate;
                Console.WriteLine();
                Console.WriteLine($"Data de abertura alterada para {call.OpeningDate:dd/MM/yyyy HH:mm}");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
            }
        }

        private static void EditCallStatus(Call call)
        {
            Console.Clear();
            Console.WriteLine("Digite abaixo o novo status do chamado: ");
            Console.WriteLine();
            Console.WriteLine("1 -> Aberto");
            Console.WriteLine("2 -> Fechado");
            Console.WriteLine();
            ProgramUtils.ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
            int option = Convert.ToInt32(Console.ReadLine()); 
            switch (option)
            {
                case 1:
                    if (call.Status == EnumCallStatus.Aberto)
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("Este chamado já está aberto.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                    }
                    else
                    {
                        call.Status = EnumCallStatus.Aberto;
                        Console.WriteLine();
                        Console.WriteLine($"Chamado {call.Id} aberto com sucesso!");
                        ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
                    }
                    break;

                case 2:
                    if (call.Status == EnumCallStatus.Fechado)
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("Este chamado já está fechado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                    }
                    else
                    {
                        call.Status = EnumCallStatus.Fechado;
                        Console.WriteLine();
                        Console.WriteLine($"Chamado {call.Id} fechado com sucesso!");
                        ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
                    }
                    break;

                default:
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("Opção não encontrada.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                    break;
            }
        }
        #endregion
    }
}