using gestao_de_equipamentos.Entities;

namespace gestao_de_equipamentos.Services
{
    public class EquipmentService
    {
        private static readonly List<Equipment> _equipments = new();
        public static void RegisterEquipment(Equipment equipment) => _equipments.Add(equipment);
        public static void DeleteEquipment(Equipment equipment) => _equipments.Remove(equipment);
        public static Equipment? FindEquipmentById(int match) => _equipments.Find(x => x.Id == match);
        public static List<Equipment> GetEquipments() => _equipments;
    }
}