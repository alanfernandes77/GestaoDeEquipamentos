using System.Text;
using GestaoDeEquipamentos.ConsoleApp.Enums;

namespace GestaoDeEquipamentos.ConsoleApp.Entities
{
    internal class Call
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Equipment Equipment { get; set; }
        public Requester Requester { get; set; }
        public DateTime OpeningDate { get; set; }
        public EnumCallStatus Status { get; set; }

        private readonly Random _randomId = new();

        public Call(string title, string description, Equipment equipment, Requester requester)
        {
            Id = _randomId.Next(10, 1000);
            Title = title;
            Description = description;
            Equipment = equipment;
            Requester = requester;
            OpeningDate = DateTime.Now;
            Status = EnumCallStatus.Aberto;
            Equipment.IsInMaintenanceCall = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID do chamado: {Id}");
            sb.AppendLine($"Titulo: {Title}");
            sb.AppendLine($"Descrição: {Description}");
            sb.AppendLine($"Equipamento: {Equipment.Name}");
            sb.AppendLine($"Solicitante: {Requester.Name}");
            sb.AppendLine($"Data de abertura: {OpeningDate:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Status do chamado: {Status}");
            TimeSpan ts = DateTime.Now.Subtract(OpeningDate);
            sb.AppendLine($"Aberto há: {ts.Days} dias, {ts.Hours} horas, {ts.Minutes} minutos e {ts.Seconds} segundos");
            return sb.ToString();
        }
    }
}