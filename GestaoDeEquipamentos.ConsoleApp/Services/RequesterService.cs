using System;
using GestaoDeEquipamentos.ConsoleApp.Entities;

namespace GestaoDeEquipamentos.ConsoleApp.Services
{
    internal class RequesterService
    {
        private static readonly List<Requester> _requesters = new();
    
        public static void RegisterRequester(Requester requester) => _requesters.Add(requester);   
        public static void DeleteRequester(Requester requester) => _requesters.Remove(requester);
        public static Requester? FindRequesterById(int match) => _requesters.Find(r => r.Id == match);
        public static List<Requester> GetRequesters() => _requesters;
    }
}