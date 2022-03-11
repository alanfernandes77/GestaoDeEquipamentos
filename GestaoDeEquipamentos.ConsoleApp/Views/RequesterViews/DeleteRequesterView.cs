using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.RequesterViews
{
    internal class DeleteRequesterView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
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
                    Console.WriteLine();
                    Console.WriteLine($"Solicitante '({requester.Id}) - {requester.Name}' deletado com sucesso!");
                    RequesterService.DeleteRequester(requester);
                    ProgramUtils.PerformActionAgain("Deseja deletar outro?", () => Show(), () => RequesterMainView.Show(), () => RequesterMainView.Show());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Erro: O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
            }
        }
    }
}