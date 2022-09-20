using System;
using ConsoleApplication3.ConsoleApplication3;

namespace ConsoleApplication3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            #region "Абстрактная фабрика"

            #region Коментарии

            // Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс для создания семейств взаимосвязанных объектов с определенными интерфейсами без указания конкретных типов данных объектов.
            // Когда система не должна зависеть от способа создания и компоновки новых объектов
            //
            // Когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными

            // недостатки - если нам захочется добавить в конфигурацию героя новый
            //     объект, например, тип одежды, то придется переделывать классы фабрик и класс героя.Поэтому
            //     возможности по расширению в данном паттерне имеют некоторые ограничения.

            #endregion

            Hero elf = new Hero(new ArcherFactory());
            elf.Hit();
            elf.Run();

            Hero warior = new Hero(new WariorFactory());
            warior.Hit();
            warior.Run();

            Console.ReadLine();

            #endregion

            #region Builder

            #region Коментарии

            // Строитель (Builder) - шаблон проектирования, который инкапсулирует создание объекта и позволяет разделить его на различные этапы.
            // Когда процесс создания нового объекта не должен зависеть от того, из каких частей этот объект состоит и как эти части связаны между собой
            //
            // Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания

            #endregion

            Blacksmith blacksmith = new Blacksmith();
            EquipmentBuilder builder = new ElfEquipmentBuilder();
            Equipment elfEquipment = blacksmith.Assemble(builder);
            elf.Equip(blacksmith.Assemble(builder));
            elf.ShowEquipment();
            builder = new WariorEquipmentBuilder();
            warior.Equip(blacksmith.Assemble(builder));
            warior.ShowEquipment();
            Console.Read();

            #endregion

            #region Прототип

            #region Коментарии

            // Паттерн Прототип (Prototype) позволяет создавать объекты на основе уже ранее созданных объектов-прототипов. То есть по сути данный паттерн предлагает технику клонирования объектов.

            #endregion

            elf.Moto();
            warior.Moto();

            Hero clone = elf.Clone() as Hero;
            clone.Moto();
            Console.ReadLine();
            #endregion

            #region Фабричный метод

            #region Коментарии

            //Фабричный метод(Factory Method) -это паттерн, который определяет интерфейс для создания объектов некоторого класса, но непосредственное
            //     решение о том, объект какого класса создавать происходит в подклассах.То есть паттерн
            //     предполагает, что базовый класс делегирует создание объектов классам - наследникам.

            #endregion

            Guild wariorGuild = new WariorGuild("Бебра");
            Hero guildWarior = wariorGuild.Create();
            guildWarior.Moto();


            Guild archerGuild = new ArcherGuild("Бруско");
            Hero guildArcher = archerGuild.Create();
            guildArcher.Moto();
            archerGuild.Create().Moto();
            Console.ReadLine();
            Console.WriteLine();

            #endregion

            #region Синглтон

            #region Коментарии

            // Одиночка(Singleton, Синглтон) - порождающий паттерн, который гарантирует, что для определенного класса
            //     будет создан только один объект, а также предоставит к этому объекту точку доступа.

            #endregion
            Tavern tavern = Tavern.GetInstance();
            tavern.AddMember(guildArcher);
            Tavern.GetInstance().ShowMembers();


            Tavern.GetInstance().AddMember(warior);
            tavern.ShowMembers();
            Console.ReadLine();
            #endregion

            
        }
    }
}