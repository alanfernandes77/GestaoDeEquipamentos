using System.Globalization;

using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.EquipmentViews
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
                    ProgramUtils.ShowCustomMessage("Um equipamento com esse ID já está cadastrado.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                }
                else
                {
                    Console.Write("Digite o nome do equipamento: ");
                    string? name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || name.Length < 6)
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("O nome do equipamento deve conter ao menos 6 caracteres.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                    }
                    else
                    {
                        Console.Write("Digite o preço do equipamento: ");
                        double price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        if (double.IsNegative(price) || price == 0.0)
                        {
                            Console.WriteLine();
                            ProgramUtils.ShowCustomMessage("O preço do equipamento não pode ser negativo ou zero.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                        }
                        else
                        {
                            Console.Write("Digite o número de série do equipamento: ");
                            string? serialNumber = Console.ReadLine().ToUpper();
                            if (string.IsNullOrEmpty(serialNumber))
                            {
                                Console.WriteLine();
                                ProgramUtils.ShowCustomMessage("O número de série do equipamento não pode ser nulo ou vazio.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                            }
                            else
                            {
                                Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy): ");
                                DateTime manufactureDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                if (manufactureDate > DateTime.Now)
                                {
                                    Console.WriteLine();
                                    ProgramUtils.ShowCustomMessage("A data de fabricação não pode ser uma data futura.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                                }
                                else
                                {
                                    Console.Write("Digite o fabricante do equipamento: ");
                                    string? manufacturer = Console.ReadLine().ToUpper();
                                    if (string.IsNullOrEmpty(manufacturer))
                                    {
                                        Console.WriteLine();
                                        ProgramUtils.ShowCustomMessage("O fabricante do equipamento não pode ser nulo ou vazio.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
                                    }
                                    else
                                    {
                                        equipment = new(id, name, price, serialNumber, manufactureDate, manufacturer);
                                        EquipmentService.RegisterEquipment(equipment);
                                        Console.WriteLine();
                                        Console.WriteLine($"Equipamento cadastrado com sucesso!");
                                        ProgramUtils.PerformActionAgain("Deseja cadastrar outro?", () => Show(), () => EquipmentMainView.Show(), () => EquipmentMainView.Show());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => EquipmentMainView.Show());
            }
        }
    }
}