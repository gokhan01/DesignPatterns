using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeAggregate tarih = new DateTimeAggregate();
            tarih.StartDate = new DateTime(2020, 04, 01);
            tarih.EndDate = DateTime.Now;
            IIterator iterator = tarih.CreateIterator();
            while (iterator.HasDate())
            {
                Console.WriteLine(iterator.CurrentDate());
            }

            Console.Read();
        }
    }

    interface IAggregate
    {
        IIterator CreateIterator();
    }

    interface IIterator
    {
        bool HasDate();
        DateTime CurrentDate();
    }

    class DateTimeAggregate : IAggregate
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public IIterator CreateIterator() => new DateTimeIterator(this);
    }

    class DateTimeIterator : IIterator
    {
        readonly DateTimeAggregate _aggregate;
        DateTime _currentDate;
        public DateTimeIterator(DateTimeAggregate aggregate)
        {
            this._aggregate = aggregate;
            _currentDate = aggregate.StartDate;
        }
        public DateTime CurrentDate() => _currentDate;
        public bool HasDate()
        {
            if (_currentDate.DayOfWeek == DayOfWeek.Saturday || _currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                int dayCount = _currentDate.DayOfWeek == DayOfWeek.Saturday ? 1 : 6;
                _currentDate = _currentDate.AddDays(dayCount);
            }
            else
            {
                int dayCount = (int)_currentDate.DayOfWeek;
                _currentDate = _currentDate.AddDays(6 - dayCount);
                /*6'dan ilgili günün haftalık sayısını çıkarırsak eğer 
                 Cumartesi gününe kalan günü hesaplamış oluruz.
                 Haliyle bu hesabı ilgili tarihe eklersek eğer
                 o haftanın hafta sonuna ulaşmış oluruz.*/
            }
            return _currentDate < _aggregate.EndDate;
        }
    }
}
