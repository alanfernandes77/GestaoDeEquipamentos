using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.RequesterViews
{
    internal class RegisterRequesterView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o nome do solicitante: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || name.Length < 6)
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("O nome não pode ser nulo ou vazio e deve conter ao menos 6 caracteres.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
                }
                else
                {
                    Console.Write("Digite o e-mail do solicitante: ");
                    string? email = Console.ReadLine();
                    if (string.IsNullOrEmpty(email))
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("O e-mail não pode ser nulo ou vazio.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
                    }
                    else
                    {
                        Console.Write("Digite o número de telefone do solicitante: ");
                        string? phoneNumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 11)
                        {
                            Console.WriteLine();
                            ProgramUtils.ShowCustomMessage("O número de telefone não pode ser nulo ou vazio e deve conter 11 caracteres.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
                        }
                        else
                        {
                            Requester requester = new(name, email, phoneNumber);
                            RequesterService.RegisterRequester(requester);
                            ProgramUtils.PerformActionAgain("Deseja registrar outro?", () => Show(), () => RequesterMainView.Show(), () => RequesterMainView.Show());
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
            }
        }
    }
}