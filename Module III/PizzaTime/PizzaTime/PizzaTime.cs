using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PizzaTime
{
    public static class Events
    {
        public static void Main()
        {
            Cook.Go();
            Console.ReadLine();

            /* TypeWithLotsOfEventsTest();*/
        }

        /*  private static void TypeWithLotsOfEventsTest()
          {
              while (Console.ReadKey().Key != ConsoleKey.Escape)
              {
                  Console.WriteLine("Введите имя заказчика");
                  string a = Console.ReadLine();

                  Console.WriteLine("Введите заказ");
                  string b = Console.ReadLine();
                  Cook twle = new Cook();


                  twle.NewCook += HandleFooEvent;
                  twle.SimulateNewOrder(a, "", b);


                  twle.NewCook -= HandleFooEvent;
                  twle.SimulateNewOrder(a, "", b);
              }

              Console.ReadLine();

          }

          private static void Twle_NewCook(object sender, NewOrderEventsArgs e)
          {
              throw new NotImplementedException();
          }
          private static void HandleFooEvent(object sender, NewOrderEventsArgs e)
          {
              Console.WriteLine(" Заказ для = {0}, Пицца = {1}  готов!", e.From, e.Subject);
          }
      }*/
        #region  Step 1
        internal class NewOrderEventsArgs : EventArgs
        {
            private readonly string m_from, m_subject;
            public NewOrderEventsArgs(string from, string subject)
            {
                m_from = from;
                m_subject = subject;
            }
            public String From { get { return m_from; } }
            public String Subject { get { return m_subject; } }
        }

        #endregion

        #region Step 2 - 4
        internal class Cook // класс, содержащий событие
        {
            #region 
            public static void Go()
            {

                string from, subject;
                Console.WriteLine("Введите имя заказчика");
                from = Console.ReadLine();
                Console.WriteLine("Введите заказ");
                subject = Console.ReadLine();

                Cook cook = new Cook();


                Order order = new Order(cook);

                cook.SimulateNewOrder(from, subject);

                Thread.Sleep(3000);

                Console.WriteLine(" Order from {0} DONE! Take your order {1} ", from, subject);

                Thread.Sleep(2000);

                order.Unregister(cook);

            }

            #endregion


            private EventHandler<NewOrderEventsArgs> m_NewCook;
            public event EventHandler<NewOrderEventsArgs> NewCook //получатели уведомления о событии должны предоставлять метод обратного вызова, прототип которого совпадает с типом-делегатом EventHandl e r<NewMa i l EventArgs>.
            {

                add
                {
                    m_NewCook += value;
                }

                remove
                {
                    m_NewCook -= value;
                }
            }
            protected virtual void OnNewOrder(NewOrderEventsArgs e)
            {
                EventHandler<NewOrderEventsArgs> temp = Volatile.Read(ref m_NewCook);
                if (temp != null) temp(this, e);
            }

            public void SimulateNewOrder(string from, string subject)
            {
                NewOrderEventsArgs e = new NewOrderEventsArgs(from, subject);
                OnNewOrder(e);
            }

        }

        /* public static class EventArgExtensions //Всплытие
         {
             public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate)
             {
                 // Copy a reference to the delegate field now into a temporary field for thread safety 
                 EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);

                 // If any methods registered interest with our event, notify them  
                 if (temp != null) temp(sender, e);
             }
         }*/

        #endregion
        internal sealed class Order
        {
            public Order(Cook cook)
            {
                cook.NewCook += OrderMassage;
            }
            private void OrderMassage(object sender, NewOrderEventsArgs e) // sender = ссылка на объект класса Cook
            {

                Console.WriteLine("Order to {0} cooking", e.From);
            }
            public void Unregister(Cook cook)
            {
                cook.NewCook -= OrderMassage;
                Console.WriteLine("Order closed");

            }
        }
    }
}
