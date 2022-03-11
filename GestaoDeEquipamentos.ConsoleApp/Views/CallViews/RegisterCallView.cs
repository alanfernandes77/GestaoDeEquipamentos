using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class RegisterCallView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                ProgramUtils.ShowRegisteredEquipmentsList();
                Console.WriteLine();
                ProgramUtils.ShowRegisteredRequestersList();
                Console.Write("Digite o titulo do chamado: ");
                string? title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("O titulo não pode ser nulo ou vazio", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                } 
                else
                {
                    Console.Write("Digite a descrição do chamado: ");
                    string? description = Console.ReadLine();
                    if (string.IsNullOrEmpty(description))
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("A descrição não pode ser nula ou vazia.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                    } 
                    else
                    {
                        Console.Write("Digite o ID do equipamento: ");
                        int equipmentId = Convert.ToInt32(Console.ReadLine());
                        Equipment? equipment = EquipmentService.FindEquipmentById(equipmentId);
                        if (equipment == null)
                        {
                            Console.WriteLine();
                            ProgramUtils.ShowCustomMessage("Equipamento não encontrado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                        }
                        else
                        {
                            Console.Write("Digite o ID do solicitante: ");
                            int requesterId = Convert.ToInt32(Console.ReadLine());
                            Requester? requester = RequesterService.FindRequesterById(requesterId);
                            if (requester == null)
                            {
                                Console.WriteLine();
                                ProgramUtils.ShowCustomMessage("Solicitante não encontrado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                            }
                            else
                            {
                                Call call = new(title, description, equipment, requester);
                                equipment.TimesInMaintenance += 1;
                                CallService.RegisterCall(call);
                                Console.WriteLine();
                                Console.WriteLine($"Chamado '({call.Id})' referente ao equipamento: '({equipment.Id}) - {equipment.Name}' registrado com sucesso!");
                                Console.WriteLine($"Solicitante: ({requester.Id}) - {requester.Name}");
                                Console.WriteLine();
                                ProgramUtils.PerformActionAgain("Deseja registrar outro?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Erro: O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
        }
    }
}