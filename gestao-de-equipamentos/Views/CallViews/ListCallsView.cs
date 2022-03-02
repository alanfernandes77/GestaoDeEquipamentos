using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.CallViews
{
    internal class ListCallsView
    {
        public static void Show()
        {
            Console.Clear();
            if (CallService.GetCalls().Count == 0)
            {
                Console.WriteLine("Nenhum chamado registrado no momento.");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                CallMainView.Show();
            }
            else
            {
                Console.WriteLine($"Quantidade de chamados registrados: {CallService.GetCalls().Count}");
                Console.WriteLine();
                Console.WriteLine("Chamados:");
                Console.WriteLine();
                foreach (Call calls in CallService.GetCalls())
                {
                    Console.WriteLine(calls);
                }
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                CallMainView.Show();
            }
        }
    }
}