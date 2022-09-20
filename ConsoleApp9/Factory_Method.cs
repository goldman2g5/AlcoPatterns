namespace ConsoleApplication3
{
    using System;

    namespace ConsoleApplication3
    {

        class WariorHero : Hero
        {
            private static int _warCounter = 1;

            public WariorHero()
            {
                moto = $"Я воин, мой номер {_warCounter}";
                _warCounter++;
            }
        }

        class ArcherHero : Hero
        {
            private static int _archCounter = 1;

            public ArcherHero()
            {
                moto = $"Я стрелок, мой номер {_archCounter}";
                _archCounter++;
            }
        }

        abstract class Guild
        {
            public string Name { get; set; }

            public Guild(string n)
            {
                Name = n;
            }

            // фабричный метод
            abstract public Hero Create();
        }

        // строит панельные дома
        class WariorGuild : Guild
        {
            private static WariorFactory _factory = new WariorFactory();
            public WariorGuild(string n) : base(n)
            {
            }

            public override Hero Create()
            {
                return new WariorHero();
            }
        }

        // строит деревянные дома
        class ArcherGuild : Guild
        {
            private static ArcherFactory _factory = new ArcherFactory();
            
            public ArcherGuild(string n) : base(n)
            {
            }

            public override Hero Create()
            {
                return new ArcherHero();
            }
        }
    }
}