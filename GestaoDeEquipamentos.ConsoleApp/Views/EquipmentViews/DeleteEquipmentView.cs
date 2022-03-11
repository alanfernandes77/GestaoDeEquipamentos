using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews
{
    internal class DeleteEquipmentView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                ProgramUtils.ShowRegisteredEquipmentsList();
                Console.Write("Digite o ID do equipamento: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Equipment? equipment = EquipmentService.FindEquipmentById(id);
                if (equipment == null)
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("Nenhum equipamento com este ID foi encontrado.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                }
                else
                {
                    if (equipment.IsInMaintenanceCall)
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("Este equipamento possui um chamado ativo, sendo assim não é possível deleta-lo", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Equipamento '({equipment.Id}) - {equipment.Name}' deletado com sucesso!");
                        EquipmentService.DeleteEquipment(equipment);
                        ProgramUtils.PerformActionAgain("Deseja deletar outro?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Erro: O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
        }
    }
}