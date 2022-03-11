using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class CallMainView
    {
        public static void Show()
        {
            try
            {
                ProgramUtils.ShowCallMainViewMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RegisterCallView.Show();
                        break;

                    case 2:
                        ListCallsView.Show();
                        break;

                    case 3:
                        EditCallView.Show();
                        break;

                    case 4:
                        DeleteCallView.Show();
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
                ProgramUtils.ShowCustomMessage("O valor fornecido é inválido.", "Pressione qualquer tecla para tentar novamente", () => Show());
            }
        }
    }
}