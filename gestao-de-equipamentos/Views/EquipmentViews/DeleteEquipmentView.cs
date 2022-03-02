using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.EquipmentViews
{
    internal class DeleteEquipmentView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o ID do equipamento: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Equipment? equipment = EquipmentService.FindEquipmentById(id);
                if (equipment == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nenhum equipamento com este ID foi encontrado.");
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    EquipmentMainView.Show();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Equipamento '({equipment.Id}) - {equipment.Name}' deletado com sucesso!");
                    EquipmentService.DeleteEquipment(equipment);
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
                            EquipmentMainView.Show();
                            break;

                        default:
                            EquipmentMainView.Show();
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
                EquipmentMainView.Show();
            }
        }
    }
}