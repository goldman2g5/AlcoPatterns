using System;

namespace ConsoleApplication3
{
    [Serializable]
    public abstract class Weapon
    {
        public abstract void Hit();
    }

// абстрактный класс движение
    [Serializable]
    public abstract class Movement
    {
        public abstract void Move();
    }
// класс арбалет
    [Serializable]
    public class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }

// класс меч
    [Serializable]
    public class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }

// движение полета
    [Serializable]
    public class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }

// движение - бег
    [Serializable]
    public class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }

// класс абстрактной фабрики
    [Serializable]
    public abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

// Фабрика создания летящего героя с арбалетом
    [Serializable]
    public class ArcherFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

// Фабрика создания бегущего героя с мечом
    [Serializable]
    public class WariorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
}