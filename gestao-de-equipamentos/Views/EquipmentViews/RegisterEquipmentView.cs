using System.Globalization;

using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.EquipmentViews
{
    internal class RegisterEquipmentView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite um ID para o equipamento: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Equipment? equipment = EquipmentService.FindEquipmentById(id);
                if (equipment != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Um equipamento com esse ID já está cadastrado.");
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para voltar ao menú principal.");
                    Console.ReadKey();
                    EquipmentMainView.Show();
                }
                else
                {
                    Console.Write("Digite o nome do equipamento: ");
                    string name = Console.ReadLine();
                    if (name.Length < 6)
                    {
                        Console.WriteLine();
                        Console.WriteLine("O nome do equipamento deve conter ao menos 6 caracteres.");
                        Console.WriteLine();
                        Console.Write("Pressione qualquer tecla para voltar.");
                        Console.ReadKey();
                        EquipmentMainView.Show();
                    }
                    else
                    {
                        Console.Write("Digite o preço do equipamento: ");
                        double price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Digite o número de série do equipamento: ");
                        string serialNumber = Console.ReadLine().ToUpper();
                        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy): ");
                        DateTime manufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Console.Write("Digite o fabricante do equipamento: ");
                        string manufacturer = Console.ReadLine().ToUpper();

                        equipment = new(id, name, price, serialNumber, manufactureDate, manufacturer);
                        EquipmentService.RegisterEquipment(equipment);
                        Console.WriteLine();
                        Console.WriteLine($"Equipamento '({equipment.Id}) - {equipment.Name}', cadastrado com sucesso!");
                        Console.WriteLine();
                        Console.WriteLine("Deseja cadastrar outro?");
                        Console.WriteLine();
                        Console.WriteLine("1 -> Sim");
                        Console.WriteLine("2 -> Não");
                        Console.WriteLine();
                        Console.Write("Opção: ");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Show();
                                break;

                            case 2:
                                EquipmentMainView.Show();
                                break;

                            default:
                                EquipmentMainView.Show();
                                break;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Erro: O valor fornecido é inválido.");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                EquipmentMainView.Show();
            }
        }
    }
}
