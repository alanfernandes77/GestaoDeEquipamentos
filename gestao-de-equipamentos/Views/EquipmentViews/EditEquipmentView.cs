using System.Globalization;

using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.EquipmentViews
{
    internal class EditEquipmentView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o ID do equipamento: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Equipment? equipment = EquipmentService.FindEquipmentById(id);
                if (equipment == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nenhum equipamento com este ID foi encontrado.");
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    EquipmentMainView.Show();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"O que deseja alterar do equipamento '({equipment.Id}) - {equipment.Name}'?");
                    Console.WriteLine();
                    Console.WriteLine("1 -> Nome");
                    Console.WriteLine("2 -> Preço");
                    Console.WriteLine("3 -> Número de Série");
                    Console.WriteLine("4 -> Data de Fabricação");
                    Console.WriteLine("5 -> Fabricante");
                    Console.WriteLine();
                    Console.WriteLine("6 -> Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write($"Insira um novo nome para o equipamento '({equipment.Id}) - {equipment.Name}': ");
                            string newName = Console.ReadLine();
                            equipment.Name = newName;
                            Console.WriteLine();
                            Console.WriteLine($"Nome alterado para '{newName}' com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write($"Insira um novo preço para o equipamento '({equipment.Id}) - {equipment.Name}': ");
                            double newPrice = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                            equipment.Price = newPrice;
                            Console.WriteLine();
                            Console.WriteLine($"Preço alterado para 'R$ {newPrice.ToString("F2", CultureInfo.InvariantCulture)}' com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write($"Insira um novo número de série para o equipamento '({equipment.Id}) - {equipment.Name}': ");
                            string newSerialNumber = Console.ReadLine().ToUpper();
                            equipment.SerialNumber = newSerialNumber;
                            Console.WriteLine();
                            Console.WriteLine($"Número de série alterado para '{newSerialNumber}' com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Formato: dd/MM/yyyy");
                            Console.Write($"Insira uma nova data de fabricação para o equipamento '({equipment.Id}) - {equipment.Name}': ");
                            DateTime newManufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            equipment.ManufactureDate = newManufactureDate;
                            Console.WriteLine();
                            Console.WriteLine($"Data de fabricação alterada para '{newManufactureDate:dd/MM/yyyy}' com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 5:
                            Console.Clear();
                            Console.Write($"Insira um novo fabricante para o equipamento '({equipment.Id}) - {equipment.Name}': ");
                            string newManufacturer = Console.ReadLine().ToUpper();
                            equipment.Manufacturer = newManufacturer;
                            Console.WriteLine();
                            Console.WriteLine($"Fabricante do equipamento alterado para '{newManufacturer}' com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 6:
                            EquipmentMainView.Show();
                            break;


                        default:
                            Console.WriteLine();
                            Console.WriteLine("Opção não encontrada.");
                            Console.WriteLine();
                            Console.Write("Pressione qualquer tecla para voltar.");
                            Console.ReadKey();
                            EquipmentMainView.Show();
                            break;
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

        private static void CheckChangeOtherProperty()
        {
            Console.WriteLine();
            Console.WriteLine("Deseja alterar alguma outra coisa?");
            Console.WriteLine();
            Console.WriteLine("1 -> Sim (Será necessário inserir o ID do equipamento novamente)");
            Console.WriteLine("2 -> Não");
            Console.WriteLine();
            Console.Write("Opção: ");
            int option2 = Convert.ToInt32(Console.ReadLine());
            switch (option2)
            {
                case 1:
                    Show();
                    break;
                case 2:
                    EquipmentMainView.Show();
                    break;
                default:
                    Console.ReadKey();
                    EquipmentMainView.Show();
                    break;
            }
        }
    }
}