using System.Globalization;
using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews
{
    internal class EditEquipmentView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                ProgramUtils.ShowRegisteredEquipmentsList();
                Console.Write("Digite o ID do equipamento: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Equipment? equipment = EquipmentService.FindEquipmentById(id);
                if (equipment == null)
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("Nenhum equipamento com este ID foi encontrado.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                }
                else
                {
                    ProgramUtils.ShowEditEquipmentViewMenu(equipment);
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            EditEquipmentName(equipment);
                            break;

                        case 2:
                            EditEquipmentPrice(equipment);
                            break;

                        case 3:
                            EditEquipmentSerialNumber(equipment);
                            break;

                        case 4:
                            EditEquipmentManufactureDate(equipment);
                            break;

                        case 5:
                            EditEquipmentManufacturer(equipment);
                            break;

                        case 6:
                            EquipmentMainView.Show();
                            break;

                        default:
                            Console.WriteLine();
                            ProgramUtils.ShowCustomMessage("Opção não encontrada.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Erro: O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
        }

        #region Métodos

        private static void EditEquipmentName(Equipment equipment)
        {
            Console.Clear();
            Console.Write($"Insira um novo nome para o equipamento '({equipment.Id}) - {equipment.Name}': ");
            string? newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName) || newName.Length < 6)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo nome escolhido não pode ser nulo ou vazio e deve conter ao menos 6 caracteres.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
            else
            {
                equipment.Name = newName;
                Console.WriteLine();
                Console.WriteLine($"Nome alterado para '{newName}' com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
            }
        }

        private static void EditEquipmentPrice(Equipment equipment)
        {
            Console.Clear();
            Console.Write($"Insira um novo preço para o equipamento '({equipment.Id}) - {equipment.Name}': ");
            double newPrice = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            if (double.IsNegative(newPrice) || newPrice == 0.0)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo preço escolhido não pode ser negativo ou zero.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
            else
            {
                equipment.Price = newPrice;
                Console.WriteLine();
                Console.WriteLine($"Preço alterado para 'R$ {newPrice.ToString("F2", CultureInfo.InvariantCulture)}' com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
            }
        }

        private static void EditEquipmentSerialNumber(Equipment equipment)
        {
            Console.Clear();
            Console.Write($"Insira um novo número de série para o equipamento '({equipment.Id}) - {equipment.Name}': ");
            string? newSerialNumber = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(newSerialNumber))
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo número de série escolhido para o equipamento não pode ser nulo ou vazio", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
            else
            {
                equipment.SerialNumber = newSerialNumber;
                Console.WriteLine();
                Console.WriteLine($"Número de série alterado para '{newSerialNumber}' com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
            }
        }

        private static void EditEquipmentManufactureDate(Equipment equipment)
        {
            Console.Clear();
            Console.WriteLine("Formato: dd/MM/yyyy");
            Console.Write($"Insira uma nova data de fabricação para o equipamento '({equipment.Id}) - {equipment.Name}': ");
            DateTime newManufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (newManufactureDate > DateTime.Now)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("A nova data de fabricação não pode ser uma data futura.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            } 
            else
            {
                equipment.ManufactureDate = newManufactureDate;
                Console.WriteLine();
                Console.WriteLine($"Data de fabricação alterada para '{newManufactureDate:dd/MM/yyyy}' com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
            }
        }

        private static void EditEquipmentManufacturer(Equipment equipment)
        {
            Console.Clear();
            Console.Write($"Insira um novo fabricante para o equipamento '({equipment.Id}) - {equipment.Name}': ");
            string? newManufacturer = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(newManufacturer))
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo fabricante escolhido para o equipamento não pode ser nulo ou vazio", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
            else
            {
                equipment.Manufacturer = newManufacturer;
                Console.WriteLine();
                Console.WriteLine($"Fabricante do equipamento alterado para '{newManufacturer}' com sucesso!");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
            }
        }
        #endregion
    }
}