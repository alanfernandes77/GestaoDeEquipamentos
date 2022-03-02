using System.Globalization;

using gestao_de_equipamentos.Services;
using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Views.CallViews
{
    internal class EditCallView
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
                Console.Write("Digite o ID do chamado: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Call call = CallService.FindCallById(id);
                if (call == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Chamado não encontrado.");
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    CallMainView.Show();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"O que deseja alterar do chamado '({call.Id})'?");
                    Console.WriteLine();
                    Console.WriteLine("1 -> Título");
                    Console.WriteLine("2 -> Descrição");
                    Console.WriteLine("3 -> ID do equipamento");
                    Console.WriteLine("4 -> Data de Abertura");
                    Console.WriteLine();
                    Console.WriteLine("5 -> Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write($"Insira um novo título para o chamado '{call.Id}': ");
                            string newTitle = Console.ReadLine();
                            call.Title = newTitle;
                            Console.WriteLine();
                            Console.WriteLine($"Titulo alterado para '{newTitle}' com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write($"Insira uma nova descrição para o chamado '{call.Id}': ");
                            string newDescription = Console.ReadLine();
                            call.Description = newDescription;
                            Console.WriteLine();
                            Console.WriteLine($"Descrição alterada com sucesso!");
                            CheckChangeOtherProperty();
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write($"Insira um novo ID de equipamento para o chamado '{call.Id}': ");
                            int newId = Convert.ToInt32(Console.ReadLine());
                            Equipment? equipment = EquipmentService.FindEquipmentById(newId);
                            if (equipment == null)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipamento não encontrado.");
                                Console.WriteLine();
                                Console.WriteLine("Só é possível editar o ID de um equipamento registrado em um chamado se o mesmo estiver cadastrado.");
                                Console.WriteLine();
                                Console.Write("Pressione qualquer tecla para voltar.");
                                Console.ReadKey();
                                CallMainView.Show();
                            }
                            else
                            {
                                call.EquipmentId = newId;
                                Console.WriteLine();
                                Console.WriteLine($"ID do equipamento alterado para '{equipment.Id}'");
                                Console.WriteLine($"Equipamento: '({equipment.Id}) - {equipment.Name}'");
                                CheckChangeOtherProperty();
                            }
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Formato: dd/MM/yyyy HH:mm");
                            Console.Write($"Insira uma nova data de abertura para o chamado '{call.Id}' ");
                            DateTime newOpeningDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                            call.OpeningDate = newOpeningDate;
                            Console.WriteLine();
                            Console.WriteLine($"Data de abertura alterada para {call.OpeningDate:dd/MM/yyyy HH:mm}");
                            CheckChangeOtherProperty();
                            break;


                        case 5:
                            CallMainView.Show();
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("Opção não encontrada.");
                            Console.WriteLine();
                            Console.Write("Pressione qualquer tecla para voltar.");
                            Console.ReadKey();
                            CallMainView.Show();
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Erro: O valor fornecido é inválido.");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                CallMainView.Show();
            }
        }

        private static void CheckChangeOtherProperty()
        {
            Console.WriteLine();
            Console.WriteLine("Deseja alterar alguma outra coisa?");
            Console.WriteLine();
            Console.WriteLine("1 -> Sim (Será necessário inserir o ID do chamado novamente)");
            Console.WriteLine("2 -> Não");
            Console.WriteLine();
            Console.Write("Opção: ");
            int option2 = Convert.ToInt32(Console.ReadLine());
            switch (option2)
            {
                case 1:
                    Show();
                    break;
                case 2:
                    CallMainView.Show();
                    break;
                default:
                    Console.ReadKey();
                    CallMainView.Show();
                    break;
            }
        }
    }
}