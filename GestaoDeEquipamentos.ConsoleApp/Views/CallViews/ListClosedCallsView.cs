using GestaoDeEquipamentos.ConsoleApp.Services;
using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Enums;

namespace GestaoDeEquipamentos.ConsoleApp.Views.CallViews
{
    internal class ListClosedCallsView
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine($"Chamados fechados:");
            Console.WriteLine();
            foreach (Call call in CallService.GetCalls())
            {
                if (call.Status == EnumCallStatus.Fechado)
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