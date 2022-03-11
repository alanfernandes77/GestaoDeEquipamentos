using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews
{
    internal class ListMoreProblematicEquipmentsView
    {

        public static void Show()
        {
            Console.Clear();
            if (EquipmentService.GetEquipments().Count == 0)
            {
                ProgramUtils.ShowCustomMessage("Nenhum registro encontrado.", "Pressione qualquer tecla para voltar.", () => EquipmentMainView.Show());
            } 
            else
            {
                EquipmentService.GetEquipments().Sort();
                EquipmentService.GetEquipments().Reverse();

                int i = 1;
                Console.WriteLine("Equipamentos mais problemáticos:");
                Console.WriteLine("Legenda: (Posição) (Nome equipamento) - (Quantidade de vezes que deu problema.)");
                Console.WriteLine();
                foreach (Equipment equipment in EquipmentService.GetEquipments())
                {
                    if (equipment.TimesInMaintenance > 1)
                    {
                        Console.WriteLine($"{i}° {equipment.Name} - {equipment.TimesInMaintenance}");
                        i++;
                    } 
                }
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                EquipmentMainView.Show();
            }
        }
    }
}