using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class ListCallsView
    {
        public static void Show()
        {
            try
            {
                ProgramUtils.ShowListCallsViewMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ListOpenCallsView.Show();
                        break;

                    case 2:
                        ListClosedCallsView.Show();
                        break;

                    case 3:
                        CallMainView.Show();
                        break;

                    default:
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("Opção não encontrada.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                        break;
                }
            } catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
        }
    }
}