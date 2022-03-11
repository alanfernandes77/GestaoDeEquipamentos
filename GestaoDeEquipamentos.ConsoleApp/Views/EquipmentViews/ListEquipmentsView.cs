using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews
{
    internal class ListEquipmentsView
    {
        public static void Show()
        {
            Console.Clear();
            if (EquipmentService.GetEquipments().Count == 0)
            {
                ProgramUtils.ShowCustomMessage("Nenhum equipamento cadastrado no momento.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
            else
            {
                Console.WriteLine($"Quantidade de equipamentos cadastrados: {EquipmentService.GetEquipments().Count}");
                Console.WriteLine();
                Console.WriteLine("Equipamentos:");
                Console.WriteLine();
                foreach (Equipment equipments in EquipmentService.GetEquipments())
                {
                    Console.WriteLine(equipments);
                }
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                EquipmentMainView.Show();
            }
        }
    }
}