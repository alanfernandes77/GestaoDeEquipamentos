using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.RequesterViews
{
    internal class RequesterMainView
    {
        public static void Show()
        {
            try
            {
                ProgramUtils.ShowRequesterMainViewMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RegisterRequesterView.Show();
                        break;

                    case 2:
                        ListRequestersView.Show();
                        break;

                    case 3:
                        EditRequesterView.Show();
                        break;

                    case 4:
                        DeleteRequesterView.Show();
                        break;

                    case 5:
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
                ProgramUtils.ShowCustomMessage("O valor inserido é inválido.", "Pressione qualquer tecla para tentar novamente", () => Show());
            }
        }
    }
}