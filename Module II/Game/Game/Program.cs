using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {       
        static void Main(string[] args)
        {           
            Heroes сharacter1 = new Сharacter();

            IActionable actCharacter = new Сharacter();
            IMoveable moveCharacter = new Сharacter();
            IInteractionable interactCharacter = new Сharacter();
            IDamageable сharacter = new Сharacter();

            Enemies wolf = new Wolf();
            IMoveable moveWolf = new Wolf();
            IDamageable damWolf = new Wolf();

            Enemies bear = new Bear();
            IMoveable movBear = new Bear();
            IDamageable damBear = new Bear();

            Bonus cherry = new Cherry();
            IInteractionable interCherry = new Cherry();

            Bonus apple = new Apple();
            IInteractionable interApple = new Apple();
   
        }

       
        public abstract class Location
        {
            public double Width { get; }
            public double Height { get; }
            public virtual void Point() { }// Расположение.Написать конструктор в классе вычислить местоположение.
        }
        interface IMoveable
        {
            void Movement(); //Движение. Передвигаются волки и персонаж.
        }
        interface IActionable
        {
            void Fight(); // бой

        }

        interface IDamageable
        {
            void Damage();// урон
        }


        interface IInteractionable // Взаимодействие          
        {
            void Increase(); // бонус (восстановление/пополнение)

        }

        public class Heroes : Location, IActionable, IInteractionable, IDamageable, IMoveable // здесь описывается логика методов. А в потомки лишь передаётся тип и вызывается существующая логика в родителе
        {
            public override void Point() { }
            public void Movement() { Console.WriteLine("Передвижение по осям X и Y"); } // действия персонажа(передвижение)
            public void Fight() { Console.WriteLine("Что будет, если персонаж выиграет нападение"); } //бой персонажа. Например, если при соответствии координат персонажа и нападающего персонаж успевает нажать букву Y, то он выигрывает бой
            public void Damage() { Console.WriteLine("Урон"); } //урон персонажа
            public void Increase() { Console.WriteLine("Бонус"); } // бонус персонажа

        }
        public class Enemies : Location, IMoveable, IDamageable // враги  от него наследуются волки, медведи
        {
            public override void Point() { Console.WriteLine("Рандомное месторасположение врагов"); }
            public void Movement() { Console.WriteLine("Движение врагов"); }
            public void Damage() { Console.WriteLine("Вам нанесли урон"); }
        }
        class Obstacles : Location // препятствия от него наследуются деревья, камни
        {
            public override void Point()
            {
                Console.WriteLine("Рандомное расположение бонусов");
            }
        }

        class Bonus : Location, IInteractionable  // бонусы от него наследуются яблоки, вишенки
        {
            public override void Point()
            {
                base.Point(); //Console.WriteLine("Рандомное расположение бонусов");
            }
            public void Increase() { Console.WriteLine("Бонус"); } // увеличивает что-то на 15 ед.

        }
        class Сharacter : Heroes// ПРОСТО НАСЛЕДОВАТЬСЯ И ВЫЗЫВАТЬ БАЗОВЫЙ КЛАСС!
        {
            public override void Point() { base.Point(); }
            public void Movement(IMoveable moveCharacter) { moveCharacter.Movement(); } // действия персонажа(передвижение)
            public void Fight(IActionable actCharacter) { actCharacter.Fight(); } //бой персонажа // факт одоления противника?
            public void Damage(IDamageable сharacter) { сharacter.Damage(); } //урон персонажа
            public void Increase(IInteractionable interactCharacter) { interactCharacter.Increase(); } // бонус персонажа*/
        }
        class Wolf : Enemies
        {
            public override void Point() { base.Point(); } // Console.WriteLine("Месторасположение врагов");  // сдлеать  Enemies wolf = new Wolf(); и будут доступны все свойства и методы

            public void Movement(IMoveable moveWolf) { moveWolf.Movement(); }// движение волка
            public void Damage(IDamageable damWolf) { damWolf.Damage(); } // если волк напал

        }
        class Bear : Enemies
        {
            public override void Point() { base.Point(); }// Console.WriteLine("Рандомное месторасположение врагов");  // сдлеать Enemies bear = new Bear(); и будут доступны все свойства и методы
            public void Movement(IMoveable movBear) { movBear.Movement(); } // движение медведя
            public void Damage(IDamageable movBear) { movBear.Damage(); } // если медведь напал

        }
        class Stone : Obstacles
        {
            public override void Point() { base.Point(); } // Console.WriteLine("Рандомное месторасположение камней");
        }
        class Wood : Obstacles
        {
            public override void Point() { Console.WriteLine("Рандомное месторасположение камней"); }
        }
        class Apple : Bonus
        {
            public override void Point()
            {
                base.Point();
            }
            public void Increase(IInteractionable interChaerry) { interChaerry.Increase(); }// увеличивает что-то на 15 ед.

        }

        class Cherry : Bonus
        {
            public override void Point()
            {
                base.Point();
            }
            public void Increase(IInteractionable interCherry) { interCherry.Increase(); } // увеличивает что-то на 15 ед.

        }
    }
}


