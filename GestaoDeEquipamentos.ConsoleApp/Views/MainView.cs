using GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews;
using GestaoDeEquipamentos.ConsoleApp.Views.CallViews;
using GestaoDeEquipamentos.ConsoleApp.Views.RequesterViews;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views
{
    internal class MainView
    {
        public static void Show()
        {
            try
            {
                ProgramUtils.ShowMainViewMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EquipmentMainView.Show();
                        break;

                    case 2:
                        CallMainView.Show();
                        break;

                    case 3:
                        RequesterMainView.Show();
                        break;

                    case 0:
                        Environment.Exit(0);
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