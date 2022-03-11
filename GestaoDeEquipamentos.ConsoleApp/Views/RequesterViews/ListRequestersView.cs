using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Utils;

namespace GestaoDeEquipamentos.ConsoleApp.Views.RequesterViews
{
    internal class ListRequestersView
    {
        public static void Show()
        {
            Console.Clear();
            if (RequesterService.GetRequesters().Count == 0)
            {
                ProgramUtils.ShowCustomMessage("Nenhum solicitante registrado no momento.", "Pressione qualquer tecla para voltar", () => RequesterMainView.Show());
            }
            else
            {
                Console.WriteLine($"Quantidade de solicitantes registrados: {RequesterService.GetRequesters().Count}");
                Console.WriteLine();
                Console.WriteLine("Solicitantes:");
                Console.WriteLine();
                foreach (Requester requesters in RequesterService.GetRequesters())
                {
                    Console.WriteLine(requesters);
                }
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                RequesterMainView.Show();
            }
        }
    }
}