using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    //Subject
    class Stock
    {
        public Stock()
        {
            _financiers = new List<IFinancier>();
        }

        public string Name { get; set; }
        public List<IFinancier> _financiers;

        private decimal _lotValue;
        public decimal LotValue
        {
            get
            {
                return _lotValue;
            }
            set
            {
                _lotValue = value;
                Notify();
            }
        }

        private void Notify()
        {
            foreach (var financier in _financiers)
            {
                financier.Update(this);
            }
        }

        public void Subscribe(IFinancier financier)
        {
            _financiers.Add(financier);
        }

        public void UnSubscribe(IFinancier financier)
        {
            _financiers.Remove(financier);
        }
    }

    //Observer
    interface IFinancier
    {
        void Update(Stock stock);
    }

    //Concrete Observer
    class Financier : IFinancier
    {
        public string Name { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine("{0} hissesinin lot değeri {1} olarak güncellendi", stock.Name, stock.LotValue.ToString("C2"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock
            {
                Name = "test",
                LotValue = 10.5M
            };

            Financier financier1 = new Financier { Name = "test financier1" };
            stock.Subscribe(financier1);

            Financier financier2 = new Financier { Name = "test financier2" };
            stock.Subscribe(financier2);

            Console.WriteLine("{0} hissesinin güncel lot değeri {1}", stock.Name, stock.LotValue.ToString("C2"));

            stock.LotValue += 1;

            Console.ReadKey();
        }
    }
}
