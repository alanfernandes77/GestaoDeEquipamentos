using GestaoDeEquipamentos.ConsoleApp.Entities;
using GestaoDeEquipamentos.ConsoleApp.Services;

namespace GestaoDeEquipamentos.ConsoleApp.Utils
{
    internal class ProgramUtils
    {

        public static void ShowMessage(string message, ConsoleColor color, bool writeLine)
        {
            if (writeLine)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = color;
                Console.Write(message);
                Console.ResetColor();
            }
        }

        public static void ShowCustomMessage(string message, string str, Action action)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.Write(str);
            Console.ReadKey();
            Console.ResetColor();
            action();
        }

        public static void ShowMainViewMenu()
        {
            Console.Clear();
            ShowMessage("Gestão de Equipamentos", ConsoleColor.DarkYellow, true);
            Console.WriteLine();
            Console.WriteLine("Módulos:");
            Console.WriteLine();
            Console.WriteLine("1 -> Controle de Equipamentos");
            Console.WriteLine("2 -> Controle de Chamados");
            Console.WriteLine("3 -> Controle de Solicitantes");
            Console.WriteLine();
            Console.WriteLine("0 -> Sair");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);

        }

        public static void ShowEquipmentMainViewMenu()
        {
            Console.Clear();
            ShowMessage("Controle de Equipamentos", ConsoleColor.DarkYellow, true);
            Console.WriteLine();
            Console.WriteLine("Olá Júnior!");
            Console.WriteLine();
            Console.WriteLine("O que deseja fazer hoje?!");
            Console.WriteLine();
            Console.WriteLine("1 -> Cadastrar equipamento");
            Console.WriteLine("2 -> Consultar equipamentos cadastrados");
            Console.WriteLine("3 -> Consultar equipamentos mais problemáticos");
            Console.WriteLine("4 -> Editar informações de um equipamento");
            Console.WriteLine("5 -> Deletar um equipamento");
            Console.WriteLine();
            Console.WriteLine("6 -> Voltar ao menú principal");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowCallMainViewMenu()
        {
            Console.Clear();
            ShowMessage("Controle de Chamados", ConsoleColor.DarkYellow, true);
            Console.WriteLine();
            Console.WriteLine("Olá Júnior!");
            Console.WriteLine();
            Console.WriteLine("O que deseja fazer hoje?!");
            Console.WriteLine();
            Console.WriteLine("1 -> Registrar um chamado");
            Console.WriteLine("2 -> Consultar chamados registrados");
            Console.WriteLine("3 -> Editar informações de um chamado");
            Console.WriteLine("4 -> Deletar um chamado");
            Console.WriteLine();
            Console.WriteLine("5 -> Voltar ao menú principal");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowRequesterMainViewMenu()
        {
            Console.Clear();
            ShowMessage("Controle de Solicitantes", ConsoleColor.DarkYellow, true);
            Console.WriteLine();
            Console.WriteLine("Olá Júnior!");
            Console.WriteLine();
            Console.WriteLine("O que deseja fazer hoje?!");
            Console.WriteLine();
            Console.WriteLine("1 -> Registrar um solicitante");
            Console.WriteLine("2 -> Consultar solicitantes registrados");
            Console.WriteLine("3 -> Editar informações de um solicitante");
            Console.WriteLine("4 -> Deletar um solicitante");
            Console.WriteLine();
            Console.WriteLine("5 -> Voltar ao menú principal");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowListCallsViewMenu()
        {
            Console.Clear();
            Console.WriteLine("Qual lista deseja visualizar?");
            Console.WriteLine();
            Console.WriteLine("1 -> Lista de chamados abertos");
            Console.WriteLine("2 -> Lista de chamados fechados");
            Console.WriteLine();
            Console.WriteLine("3 -> Voltar");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowEditCallViewMenu(Call call)
        {
            Console.WriteLine();
            Console.WriteLine($"O que deseja alterar do chamado '({call.Id})'?");
            Console.WriteLine();
            Console.WriteLine("1 -> Título");
            Console.WriteLine("2 -> Descrição");
            Console.WriteLine("3 -> Equipamento");
            Console.WriteLine("4 -> Solicitante");
            Console.WriteLine("5 -> Data de abertura");
            Console.WriteLine("6 -> Status do chamado");
            Console.WriteLine();
            Console.WriteLine("7 -> Voltar");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowEditEquipmentViewMenu(Equipment equipment)
        {
            Console.WriteLine();
            Console.WriteLine($"O que deseja alterar do equipamento '({equipment.Id}) - {equipment.Name}'?");
            Console.WriteLine();
            Console.WriteLine("1 -> Nome");
            Console.WriteLine("2 -> Preço");
            Console.WriteLine("3 -> Número de Série");
            Console.WriteLine("4 -> Data de Fabricação");
            Console.WriteLine("5 -> Fabricante");
            Console.WriteLine();
            Console.WriteLine("6 -> Voltar");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowEditRequesterViewMenu(Requester requester)
        {
            Console.WriteLine();
            Console.WriteLine($"O que deseja alterar do solicitante '({requester.Id}) - {requester.Name}'?");
            Console.WriteLine();
            Console.WriteLine("1 -> Nome");
            Console.WriteLine("2 -> E-mail");
            Console.WriteLine("3 -> Telefone");
            Console.WriteLine();
            Console.WriteLine("4 -> Voltar");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
        }

        public static void ShowRegisteredEquipmentsList()
        {
            if (EquipmentService.GetEquipments().Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------- Equipamentos disponíveis ---------");
                foreach (Equipment equipment in EquipmentService.GetEquipments())
                {
                    Console.WriteLine($"{equipment.Id} - {equipment.Name}");
                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void ShowRegisteredCallsList()
        {
            if (CallService.GetCalls().Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------- Chamados disponíveis ---------");
                foreach (Call call in CallService.GetCalls())
                {
                    Console.WriteLine($"{call.Id} - {call.Title}");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }
        }

        public static void ShowRegisteredRequestersList()
        {
            if (RequesterService.GetRequesters().Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------- Solicitantes disponíveis ---------");
                foreach (Requester requester in RequesterService.GetRequesters())
                {
                    Console.WriteLine($"{requester.Id} - {requester.Name}");
                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void PerformActionAgain(string message, Action a1, Action a2, Action a3)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("1 -> Sim");
            Console.WriteLine("2 -> Não");
            Console.WriteLine();
            ShowMessage("Opção: ", ConsoleColor.DarkCyan, false);
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    a1();
                    break;

                case 2:
                    a2();
                    break;

                default:
                    a3();
                    break;
            }
        }
    }
}