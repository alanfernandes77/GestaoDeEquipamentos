using System.Text;

namespace gestao_de_equipamentos.Entities
{
    internal class Call
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public DateTime OpeningDate { get; set; }

        public Call(int id, string title, string description, int equipmentId)
        {
            Id = id;
            Title = title;
            Description = description;
            EquipmentId = equipmentId;
            OpeningDate = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID do chamado: {Id}");
            sb.AppendLine($"Titulo: {Title}");
            sb.AppendLine($"Descrição: {Description}");
            sb.AppendLine($"ID do equipamento: {EquipmentId}");
            sb.AppendLine($"Data de abertura: {OpeningDate:dd/MM/yyyy HH:mm}");
            TimeSpan ts = DateTime.Now.Subtract(OpeningDate);
            sb.AppendLine($"Aberto há: {ts.Days} dias, {ts.Hours} horas, {ts.Minutes} minutos e {ts.Seconds} segundos");
            return sb.ToString();
        }
    }
}