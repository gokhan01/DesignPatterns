using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            IArabaBuilder araba = new OpelConcreteBuilder();
            ArabaUret uret = new ArabaUret();
            uret.Uret(araba);

            Console.WriteLine(araba.Araba.ToString());

            araba = new ToyotaConcreteBuilder();
            uret.Uret(araba);
            Console.WriteLine(araba.Araba.ToString());

            Console.Read();
        }
    }

    //Director Class
    class ArabaUret
    {
        public void Uret(IArabaBuilder Araba)
        {
            Araba.SetKM();
            Araba.SetMarka();
            Araba.SetModel();
            Araba.SetVites();
        }
    }

    //ConcreteBuilder Class
    class OpelConcreteBuilder : IArabaBuilder
    {
        public OpelConcreteBuilder()
        {
            araba = new Araba();
        }
        public override void SetKM() => araba.KM = 100;
        public override void SetMarka() => araba.Marka = "Opel";
        public override void SetModel() => araba.Model = "Astra";
        public override void SetVites() => araba.Vites = true;
    }
    //ConcreteBuilder Class
    class ToyotaConcreteBuilder : IArabaBuilder
    {
        public ToyotaConcreteBuilder()
        {
            araba = new Araba();
        }
        public override void SetKM() => araba.KM = 150;
        public override void SetMarka() => araba.Marka = "Toyota";
        public override void SetModel() => araba.Model = "Corolla";
        public override void SetVites() => araba.Vites = true;
    }
    //ConcreteBuilder Class
    class BMWConcreteBuilder : IArabaBuilder
    {
        public BMWConcreteBuilder()
        {
            araba = new Araba();
        }
        public override void SetKM() => araba.KM = 25;
        public override void SetMarka() => araba.Marka = "BMW";
        public override void SetModel() => araba.Model = "X Bilmem Kaç";
        public override void SetVites() => araba.Vites = true;
    }
}
