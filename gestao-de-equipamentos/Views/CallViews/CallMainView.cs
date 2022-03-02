namespace gestao_de_equipamentos.Views.CallViews
{
    internal class CallMainView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("<> Controle de Chamados <>");
                Console.WriteLine();
                Console.WriteLine("Olá Júnior!");
                Console.WriteLine();
                Console.WriteLine("O que deseja fazer hoje?!");
                Console.WriteLine();
                Console.WriteLine("1 -> Registrar um chamado");
                Console.WriteLine("2 -> Consultar chamados registrados");
                Console.WriteLine("3 -> Editar informações de um chamado");
                Console.WriteLine("4 -> Deletar um chamado");
                Console.WriteLine();
                Console.WriteLine("5 -> Voltar ao menú principal");
                Console.WriteLine();
                Console.Write("Opção: ");
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
                Console.Write("Pressione qualquer tecla para voltar ao menú principal.");
                Console.ReadKey();
                Show();
            }
        }
    }
}