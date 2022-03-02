using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.EquipmentViews
{
    internal class ListEquipmentsView
    {
        public static void Show()
        {
            Console.Clear();
            if (EquipmentService.GetEquipments().Count == 0)
            {
                Console.WriteLine("Nenhum equipamento cadastrado no momento.");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                EquipmentMainView.Show();
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
