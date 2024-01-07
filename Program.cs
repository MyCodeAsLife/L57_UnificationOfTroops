using System;
using System.Collections.Generic;
using System.Linq;

namespace L57_UnificationOfTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Headquarters headquarters = new Headquarters();
            string transferCondition = "б";

            Console.WriteLine("До перемещения:");
            headquarters.ShowAllPersonnels();

            headquarters.TransferSoldiers(transferCondition);

            Console.WriteLine("\nПосле перемещения:");
            headquarters.ShowAllPersonnels();
        }
    }

    class Headquarters
    {
        private List<Soldier> _firstSquad = new List<Soldier>();
        private List<Soldier> _secondSquad = new List<Soldier>();

        public Headquarters()
        {
            Fill();
        }

        public void ShowAllPersonnels()
        {
            int maxNameLenght = _firstSquad.Max(soldier => soldier.Name.Length);
            int maxRankLenght = _firstSquad.Max(soldier => soldier.Rank.Length);

            Console.WriteLine("Первый отряд:");
            Show(_firstSquad, maxNameLenght, maxRankLenght);
            Console.WriteLine("\nВторой отряд:");
            Show(_secondSquad, maxNameLenght, maxRankLenght);
            Console.WriteLine("--------------------------------------");
        }

        public void TransferSoldiers(string transferCondition)
        {
            var sortSquad = _firstSquad.Where(soldier => soldier.Name.ToLower().StartsWith(transferCondition)).ToList();

            foreach (var soldier in sortSquad)
            {
                _firstSquad.Remove(soldier);
                _secondSquad.Add(soldier);
            }
        }

        private void Show(List<Soldier> squad, int maxNameLenght, int maxRankLenght)
        {
            foreach (var soldier in squad)
                Console.WriteLine($"{{0, -{maxNameLenght}}} - {{1, -{maxRankLenght}}}", soldier.Name, soldier.Rank);
        }

        private void Fill()
        {
            _firstSquad.Add(new Soldier("Виталий", "Абакан", "Cтарший лейтенант", 36));
            _firstSquad.Add(new Soldier("Александр", "Люгер", "Майор", 48));
            _firstSquad.Add(new Soldier("Бенджамин", "Доллар", "Батя", 48));
            _firstSquad.Add(new Soldier("Рембо", "Мачете", "Засекречено", 99));
            _firstSquad.Add(new Soldier("Дмитрий", "ПКМ", "Подполковник", 68));
            _firstSquad.Add(new Soldier("Петр", "АК-74М", "Рядовой", 7));
            _firstSquad.Add(new Soldier("Борис Бритва", "Кольт М1911 А1", "Хрен попадеш", 98));

            _secondSquad.Add(new Soldier("Витек", "АК-74М", "Рядовой", 3));
            _secondSquad.Add(new Soldier("Саня", "АК-74М", "Рядовой", 5));
            _secondSquad.Add(new Soldier("Игорь", "АК-74М", "Рядовой", 1));
        }
    }

    class Soldier
    {
        public Soldier(string name, string weapon, string rank, int service)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            Service = service;
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int Service { get; private set; }
    }
}
