using gestao_de_equipamentos.Views.EquipmentViews;
using gestao_de_equipamentos.Views.CallViews;

namespace gestao_de_equipamentos.Views
{
    internal class MainView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("<> Gestão de Equipamentos <>");
                Console.WriteLine();
                Console.WriteLine("Módulos:");
                Console.WriteLine();
                Console.WriteLine("1 -> Controle de Equipamentos");
                Console.WriteLine("2 -> Controle de Chamados");
                Console.WriteLine();
                Console.WriteLine("0 -> Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EquipmentMainView.Show();
                        break;

                    case 2:
                        CallMainView.Show();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Opção não encontrada.");
                        Console.WriteLine();
                        Console.Write("Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        Show();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Erro: O valor fornecido é inválido.");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Show();
            }
        }
    }
}