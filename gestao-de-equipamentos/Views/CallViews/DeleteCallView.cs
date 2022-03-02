using gestao_de_equipamentos.Entities;
using gestao_de_equipamentos.Services;

namespace gestao_de_equipamentos.Views.CallViews
{
    internal class DeleteCallView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o ID do chamado: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Call? call = CallService.FindCallById(id);
                if (call == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nenhum chamado com este ID foi encontrado.");
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    CallMainView.Show();
                }
                else
                {
                    Equipment? equipment = EquipmentService.FindEquipmentById(call.EquipmentId);
                    Console.WriteLine();
                    Console.WriteLine($"Chamado '({call.Id})' referente ao equipamento '({equipment.Id}) - {equipment.Name}' deletado com sucesso!");
                    CallService.DeleteCall(call);
                    Console.WriteLine();
                    Console.WriteLine("Deseja deletar outro?");
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