using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class DeleteCallView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                ProgramUtils.ShowRegisteredCallsList();
                Console.Write("Digite o ID do chamado: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Call? call = CallService.FindCallById(id);
                if (call == null)
                {
                    Console.WriteLine();
                    ProgramUtils.ShowCustomMessage("Nenhum chamado com este ID foi encontrado.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
                }
                else
                {
                    Equipment? equipment = EquipmentService.FindEquipmentById(call.Equipment.Id);
                    Console.WriteLine();
                    Console.WriteLine($"Chamado '({call.Id})' referente ao equipamento '({equipment.Id}) - {equipment.Name}' deletado com sucesso!");
                    CallService.DeleteCall(call);
                    ProgramUtils.PerformActionAgain("Deseja deletar outro?", () => Show(), () => CallMainView.Show(), () => CallMainView.Show());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                ProgramUtils.ShowCustomMessage("Erro: O valor fornecido é inválido.", "Pressione qualquer tecla para voltar", () => CallMainView.Show());
            }
        }
    }
}