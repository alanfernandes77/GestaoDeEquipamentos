using System.Text;
using System.Globalization;

namespace gestao_de_equipamentos.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Manufacturer { get; set; }

        public Equipment(int id, string name, double price, string serialNumber, DateTime manufactureDate, string manufacturer)
        {
            Id = id;
            Name = name;
            Price = price;
            SerialNumber = serialNumber;
            ManufactureDate = manufactureDate;
            Manufacturer = manufacturer;
        }


        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine($"Preço: R$ {Price.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Número de Série: {SerialNumber}");
            sb.AppendLine($"Data de Fabricação: {ManufactureDate:dd/MM/yyyy}");
            sb.AppendLine($"Fabricante: {Manufacturer}");
            return sb.ToString();
        }
    }
}