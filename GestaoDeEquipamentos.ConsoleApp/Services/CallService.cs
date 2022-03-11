using GestaoDeEquipamentos.ConsoleApp.Entities;

namespace GestaoDeEquipamentos.ConsoleApp.Services
{
    internal class CallService
    {
        private static readonly List<Call> _calls = new();
        public static void RegisterCall(Call call) => _calls.Add(call);
        public static void DeleteCall(Call call) => _calls.Remove(call);
        public static Call? FindCallById(int match) => _calls.Find(x => x.Id == match);
        public static List<Call> GetCalls() => _calls;
    }
}