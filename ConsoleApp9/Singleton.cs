using System;
using System.Collections.Generic;

namespace ConsoleApplication3
{
    class Tavern
    {
        private static Tavern instance;
        private List<Hero> _members;

        private Tavern()
        {
            _members = new List<Hero>();
        }
 
        public static Tavern GetInstance()
        {
            return instance ??= new Tavern();
        }

        public void AddMember(Hero hero)
        {
            GetInstance()._members.Add(hero);
        }

        public void ShowMembers()
        {
            Console.WriteLine("Сейчас в таверне:");
            foreach (var i in _members)
                i.Moto();
            Console.WriteLine();
        }
    }
}