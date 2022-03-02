using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.CallViews
{
    internal class RegisterCallView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o titulo do chamado: ");
                string title = Console.ReadLine();
                Console.Write("Digite a descrição do chamado: ");
                string description = Console.ReadLine();
                Console.Write("Digite o ID do equipamento: ");
                int equipmentId = Convert.ToInt32(Console.ReadLine());
                Equipment? equipment = EquipmentService.FindEquipmentById(equipmentId);
                if (equipment == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Equipamento não encontrado.");
                    Console.WriteLine();
                    Console.WriteLine("Só é possível registrar um chamado para equipamentos cadastrados.");
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    CallMainView.Show();
                }
                else
                {
                    Random random = new();
                    int callId = random.Next(10, 1000);
                    Call call = new(callId, title, description, equipmentId);
                    CallService.RegisterCall(call);
                    Console.WriteLine();
                    Console.WriteLine($"Chamado '({callId})' referente ao equipamento: '({equipment.Id}) - {equipment.Name}' registrado com sucesso!");
                    Console.WriteLine();
                    Console.WriteLine("Deseja registrar outro?");
                    Console.WriteLine();
                    Console.WriteLine("1 -> Sim");
                    Console.WriteLine("2 -> Não");
                    Console.WriteLine();
                    Console.Write("Opção: ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Show();
                            break;

                        case 2:
                            CallMainView.Show();
                            break;

                        default:
                            CallMainView.Show();
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Erro: O valor fornecido é inválido.");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                CallMainView.Show();
            }
        }
    }
}