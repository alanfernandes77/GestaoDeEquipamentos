using System.Text;

namespace GestaoDeEquipamentos.ConsoleApp.Entities
{
    internal class Requester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        private readonly Random _randomId = new();

        public Requester(string name, string email, string phoneNumber)
        {
            Id = _randomId.Next(10, 1000);
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Telefone: {PhoneNumber}");
            return sb.ToString();
        }
    }
}