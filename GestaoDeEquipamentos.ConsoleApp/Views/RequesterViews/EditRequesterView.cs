using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.RequesterViews
{
    internal class EditRequesterView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                if (RequesterService.GetRequesters().Count == 0)
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("Nenhum registro de solicitante encontrado para editar.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
                    return;
                }
                else
                {
                    ProgramUtils.ShowRegisteredRequestersList();
                    Console.Write("Digite o ID do solicitante: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Requester? requester = RequesterService.FindRequesterById(id);
                    if (requester == null)
                    {
                        Console.WriteLine();
                        ProgramUtils.ShowCustomMessage("Nenhum solicitante com este ID foi encontrado.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
                    }
                    else
                    {
                        ProgramUtils.ShowEditRequesterViewMenu(requester);
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                EditRequesterName(requester);
                                break;

                            case 2:
                                EditRequesterEmail(requester);
                                break;

                            case 3:
                                EditRequesterPhoneNumber(requester);
                                break;

                            case 4:
                                RequesterMainView.Show();
                                break;

                            default:
                                Console.WriteLine();
                                ProgramUtils.ShowCustomMessage("Opção não encontrada.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
                                break;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O valor fornecido é inválido.", "Pressione qualquer tecla para tentar novamente", () => RequesterMainView.Show());
            }
        }

        #region Métodos
        private static void EditRequesterName(Requester? requester)
        {
            Console.Clear();
            Console.Write("Insira um novo nome para o solicitante: ");
            string? newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName) || newName.Length < 6)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo nome não pode ser nulo ou vazio e deve conter ao menos 6 caracteres.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
            } 
            else
            {
                requester.Name = newName;
                Console.WriteLine();
                Console.WriteLine($"Nome do solicitante atualizado com sucesso para {newName}");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => RequesterMainView.Show(), () => RequesterMainView.Show());
            }
        }

        private static void EditRequesterEmail(Requester? requester)
        {
            Console.Clear();
            Console.Write("Insira um novo e-mail para o solicitante: ");
            string? newEmail = Console.ReadLine();
            if (string.IsNullOrEmpty(newEmail))
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo e-mail não pode ser nulo ou vazio.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
            }
            else
            {
                requester.Email = newEmail;
                Console.WriteLine();
                Console.WriteLine($"E-mail do solicitante atualizado com sucesso para {newEmail}");
                ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => RequesterMainView.Show(), () => RequesterMainView.Show());
            }
        }

        private static void EditRequesterPhoneNumber(Requester? requester)
        {
            Console.Clear();
            Console.Write("Insira um novo número de telefone para o solicitante: ");
            string newPhoneNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(newPhoneNumber) || newPhoneNumber.Length < 11)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("O novo número de telefone não pode ser nulo ou vazio e deve conter 11 caracteres.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
            }
            requester.PhoneNumber = newPhoneNumber;
            Console.WriteLine();
            Console.WriteLine($"Número de telefone do solicitante atualizado com sucesso para {newPhoneNumber}");
            ProgramUtils.PerformActionAgain("Deseja alterar outra coisa?", () => Show(), () => RequesterMainView.Show(), () => RequesterMainView.Show());
        }
        #endregion
    }
}