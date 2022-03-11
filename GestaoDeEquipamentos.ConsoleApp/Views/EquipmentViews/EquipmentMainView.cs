using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews
{
    internal class EquipmentMainView
    {
        public static void Show()
        {
            try
            {
                ProgramUtils.ShowEquipmentMainViewMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RegisterEquipmentView.Show();
                        break;

                    case 2:
                        ListEquipmentsView.Show();
                        break;

                    case 3:
                        ListMoreProblematicEquipmentsView.Show();
                        break;

                    case 4:
                        EditEquipmentView.Show();
                        break;

                    case 5:
                        DeleteEquipmentView.Show();
                        break;

                    case 6:
                        MainView.Show();
                        break;

                    default:
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("Opção não encontrada.", "Pressione qualquer tecla para tentar novamente", () => Show());
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O valor fornecido é inválido.", "Pressione qualquer tecla para tentar novamente", () => Show());
            }
        }
    }
}