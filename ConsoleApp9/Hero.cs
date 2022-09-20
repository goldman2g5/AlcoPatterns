using System;
using System.Net.Mail;

namespace ConsoleApplication3
{
    [Serializable]
    public class Hero : IClonable
    {
        protected Weapon weapon;
        protected Movement movement;
        protected string moto;
        protected static int Counter = 1;
        protected Equipment Equipment;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
            moto = $"Я номер {Counter}";
            Counter++;
        }
        
        public Hero()
        {
            moto = $"Я номер {Counter}";
            Counter++;
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }

        public void ShowEquipment() => Console.WriteLine(Equipment.ToString());

        public void Equip(Equipment equipment) => Equipment = equipment;

        public void Moto() => Console.WriteLine(moto);
        public IClonable Clone()
        {
            return  (IClonable)((IClonable)this).DeepCopy()  ;
        }
    }
}