using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class GameWorld
    {
        public string Name { get; set; }
        public long Population { get; set; }

        public GameWorldMemento Save()
        {
            return new GameWorldMemento
            {
                Name = Name,
                Population = Population
            };
        }

        public void Undo(GameWorldMemento memento)
        {
            Name = memento.Name;
            Population = memento.Population;
        }

        public override string ToString()
        {
            return string.Format("{0} dünyasında {1} insan var", Name, Population);
        }
    }

    //Memento Class
    class GameWorldMemento
    {
        public string Name { get; set; }
        public long Population { get; set; }
    }

    //CareTaker Class
    class GameWorldCareTaker
    {
        public GameWorldMemento World { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameWorld test = new GameWorld
            {
                Name = "test",
                Population = 100000
            };

            GameWorldCareTaker taker = new GameWorldCareTaker();
            taker.World = test.Save();

            test.Population += 20;
            Console.WriteLine(test.ToString());

            test.Undo(taker.World);
            Console.WriteLine(test.ToString());

            Console.ReadKey();
        }
    }
}
