using System.Text;
using System.Globalization;

namespace GestaoDeEquipamentos.ConsoleApp.Entities
{
    public class Equipment : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Manufacturer { get; set; }
        public bool IsInMaintenanceCall { get; set; }
        public int TimesInMaintenance { get; set; }

        public Equipment(int id, string name, double price, string serialNumber, DateTime manufactureDate, string manufacturer)
        {
            Id = id;
            Name = name;
            Price = price;
            SerialNumber = serialNumber;
            ManufactureDate = manufactureDate;
            Manufacturer = manufacturer;
            IsInMaintenanceCall = false;
            TimesInMaintenance = 0;
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
        public int CompareTo(object? obj)
        {
            Equipment? other = obj as Equipment;
            return TimesInMaintenance.CompareTo(other.TimesInMaintenance);
        }
    }
}