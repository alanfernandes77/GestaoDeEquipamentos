using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Enums;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class ListOpenCallsView
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine($"Chamados abertos:");
            Console.WriteLine();
            foreach (Call call in CallService.GetCalls())
            {
                if (call.Status == EnumCallStatus.Aberto)
                {
                    Console.WriteLine(call);
                }
            }
            Console.Write("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
            CallMainView.Show();
        }
    }
}