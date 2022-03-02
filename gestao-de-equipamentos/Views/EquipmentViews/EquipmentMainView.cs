namespace gestao_de_equipamentos.Views.EquipmentViews
{
    internal class EquipmentMainView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("<> Controle de Equipamentos <>");
                Console.WriteLine();
                Console.WriteLine("Olá Júnior!");
                Console.WriteLine();
                Console.WriteLine("O que deseja fazer hoje?!");
                Console.WriteLine();
                Console.WriteLine("1 -> Cadastrar equipamento");
                Console.WriteLine("2 -> Consultar equipamentos cadastrados");
                Console.WriteLine("3 -> Editar informações de um equipamento");
                Console.WriteLine("4 -> Deletar um equipamento");
                Console.WriteLine();
                Console.WriteLine("5 -> Voltar ao menú principal");
                Console.WriteLine();
                Console.Write("Opção: ");
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
                        EditEquipmentView.Show();
                        break;

                    case 4:
                        DeleteEquipmentView.Show();
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
                Console.Write("Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Show();
            }
        }
    }
}